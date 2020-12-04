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
	[Register ("CreateReminderViewController")]
	partial class CreateReminderViewController
	{
		[Outlet]
		UIKit.UIButton btnCancel { get; set; }

		[Outlet]
		UIKit.UIButton btnSave { get; set; }

		[Outlet]
		UIKit.UIDatePicker DatePicker { get; set; }

		[Outlet]
		UIKit.UISwitch swtDateSwitch { get; set; }

		[Outlet]
		UIKit.UITextView txtDetails { get; set; }

		[Outlet]
		UIKit.UITextField txtTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}

			if (btnSave != null) {
				btnSave.Dispose ();
				btnSave = null;
			}

			if (txtTitle != null) {
				txtTitle.Dispose ();
				txtTitle = null;
			}

			if (txtDetails != null) {
				txtDetails.Dispose ();
				txtDetails = null;
			}

			if (swtDateSwitch != null) {
				swtDateSwitch.Dispose ();
				swtDateSwitch = null;
			}

			if (DatePicker != null) {
				DatePicker.Dispose ();
				DatePicker = null;
			}
		}
	}
}
