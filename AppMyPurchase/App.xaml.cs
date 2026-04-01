using AppMyPurchase.Service;
using AppMyPurchase.Views;
using SQLite;

namespace AppMyPurchase
{
    public partial class App : Application
    {
        private readonly SQLiteAsyncConnection _connect;

        private static ProductService _database;

        public static ProductService Database
        {
            get
            {
                if (_database == null)
                {
                    string path = Path
                        .Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "_dbMyPurchase_Local.db3");
                    _database = new ProductService(path);
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