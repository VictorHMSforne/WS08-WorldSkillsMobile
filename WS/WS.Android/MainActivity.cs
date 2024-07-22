using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace WS.Droid
{
    [Activity(Label = "WS", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            string dbName = "dbConsultorio.db3"; // dando o nome ao banco
            string dbPath = FileAccessHelper.GetFolderPath(dbName);// atribuindo a essa variável a Classe com o Método de definição do caminho do banco
            LoadApplication(new App(dbPath, dbName));// Executando o App com parâmetros do banco
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}