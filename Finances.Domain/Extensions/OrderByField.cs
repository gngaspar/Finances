namespace Finances.Domain.Extensions
{
    using System.Data.SqlClient;
    using System.Linq;
    using Finances.Contract.Banking;
    using Finances.Domain.Banking;

    public static class OrderByField
    {
        public static IQueryable<BankEntity> OrderByFieldBank(this IQueryable<BankEntity> bankEntity, SortOrder order, BankField orderByProperty)
        {
            switch (order)
            {
                case SortOrder.Ascending:

                    switch (orderByProperty)
                    {
                        case BankField.Country:
                            bankEntity = bankEntity.OrderBy(x => x.Country);
                            break;

                        case BankField.Name:
                            bankEntity = bankEntity.OrderBy(x => x.Name);
                            break;

                        case BankField.Swift:
                            bankEntity = bankEntity.OrderBy(x => x.Swift);
                            break;
                    }
                    break;

                case SortOrder.Descending:

                    switch (orderByProperty)
                    {
                        case BankField.Country:
                            bankEntity = bankEntity.OrderByDescending(x => x.Country);
                            break;

                        case BankField.Name:
                            bankEntity = bankEntity.OrderByDescending(x => x.Name);
                            break;

                        case BankField.Swift:
                            bankEntity = bankEntity.OrderByDescending(x => x.Swift);
                            break;
                    }
                    break;
            }

            return bankEntity;
        }
    }
}