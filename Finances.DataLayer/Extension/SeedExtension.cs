﻿namespace Finances.DataLayer.Extension
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class SeedExtension
    {
        /// <summary>
        /// Add or Updates and Object according to the updating expression. Prevents that Seed wil
        /// set the CreatedAt to Now to old objects. USE ONLY at Seed Method
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="db">The database.</param>
        /// <param name="identifierExpression">The identifier expression.</param>
        /// <param name="updatingExpression">The updating expression.</param>
        /// <param name="entities">The entities.</param>
        internal static void SeedAddOrUpdate<T>(this DbContext db, Expression<Func<T, object>> identifierExpression, Expression<Func<T, object>> updatingExpression, params T[] entities) where T : class
        {
            if (updatingExpression == null)
            {
                db.Set<T>().AddOrUpdate(identifierExpression, entities);
                return;
            }

            var identifyingProperties = GetProperties<T>(identifierExpression).ToList();
            Debug.Assert(identifyingProperties.Count != 0);

            var updatingProperties = GetProperties<T>(updatingExpression).Where(pi => IsModifiedable(pi.PropertyType)).ToList();
            Debug.Assert(updatingProperties.Count != 0);

            var parameter = Expression.Parameter(typeof(T));
            foreach (var entity in entities)
            {
                var matches = identifyingProperties.Select(pi => Expression.Equal(Expression.Property(parameter, pi.Name), Expression.Constant(pi.GetValue(entity, null))));
                var matchExpression = matches.Aggregate<BinaryExpression, Expression>(null, (agg, v) => (agg == null) ? v : Expression.AndAlso(agg, v));

                var predicate = Expression.Lambda<Func<T, bool>>(matchExpression, new[] { parameter });
                var existing = db.Set<T>().SingleOrDefault(predicate);
                if (existing == null)
                {
                    // New.
                    db.Set<T>().Add(entity);
                    continue;
                }

                // Update.
                foreach (var prop in updatingProperties)
                {
                    if (prop.Name == "ChangeAt")
                    {
                        db.Entry(existing).Property(prop.Name).IsModified = true;
                        prop.SetValue(existing, DateTime.Now);
                        continue;
                    }

                    var oldValue = prop.GetValue(existing, null);
                    var newValue = prop.GetValue(entity, null);
                    if (Equals(oldValue, newValue))
                    {
                        continue;
                    }

                    db.Entry(existing).Property(prop.Name).IsModified = true;
                    prop.SetValue(existing, newValue);
                }
            }
        }

        private static IEnumerable<PropertyInfo> GetProperties<T>(Expression<Func<T, object>> exp) where T : class
        {
            Debug.Assert(exp != null);
            Debug.Assert(exp.Body != null);
            Debug.Assert(exp.Parameters.Count == 1);

            var type = typeof(T);
            var properties = new List<PropertyInfo>();

            if (exp.Body.NodeType == ExpressionType.MemberAccess)
            {
                var memExp = exp.Body as MemberExpression;
                if (memExp != null && memExp.Member != null) properties.Add(type.GetProperty(memExp.Member.Name));
            }
            else if (exp.Body.NodeType == ExpressionType.Convert)
            {
                var unaryExp = exp.Body as UnaryExpression;
                if (unaryExp != null)
                {
                    var propExp = unaryExp.Operand as MemberExpression;
                    if (propExp != null && propExp.Member != null) properties.Add(type.GetProperty(propExp.Member.Name));
                }
            }
            else if (exp.Body.NodeType == ExpressionType.New)
            {
                var newExp = exp.Body as NewExpression;
                if (newExp != null) properties.AddRange(newExp.Members.Select(x => type.GetProperty(x.Name)));
            }

            return properties.OfType<PropertyInfo>();
        }

        private static bool IsModifiedable(Type type)
        {
            return type.IsPrimitive || type.IsValueType || type == typeof(string);
        }
    }
}