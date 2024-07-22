using System;
using WS.Views; // adicionei para poder usar as views
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS
{
    public partial class App : Application
    {
        // criado duas variáveis de escopo global, no qual vão ser atribuidas em outro metodo
        public static string DbPath; 
        public static string DbName;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new PagePrincipal());
        }
        public App(string dbPath, string dbName) // Quando o App for novamente executado ele irá abrir usando esses parâmetros
        {
            InitializeComponent();
            App.DbPath = dbPath;
            App.DbName = dbName;
            MainPage = new NavigationPage(new PagePrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
