using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Helpers;
using Assessment.Models;

namespace Assessment.Services.Mock
{
    public class MockReminderDataStore : IDataStore<Reminder>
    {
        List<Reminder> reminders;

        public MockReminderDataStore()
        {
            reminders = new List<Reminder>()
            {
                new Reminder() { ListId = 0, Id = 0, Completed = false, Title = "Paint Shed", DueDate = null },
                new Reminder() { ListId = 0, Id = 1, Completed = false, Title = "Build Table", DueDate = DateTime.Now  },
                new Reminder() { ListId = 0, Id = 2, Completed = true, Title = "Powerwash Gazebo", DueDate = DateTime.Now.AddDays(1) },
                new Reminder() { ListId = 0, Id = 3, Completed = true, Title = "Fix Ceiling Fan", DueDate = null }
            };
        }

        public async Task<bool> AddModelAsync(Reminder reminder)
        {
            reminders.Add(reminder);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateModelAsync(Reminder reminder)
        {
            var _reminder = reminders.Where((Reminder arg) => arg.Id == reminder.Id).FirstOrDefault();
            reminders.Remove(_reminder);
            reminders.Add(_reminder);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteModelAsync(Reminder list)
        {
            var _reminder = reminders.Where((Reminder arg) => arg.Id == list.Id).FirstOrDefault();
            reminders.Remove(_reminder);

            return await Task.FromResult(true);
        }

        public async Task<Reminder> GetModelAsync(int id)
        {
            return await Task.FromResult(reminders.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Reminder>> GetModelsAsync(bool forceRefresh = false, Dictionary<Constants.Parameter, object> parameters = null)
        {
            return await Task.FromResult(reminders);
        }
    }
}
