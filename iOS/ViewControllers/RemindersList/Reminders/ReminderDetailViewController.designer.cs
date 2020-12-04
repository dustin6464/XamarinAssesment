// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Assessment.iOS
{
	[Register ("ReminderDetailViewController")]
	partial class ReminderDetailViewController
	{
		[Outlet]
		UIKit.UIButton btnCompleted { get; set; }

		[Outlet]
		UIKit.UIDatePicker DatePicker { get; set; }

		[Outlet]
		UIKit.UISwitch DateSwitch { get; set; }

		[Outlet]
		UIKit.UITextField txtTitle { get; set; }

		[Outlet]
		UIKit.UITextView txtviewDetails { get; set; }

		[Action ("CompleteReminderButtonPress:")]
		partial void CompleteReminderButtonPress (Foundation.NSObject sender);

		[Action ("DateSwitchValueChange:")]
		partial void DateSwitchValueChange (Foundation.NSObject sender);

		[Action ("SaveButtonPress:")]
		partial void SaveButtonPress (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCompleted != null) {
				btnCompleted.Dispose ();
				btnCompleted = null;
			}

			if (DatePicker != null) {
				DatePicker.Dispose ();
				DatePicker = null;
			}

			if (DateSwitch != null) {
				DateSwitch.Dispose ();
				DateSwitch = null;
			}

			if (txtTitle != null) {
				txtTitle.Dispose ();
				txtTitle = null;
			}

			if (txtviewDetails != null) {
				txtviewDetails.Dispose ();
				txtviewDetails = null;
			}
		}
	}
}
