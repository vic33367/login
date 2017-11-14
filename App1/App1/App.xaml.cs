
using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {
        public static ISQLAzure Authenticator { get; private set; }
        public static void Init(ISQLAzure authenticator)
        {
            Authenticator = authenticator;
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new App1.DataPage()){ BarTextColor = Color.FromRgb(253, 254, 254), BarBackgroundColor = Color.FromRgb(91, 44, 111) };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
