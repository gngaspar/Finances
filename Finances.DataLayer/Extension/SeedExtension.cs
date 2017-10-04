// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeedExtension.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The seed extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer.Extension
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// The seed extension.
    /// </summary>
    internal static class SeedExtension
    {
        /// <summary>
        /// Add or Updates and Object according to the updating expression. Prevents that Seed will
        /// set the CreatedAt to Now to old objects. USE ONLY at Seed Method.
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="db">The database.</param>
        /// <param name="identifierExpression">The identifier expression.</param>
        /// <param name="updatingExpression">The updating expression.</param>
        /// <param name="entities">The entities.</param>
        internal static void SeedAddOrUpdate<T>( this DbContext db, Expression<Func<T, object>> identifierExpression, Expression<Func<T, object>> updatingExpression, params T[] entities ) where T : class
        {
            if ( updatingExpression == null )
            {
                db.Set<T>().AddOrUpdate( identifierExpression, entities );
                return;
            }

            var identifyingProperties = GetProperties<T>( identifierExpression ).ToList();

            var updatingProperties = GetProperties<T>( updatingExpression ).Where( pi => IsModifiedable( pi.PropertyType ) ).ToList();

            var parameter = Expression.Parameter( typeof( T ) );
            foreach ( var entity in entities )
            {
                var matches = identifyingProperties.Select( pi => Expression.Equal( Expression.Property( parameter, pi.Name ), Expression.Constant( pi.GetValue( entity, null ) ) ) );
                var matchExpression = matches.Aggregate<BinaryExpression, Expression>( null, ( agg, v ) => ( agg == null ) ? v : Expression.AndAlso( agg, v ) );

                var predicate = Expression.Lambda<Func<T, bool>>( matchExpression, new[] { parameter } );
                var existing = db.Set<T>().SingleOrDefault( predicate );
                if ( existing == null )
                {
                    // New.
                    db.Set<T>().Add( entity );
                    continue;
                }

                // Update.
                foreach ( var prop in updatingProperties )
                {
                    if ( prop.Name == "ChangeAt" )
                    {
                        db.Entry( existing ).Property( prop.Name ).IsModified = true;
                        prop.SetValue( existing, DateTime.Now );
                        continue;
                    }

                    var oldValue = prop.GetValue( existing, null );
                    var newValue = prop.GetValue( entity, null );
                    if ( object.Equals( oldValue, newValue ) )
                    {
                        continue;
                    }

                    db.Entry( existing ).Property( prop.Name ).IsModified = true;
                    prop.SetValue( existing, newValue );
                }
            }
        }

        /// <summary>
        /// The get properties.
        /// </summary>
        /// <param name="exp">
        /// The expression.
        /// </param>
        /// <typeparam name="T">
        /// The type.
        /// </typeparam>
        /// <returns>
        /// The enumerable of PropertyInfo.
        /// </returns>
        private static IEnumerable<PropertyInfo> GetProperties<T>( Expression<Func<T, object>> exp ) where T : class
        {
            var type = typeof( T );
            var properties = new List<PropertyInfo>();

            if ( exp.Body.NodeType == ExpressionType.MemberAccess )
            {
                var memExp = exp.Body as MemberExpression;
                if ( memExp != null && memExp.Member != null )
                {
                    properties.Add( type.GetProperty( memExp.Member.Name ) );
                }
            }
            else if ( exp.Body.NodeType == ExpressionType.Convert )
            {
                var unaryExp = exp.Body as UnaryExpression;
                if ( unaryExp != null )
                {
                    var propExp = unaryExp.Operand as MemberExpression;
                    if ( propExp != null && propExp.Member != null )
                    {
                        properties.Add( type.GetProperty( propExp.Member.Name ) );
                    }
                }
            }
            else if ( exp.Body.NodeType == ExpressionType.New )
            {
                var newExp = exp.Body as NewExpression;
                if ( newExp != null )
                {
                    properties.AddRange( newExp.Members.Select( x => type.GetProperty( x.Name ) ) );
                }
            }

            return properties.OfType<PropertyInfo>();
        }

        /// <summary>
        /// Can be modified.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsModifiedable( Type type )
        {
            return type.IsPrimitive || type.IsValueType || type == typeof( string );
        }
    }
}