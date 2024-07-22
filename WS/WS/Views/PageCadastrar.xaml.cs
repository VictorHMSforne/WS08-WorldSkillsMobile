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
	public partial class PageCadastrar : ContentPage
	{
		public PageCadastrar ()
		{
			InitializeComponent ();
		}
        public PageCadastrar(Medico medico)
        {
            InitializeComponent();
			
			
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
			Medico medico = new Medico();
			medico.Nome = txtNome.Text;
			medico.HorarioEntrada = txtHoraEntra.Text;
			medico.HorarioSaida = txtHoraSai.Text;
			ServiceDbConsultorio consultorio = new ServiceDbConsultorio(App.DbPath);
			try
			{
				if (txtNome.Text == null || txtHoraEntra.Text == null || txtHoraSai.Text == null)
				{
                    DisplayAlert("Preencha os Campos", "Campos Vazios!", "OK");
                }
				else
				{
                    consultorio.Inserir(medico);
                    DisplayAlert("Inserção concluída", "Médico inserido com Sucesso!", "OK");
                    Navigation.PushAsync(new PageListar());
                }			
			}
			catch (Exception er)
			{
				DisplayAlert("Erro", er.Message,"OK");
			}

        }
    }
}