using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Helpers;
using Assessment.Models;
using SQLite;

namespace Assessment
{
    public class ReminderDataStore : IDataStore<Reminder>
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ReminderDataStore()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Reminder).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.AutoIncPK, typeof(Reminder)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public async Task<bool> AddModelAsync(Reminder reminder)
        {
            return await Database.InsertAsync(reminder) == 1;
        }

        public async Task<bool> UpdateModelAsync(Reminder reminder)
        {
            return await Database.UpdateAsync(reminder) == 1;
        }

        public async Task<bool> DeleteModelAsync(Reminder reminder)
        {
            return await Database.DeleteAsync(reminder) == 1;
        }

        public Task<Reminder> GetModelAsync(int id)
        {
            return Database.Table<Reminder>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Reminder>> GetModelsAsync(bool forceRefresh = false, Dictionary<Constants.Parameter, object> parameters = null)
        {
            int result;
            if (parameters.ContainsKey(Constants.Parameter.ReminderListId) && int.TryParse(parameters[Constants.Parameter.ReminderListId].ToString(), out result))
            {
                return await Database.Table<Reminder>().Where(r => r.ListId == result).ToListAsync();
            }
            else
            {
                return new List<Reminder>();
            }
        }
    }
}
