using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_CONSULTARCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_CONSULTARCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo) ;

            if (end.cep ==null || end == null) return null;

            return end;
        }
    }
}
