using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Helpers;
using Assessment.Models;
using SQLite;

namespace Assessment
{
    public class ReminderListDataStore : IDataStore<ReminderList>
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ReminderListDataStore()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ReminderList).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.AutoIncPK, typeof(ReminderList)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public async Task<bool> AddModelAsync(ReminderList list)
        {
            return await Database.InsertAsync(list) == 1;
        }

        public async Task<bool> UpdateModelAsync(ReminderList list)
        {
            return await Database.UpdateAsync(list) == 1;
        }

        public async Task<bool> DeleteModelAsync(ReminderList list)
        {
            return await Database.DeleteAsync(list) == 1;
        }

        public Task<ReminderList> GetModelAsync(int id)
        {
            return Database.Table<ReminderList>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ReminderList>> GetModelsAsync(bool forceRefresh = false, Dictionary<Constants.Parameter, object> parameters = null)
        {
            return await Database.Table<ReminderList>().OrderByDescending(r => r.CreatedDate).ToListAsync();
        }
    }
}
