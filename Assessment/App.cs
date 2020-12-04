using System;
using Assessment.Models;
using Assessment.Services.Mock;

namespace Assessment
{
    public class App
    {
        public static bool UseMockDataStore = true;

        public static void Initialize()
        {
            if (UseMockDataStore)
            {
                ServiceLocator.Instance.Register<IDataStore<ReminderList>, MockReminderListDataStore>();
                ServiceLocator.Instance.Register<IDataStore<Reminder>, MockReminderDataStore>();
            }
            else
            {
                ServiceLocator.Instance.Register<IDataStore<ReminderList>, ReminderListDataStore>();
                ServiceLocator.Instance.Register<IDataStore<Reminder>, ReminderDataStore>();
            }
        }
    }
}
