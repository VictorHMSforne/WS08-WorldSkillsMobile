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
    public partial class PageListaMisto : ContentPage
    {
        public PageListaMisto()
        {
            InitializeComponent();
            ServiceDbConsultorio consultorio = new ServiceDbConsultorio(App.DbPath);
            TimeSpan HrEntraManha = new TimeSpan(6, 0, 0);
            TimeSpan HrSaiManha = new TimeSpan(11, 59, 0);

            TimeSpan HrEntraTarde = new TimeSpan(12, 0, 0);
            TimeSpan HrSaiTarde = new TimeSpan(17, 59, 0);

            TimeSpan HrEntraNoite = new TimeSpan(18, 0, 0);
            TimeSpan HrSaiNoite = new TimeSpan(5, 59, 0);

            var turnosMist = consultorio.Listar().Where(m =>
                !((m.HorarioEntrada >= HrEntraManha && m.HorarioSaida <= HrSaiManha) ||
                  (m.HorarioEntrada >= HrEntraTarde && m.HorarioSaida <= HrSaiTarde) ||
                  (m.HorarioEntrada >= HrEntraNoite && m.HorarioSaida <= HrSaiNoite))
            );

            lsvHistoricoMisto.ItemsSource = turnosMist;


        }

        private void lsvHistoricoMisto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Medico selectedMedico = e.SelectedItem as Medico;
                lsvHistoricoMisto.SelectedItem = null;
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