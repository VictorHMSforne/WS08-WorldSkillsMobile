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
		public Medico medico;
		public PageCadastrar ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, true);
            

        }
        public PageCadastrar(Medico medico)
        {
            InitializeComponent();
			btnCadastrar.Text = "Editar";
			btnCadastrar.BackgroundColor = Color.Yellow;
			btnCadastrar.TextColor = Color.Black;
			Title = "Edição de Turno";
            lblId.IsVisible = true;
            txtId.IsVisible = true;
			
			txtId.Text = medico.Id.ToString();
			txtNome.Text = medico.Nome;
			txtHoraEntra.Time = medico.HorarioEntrada;
			txtHoraSai.Time = medico.HorarioSaida;
		}

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
			Medico medico = new Medico();
			medico.Id = Convert.ToInt32(txtId.Text);
			medico.Nome = txtNome.Text;
			medico.HorarioEntrada = txtHoraEntra.Time;
			medico.HorarioSaida = txtHoraSai.Time;
			ServiceDbConsultorio consultorio = new ServiceDbConsultorio(App.DbPath);
			try
			{
				if (txtNome.Text == null || txtHoraEntra.Time == null || txtHoraSai.Time == null)
				{
                    DisplayAlert("Preencha os Campos", "Campos Vazios!", "OK");
                }
				else
				{
                    if (btnCadastrar.Text == "Cadastrar Médico")
                    {
                        consultorio.Inserir(medico);
                        DisplayAlert("Inserção concluída", "Médico inserido com Sucesso!", "OK");
                        Navigation.PushAsync(new PageListar());
                    }
                    else if (btnCadastrar.Text == "Editar")
                    {
                        consultorio.Atualizar(medico);
                        DisplayAlert("Edição!", "Edição realizada com Sucesso!", "Ok");
                        Navigation.PushAsync(new PageListar());
                    }
                }
							
			}
			catch (Exception er)
			{
				DisplayAlert("Erro", er.Message,"OK");
			}

        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
			Navigation.PushAsync(new PagePrincipal());
        }
    }
}