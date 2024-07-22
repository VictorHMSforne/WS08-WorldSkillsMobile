using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Models;
using WS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageListar : ContentPage
	{
		public PageListar ()
		{
			string dbPath = "";
			InitializeComponent ();
			ServiceDbConsultorio consultorio = new ServiceDbConsultorio(dbPath);
			lsvHistorico.ItemsSource = consultorio.Listar();
		}
        private void lsvHistorico_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
			Medico medico = new Medico();
			Navigation.PushAsync(new PageCadastrar(medico));
        }
    }
}