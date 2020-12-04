using System.Windows.Input;

namespace Assessment
{
    public class AboutViewModel : BaseViewModel
    {
        public string TitleLabel;
        public string Details;

        public AboutViewModel()
        {
            Title = "About";
            TitleLabel = "Assessment";
            Details = "Notes about the app: \n  1. There is a local data store and mock data store that are injected based off UseMockDataStore flag in App.cs. The local data store writes to SQLite db where as the mock service is just keeping in ram (not presistent)\n  2. The unit tests are not as many as there could be, this was more of a proof of knowledge.\n\n\nAbout the Dev:\nI have multiple years of Xamarin experience from just maintaining/bug fixing to architecting solutions. I am more profficient in iOS but can handle Android as well. This has been a fun little project and I am glad I got to sling some quick code. Below is a link to my LinkedIn for more bio info.";
            OpenWebCommand = new Command(() => Plugin.Share.CrossShare.Current.OpenBrowser("https://www.linkedin.com/in/dustin-williams-6131b457/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
