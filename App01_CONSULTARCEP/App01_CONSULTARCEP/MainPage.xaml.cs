using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_CONSULTARCEP.Servico.Modelo;
using App01_CONSULTARCEP.Servico;

namespace App01_CONSULTARCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;


        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TO-DO Lógica

            //TO-DO Validações


            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {

                Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                try { 

                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0},{3},{1},{2}", end.logradouro, end.localidade, end.uf, end.bairro);
                    }

                    else
                    {
                        DisplayAlert("ERRO","Não foi encontrado um CEP válido para o endereço digitado"+ end.cep,"OK");
                    }
                    }
                catch (Exception e)
                {
                    DisplayAlert("Erro Critico", e.Message, "OK");
                }
                }
        }
            public bool isValidCEP(string cep)
            {
                bool valido = true;

                if (cep.Length != 8)
                {
                    DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres", "OK");

                    valido = false;
                }
                int NovoCEP = 0;
                if (!int.TryParse(cep, out NovoCEP))
                {
                    DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas de numeros", "OK");

                    valido = false;
                }


                return true;
            }
        }
    
}
