namespace Finances.Domain.Extensions
{
    using System.Data.SqlClient;
    using System.Linq;
    using Finances.Contract.Banking;
    using Finances.Contract.Humans;
    using Finances.Domain.Banking;
    using Finances.Domain.Human;

    public static class OrderByField
    {
        public static IQueryable<BankEntity> OrderByFieldBank(this IQueryable<BankEntity> entity, SortOrder order, BankField orderByProperty)
        {
            switch (order)
            {
                case SortOrder.Ascending:

                    switch (orderByProperty)
                    {
                        case BankField.Country:
                            entity = entity.OrderBy(x => x.Country);
                            break;

                        case BankField.Name:
                            entity = entity.OrderBy(x => x.Name);
                            break;

                        case BankField.Swift:
                            entity = entity.OrderBy(x => x.Swift);
                            break;
                    }
                    break;

                case SortOrder.Descending:

                    switch (orderByProperty)
                    {
                        case BankField.Country:
                            entity = entity.OrderByDescending(x => x.Country);
                            break;

                        case BankField.Name:
                            entity = entity.OrderByDescending(x => x.Name);
                            break;

                        case BankField.Swift:
                            entity = entity.OrderByDescending(x => x.Swift);
                            break;
                    }
                    break;
            }

            return entity;
        }


        public static IQueryable<PersonEntity> OrderByFieldPerson(this IQueryable<PersonEntity> entity, SortOrder order, HumanField orderByProperty)
        {
            switch (order)
            {
                case SortOrder.Ascending:

                    switch (orderByProperty)
                    {
                        case HumanField.Name:
                            entity = entity.OrderBy(x => x.Name);
                            break;

                        case HumanField.Email:
                            entity = entity.OrderBy(x => x.Email);
                            break;

                        case HumanField.Surname:
                            entity = entity.OrderBy(x => x.Surname);
                            break;
                    }
                    break;

                case SortOrder.Descending:

                    switch (orderByProperty)
                    {
                        case HumanField.Name:
                            entity = entity.OrderByDescending(x => x.Name);
                            break;

                        case HumanField.Email:
                            entity = entity.OrderByDescending(x => x.Email);
                            break;

                        case HumanField.Surname:
                            entity = entity.OrderByDescending(x => x.Surname);
                            break;
                    }
                    break;
            }

            return entity;
        }
    }
}