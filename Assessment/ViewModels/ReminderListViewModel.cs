using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Helpers;
using Assessment.Models;

namespace Assessment
{
    public class ReminderListViewModel : BaseViewModel
    {
        public ReminderList ReminderList;
        public ObservableCollection<Reminder> Reminders { get; set; }
        public Command LoadReminderListCommand { get; set; }
        public Command AddReminderCommand { get; set; }
        public Command DeleteReminderCommand { get; set; }
        public Command UpdateReminderCommand {get; set; }

        public ReminderListViewModel(ReminderList list = null)
        {
            if (list != null)
            {
                ReminderList = list;
            }

            Title = "Reminder Lists";
            Reminders = new ObservableCollection<Reminder>();
            LoadReminderListCommand = new Command(async () => await ExecuteLoadRemindersCommand());
            AddReminderCommand = new Command<Reminder>(async (Reminder reminder) => await AddReminder(reminder));
            DeleteReminderCommand = new Command<Reminder>(async (Reminder reminder) => await DeleteReminder(reminder));
            UpdateReminderCommand = new Command<Reminder>(async (Reminder reminder) => await UpdateReminder(reminder));
        }

        async Task ExecuteLoadRemindersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Reminders.Clear();
                var parameters = new Dictionary<Constants.Parameter, object>();
                parameters[Constants.Parameter.ReminderListId] = ReminderList.Id;
                var reminders = await ReminderDataStore.GetModelsAsync(true, parameters);
                reminders = reminders.OrderBy(r => r.Completed).ThenByDescending(r => r.DueDate);
                foreach (var reminder in reminders)
                {
                    Reminders.Add(reminder);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task AddReminder(Reminder reminder)
        {
            Reminders.Insert(0, reminder);
            await ReminderDataStore.AddModelAsync(reminder);
        }

        async Task DeleteReminder(Reminder reminder)
        {
            Reminders.Remove(reminder);
            await ReminderDataStore.DeleteModelAsync(reminder);
        }

        async Task UpdateReminder(Reminder reminder)
        {
            await ReminderDataStore.UpdateModelAsync(reminder);
            await ExecuteLoadRemindersCommand();
        }
    }
}
