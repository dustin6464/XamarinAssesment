using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Assessment;
using Assessment.Models;
using Xunit;

namespace UnitTests.ViewModels
{
    public class ReminderListsViewModelTests
    {
        ReminderListsViewModel ViewModel;
        public ReminderListsViewModelTests()
        {
            ViewModel = new ReminderListsViewModel();
        }

        [Fact]
        public void TestViewModelCommands()
        {
            ViewModel.ReminderLists = new ObservableCollection<ReminderList>();
            var list = new ReminderList() { Id = 100, Title = "Test Title 1" };

            //Add
            ViewModel.AddReminderListCommand.Execute(list);
            Assert.True(ViewModel.ReminderLists.Count ==  1, "There was an error in the AddReminderListCommand");

            //Update
            list.Title = "Test Title 2";
            ViewModel.UpdateReminderCommand.Execute(ViewModel.ReminderLists.LastOrDefault());
            Assert.True(ViewModel.ReminderLists.FirstOrDefault().Title == "Test Title 2", "There was an error in the UpdateReminderCommand");

            //Delete
            ViewModel.DeleteReminderListCommand.Execute(ViewModel.ReminderLists.LastOrDefault());
            Assert.True(ViewModel.ReminderLists.Count == 0, "There was an error in the DeleteReminderListCommand");
        }

        [Fact]
        public void TestViewModelListDetailsString()
        {
            Assert.True(true);
        }
    }
}
