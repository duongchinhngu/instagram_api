using Instagram.HttpMessages.Requests;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Instagram.Helpers.SortHelpers
{
    public class SortHelper : ISortHelper
    {
        public void ApplySort<TEntity>(ref IQueryable<TEntity> entities, string sortBy, OrderType orderBy) where TEntity : class
        {
            if (!entities.Any())
            {
                return;
            }

            if (string.IsNullOrEmpty(sortBy) || orderBy.Equals(OrderType.None))
            {
                return;
            }

            var propertyInfo = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sortQueryBuilder = new StringBuilder();

            var objectAttribute = propertyInfo.FirstOrDefault(pi => pi.Name.Equals(sortBy, StringComparison.OrdinalIgnoreCase));
            //var sortingOrder = OrderType.Ascending.ToString().Contains(orderBy.ToString()) ? "ascending" : "descending";

            sortQueryBuilder.Append($"{objectAttribute.Name.ToString()} {orderBy.ToString()}");

            entities = entities.OrderBy(sortQueryBuilder.ToString());
        }
    }
}
