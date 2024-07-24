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
		public PageListar()
		{
			InitializeComponent ();
			ServiceDbConsultorio consultorio = new ServiceDbConsultorio(App.DbPath);

			TimeSpan HrEntraManha = new TimeSpan(6, 0, 0);
            TimeSpan HrSaiManha = new TimeSpan(11, 59, 0);

            TimeSpan HrEntraTarde = new TimeSpan(12, 0, 0);
            TimeSpan HrSaiTarde = new TimeSpan(17, 59, 0);

            TimeSpan HrEntraNoite = new TimeSpan(18, 0, 0);
            TimeSpan HrSaiNoite = new TimeSpan(5, 59, 0);

            lsvHistorico.ItemsSource = consultorio.Listar().Where(f => f.HorarioEntrada >= HrEntraManha && f.HorarioSaida <= HrSaiManha);
            lsvHistoricoTarde.ItemsSource = consultorio.Listar().Where(f => f.HorarioEntrada >= HrEntraTarde && f.HorarioSaida <= HrSaiTarde);
            lsvHistoricoNoite.ItemsSource = consultorio.Listar().Where(f => f.HorarioEntrada >= HrEntraNoite && f.HorarioSaida <= HrSaiNoite);
        }
        private void lsvHistorico_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
          
            if (e.SelectedItem != null)
            {
                Medico selectedMedico = e.SelectedItem as Medico;
                lsvHistorico.SelectedItem = null;
                NavegarMedico(selectedMedico);
            }
        }

        private void lsvHistoricoTarde_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Medico selectedMedico = e.SelectedItem as Medico;
                lsvHistorico.SelectedItem = null;
                NavegarMedico(selectedMedico);
            }
        }

        private void lsvHistoricoNoite_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Medico selectedMedico = e.SelectedItem as Medico;
                lsvHistorico.SelectedItem = null;
                NavegarMedico(selectedMedico);
            }
        }

        void NavegarMedico(Medico medico)
        {
            PageCadastrar cadastrar = new PageCadastrar(medico);
            cadastrar.medico = medico;
            Navigation.PushAsync(cadastrar);
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageCadastrar());
        }
    }
}