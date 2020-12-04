using System;

using UIKit;

namespace Assessment.iOS.ViewControllers
{
    public partial class ReminderListsViewController : UIViewController
    {
        public ReminderListsViewController() : base("ReminderListsViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

