using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoJacto.Dal;
using ProjetoJacto.Types;
using ProjetoJacto.Utilitarios;
using System.Net;
using System.Security.Policy;
using System.Text.Json.Nodes;

namespace TesteJacto.Controllers
{
    public class AgendamentoController : Controller
    {

        [HttpGet("/Agendamento/RetornaAgendamentos")]
        public object RetornaAgendamentos(string hash,int codigousuario)
        {
            if (!Utilitarios.ValidaHash(hash)) { return "Autenticação falhou!"; }
            if (codigousuario == 0) { return "Existem Parametros Nulos!"; }
            Dictionary<int, AgendamentoTypes> list = new Dictionary<int, AgendamentoTypes>();
            list = AgendamentoDal.RetornaAgendamentos(codigousuario);
            if (list.Count > 0) { return list; } else { return "Não existem agendamentos para este usuario!"; }
        }

        [HttpPost("/Agendamento/CriarAgendamento")]
        public object CriarAgendamentos(string hash,AgendamentoTypes agendamento)
        {
            if (!Utilitarios.ValidaHash(hash)) { return "Autenticação falhou!"; }
            if (!Utilitarios.VerificaValorNulo(agendamento)) { return "Existem Parametros Nulos!"; }
            if(agendamento.datafinal <= agendamento.datainicio) { return "Data final não pode ser igual ou menor que a data incial!"; }
            if(agendamento.datainicio < DateTime.Now) { return "Data Inicial não pode ser menor que a data atual!"; }

            string url = "https://viacep.com.br/ws/"+ agendamento.cep +"/json/";                      
            HttpClient client = new HttpClient();
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            {
                using (HttpContent content = response.Content)                {
                 
                    var retorno = JsonObject.Parse(content.ReadAsStringAsync().Result);
                    agendamento.endereco = ((string?)retorno["logradouro"]);
                    agendamento.cidade = ((string?)retorno["localidade"]);
                    agendamento.bairro = ((string?)retorno["bairro"]);
                    agendamento.uf = ((string?)retorno["uf"]);                  

                }
            }

            if (AgendamentoDal.CriarAgendamento(agendamento))
            {
                return "Agendamento Criado com Sucesso!";
            }
            else
            {
                return "Nao foi possivel criar agendamento!";
            }

        }

        [HttpPut("/Agendamento/AtualizaAgendamento")]
        public object AtualizaAgendamento(string hash,int codigoagendamento,AgendamentoTypes agendamento)
        {
            if (!Utilitarios.ValidaHash(hash)) { return "Autenticação falhou!"; }
            if (!Utilitarios.VerificaValorNulo(codigoagendamento)) { return "Parametro Nulo!"; }

            if (AgendamentoDal.AtualizaAgendamento(agendamento, codigoagendamento)) { 
                return "Agendamento Atualizado com Sucesso"; 
            }else { 
                return "Nao foi possivel atualizar agendamento!"; 
            }

        }

        [HttpDelete("/Agendamento/ExcluirAgendamento")]
        public object ExcluirAgendamento(string hash, int codigoagendamento)
        {
            if (!Utilitarios.ValidaHash(hash)) { return "Autenticação falhou!"; }
            if (!Utilitarios.VerificaValorNulo(codigoagendamento)) { return "Parametro Nulo!"; }
            if (AgendamentoDal.ExcluirAgendamento(codigoagendamento)) {
                return "Agendamento Excluido com Sucesso!";
            }else{
                return "Não foi possivel excluir agendamento!";
            }

           
        }
        [HttpPost("/Agendamento/FinalizaAgendamento")]
        public object FinalizaAgendamento(string hash,int codigoagendamento, DateTime Datafinalizacao,string obsadicional)
        {
            if (!Utilitarios.ValidaHash(hash)) { return "Autenticação falhou!"; }
            Dictionary<int, AgendamentoTypes> list = new Dictionary<int, AgendamentoTypes>();
            list = AgendamentoDal.RetornaAgendamentos(codigoagendamento, true);
            if(Datafinalizacao > list[0].datafinal) { return "Data de finalizacao nao pode ser maior que a data final agendada!"; }
            list[0].datafinalizacao = DateTime.Now;
            list[0].finalizado = "S";
            list[0].detalhes += " Obs.Final:" + obsadicional;
            if (AgendamentoDal.AtualizaAgendamento(list[0], codigoagendamento))
            {
                return "Agendamento Finalizado com Sucesso";
            }else{
                return "Nao foi possivel finalizar agendamento!";
            }
            
        }
    }
}
