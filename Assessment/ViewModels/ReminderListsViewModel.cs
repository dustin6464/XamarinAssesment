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
    public class ReminderListsViewModel : BaseViewModel
    {
        public ObservableCollection<ReminderList> ReminderLists { get; set; }
        public Command LoadReminderListsCommand { get; set; }
        public Command AddReminderListCommand { get; set; }
        public Command DeleteReminderListCommand { get; set; }
        public Command UpdateReminderCommand { get; set; }

        public ReminderListsViewModel()
        {
            Title = "Reminder Lists";
            ReminderLists = new ObservableCollection<ReminderList>();
            LoadReminderListsCommand = new Command(async () => await ExecuteLoadReminderListsCommand());
            AddReminderListCommand = new Command<ReminderList>(async (ReminderList list) => await AddList(list));
            DeleteReminderListCommand = new Command<ReminderList>(async (ReminderList list) => await DeleteList(list));
            UpdateReminderCommand = new Command<ReminderList>(async (ReminderList list) => await UpdateReminder(list));
        }

        async Task ExecuteLoadReminderListsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ReminderLists.Clear();
                var lists = await ReminderListDataStore.GetModelsAsync(true);
                foreach (var list in lists)
                {
                    var reminders = await ReminderDataStore.GetModelsAsync(false, new Dictionary<Constants.Parameter, object>() { { Constants.Parameter.ReminderListId, list.Id } });
                    list.DetailString = string.Format("{0} todo of {1}", reminders.Where(r => r.Completed == false).ToList().Count(), reminders.Count());
                    ReminderLists.Add(list);
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

        async Task AddList(ReminderList list)
        {
            ReminderLists.Insert(0, list);
            await ReminderListDataStore.AddModelAsync(list);
        }

        async Task DeleteList(ReminderList list)
        {
            ReminderLists.Remove(list);
            await ReminderListDataStore.DeleteModelAsync(list);
            //todo: delete all reminders on this list
        }

        async Task UpdateReminder(ReminderList list)
        {
            await ReminderListDataStore.UpdateModelAsync(list);
            await ExecuteLoadReminderListsCommand();
        }
    }
}
