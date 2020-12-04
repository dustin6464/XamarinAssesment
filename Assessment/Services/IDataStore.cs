using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Helpers;

namespace Assessment
{
    public interface IDataStore<T>
    {
        Task<bool> AddModelAsync(T list);
        Task<bool> UpdateModelAsync(T list);
        Task<bool> DeleteModelAsync(T list);
        Task<T> GetModelAsync(int id);
        Task<IEnumerable<T>> GetModelsAsync(bool forceRefresh = false, Dictionary<Constants.Parameter, object> parameters = null);
    }
}
