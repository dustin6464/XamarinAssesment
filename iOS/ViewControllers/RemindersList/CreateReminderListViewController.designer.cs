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
	[Register ("CreateReminderListViewController")]
	partial class CreateReminderListViewController
	{
		[Outlet]
		UIKit.UIButton btnCancel { get; set; }

		[Outlet]
		UIKit.UIButton btnSaveUser { get; set; }

		[Outlet]
		UIKit.UIButton btnSelectColor { get; set; }

		[Outlet]
		UIKit.UILabel lblColorLabel { get; set; }

		[Outlet]
		UIKit.UITextField txtTitle { get; set; }

		[Outlet]
		UIKit.UIView viewColorDisplay { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}

			if (btnSaveUser != null) {
				btnSaveUser.Dispose ();
				btnSaveUser = null;
			}

			if (btnSelectColor != null) {
				btnSelectColor.Dispose ();
				btnSelectColor = null;
			}

			if (lblColorLabel != null) {
				lblColorLabel.Dispose ();
				lblColorLabel = null;
			}

			if (txtTitle != null) {
				txtTitle.Dispose ();
				txtTitle = null;
			}

			if (viewColorDisplay != null) {
				viewColorDisplay.Dispose ();
				viewColorDisplay = null;
			}
		}
	}
}
