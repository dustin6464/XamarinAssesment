// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Threading.Tasks;
using Assessment.iOS.Utils;
using Assessment.Models;
using Foundation;
using UIKit;

namespace Assessment.iOS
{
	public partial class ReminderDetailViewController : UIViewController
	{
        public ReminderListViewModel ViewModel;
        public Reminder Reminder;
		public ReminderDetailViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            StyleUI();
            BindUI();
        }

        void StyleUI()
        {
            txtviewDetails.ClipsToBounds = true;
            txtviewDetails.Layer.BorderWidth = 1;
            txtviewDetails.Layer.BorderColor = UIColor.LightGray.CGColor;
            txtviewDetails.Layer.CornerRadius = 5;
        }

        void BindUI()
        {
            DatePicker.Hidden = !DateSwitch.On;
            DateSwitch.On = Reminder.DueDate == null ? false : true;
            DatePicker.Hidden = !DateSwitch.On;
            DatePicker.Date = DateTimeUtils.DateTimeToNSDate(Reminder.DueDate) ?? DateTimeUtils.DateTimeToNSDate(DateTime.Now);
            txtTitle.Text = Reminder.Title;
            txtviewDetails.Text = Reminder.Deails;
            SetCompletedButtonImage();
        }

        partial void DateSwitchValueChange(NSObject sender)
        {
            DatePicker.Hidden = !DateSwitch.On;
        }

        partial void CompleteReminderButtonPress(NSObject sender)
        {
            Reminder.Completed = !Reminder.Completed;
            SetCompletedButtonImage();
        }

        partial void SaveButtonPress(NSObject sender)
        {
            Reminder.Title = txtTitle.Text;
            Reminder.Deails = txtviewDetails.Text;
            DateTime? date = null;
            if (DateSwitch.On)
            {
                date = (DateTime)DatePicker.Date;
            }
            Reminder.DueDate = date;
            ViewModel.UpdateReminderCommand.Execute(Reminder);
            this.NavigationController.PopViewController(true);
        }

        void SetCompletedButtonImage()
        {
            btnCompleted.SetImage(Reminder.Completed ? UIImage.GetSystemImage("checkmark.circle.fill") : UIImage.GetSystemImage("circle"), UIControlState.Normal);
        }
    }
}
