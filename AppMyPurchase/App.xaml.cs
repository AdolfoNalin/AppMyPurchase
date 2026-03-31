using AppMyPurchase.FactoryConnection;
using AppMyPurchase.Views;

namespace AppMyPurchase
{
    public partial class App : Application
    {
        private static ConnectSqLiteDatabase _database;
        public static ConnectSqLiteDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    string path = Path
                        .Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "_dbMyPurchase_Local.db3");
                    _database = new ConnectSqLiteDatabase(path);
                }

                return _database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ListProduct());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var windows = base.CreateWindow(activationState);
            windows.Width = 400;
            windows.Height = 600;

            return windows;
        }
    }
}