using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Helpers;
using Assessment.Models;

namespace Assessment.Services.Mock
{
    public class MockReminderListDataStore : IDataStore<ReminderList>
    {
        List<ReminderList> reminderLists;

        public MockReminderListDataStore()
        {
            reminderLists = new List<ReminderList>
            {
                new ReminderList() { Id = 0, Title = "House Work" , Color = "3780bf" },
                new ReminderList() { Id = 1, Title = "Work", Color = "eb4034" },
                new ReminderList() { Id = 2, Title = "Christmas Gift Ideas", Color = "4bb334" },
                new ReminderList() { Id = 3, Title = "Chruch Projects", Color = "472fa8" },
            };
        }

        public async Task<bool> AddModelAsync(ReminderList list)
        {
            reminderLists.Add(list);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateModelAsync(ReminderList list)
        {
            var _list = reminderLists.Where((ReminderList arg) => arg.Id == list.Id).FirstOrDefault();
            reminderLists.Remove(_list);
            reminderLists.Add(_list);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteModelAsync(ReminderList list)
        {
            var _list = reminderLists.Where((ReminderList arg) => arg.Id == list.Id).FirstOrDefault();
            reminderLists.Remove(_list);

            return await Task.FromResult(true);
        }

        public async Task<ReminderList> GetModelAsync(int id)
        {
            return await Task.FromResult(reminderLists.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ReminderList>> GetModelsAsync(bool forceRefresh = false, Dictionary<Constants.Parameter, object> parameters = null)
        {
            return await Task.FromResult(reminderLists);
        }
    }
}
