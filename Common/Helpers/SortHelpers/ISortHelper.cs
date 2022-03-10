
using Instagram.HttpMessages.Requests;
using System.Linq;

namespace Instagram.Helpers.SortHelpers
{
    public interface ISortHelper
    {
        void ApplySort<TEntity>(ref IQueryable<TEntity> entities, string sortBy, OrderType orderBy) where TEntity : class;
    }
}
