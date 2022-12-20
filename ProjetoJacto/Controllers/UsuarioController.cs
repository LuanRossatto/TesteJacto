using Microsoft.AspNetCore.Mvc;
using ProjetoJacto.Types;
using ProjetoJacto.Dal;
using ProjetoJacto.Utilitarios;
using static System.Net.WebRequestMethods;

namespace Testejacto.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpPost("/Usuario/ValidaUsuario")]
        public object ValidaUsuario(string hash,int codigo = 0, string senha = "")
        {
            if (!Utilitarios.ValidaHash(hash)) { return "Autenticação falhou!"; }
            if (codigo == 0 || senha.Length == 0){ return "Alguns dos Parametros estão Nulos!";}
            UsuarioTypes usuario = new UsuarioTypes();
            usuario = UsuarioDal.ValidaUsuario(codigo, senha);
            if(usuario.codigo > 0) { return usuario;} else { return "Usuario Não Encontrado"; }

        }
        [HttpGet("/Usuario/RetornaUsuarios")]
        public object RetornaUsuarios(string hash)
        {
            if (!Utilitarios.ValidaHash(hash)) { return "Autenticação falhou!"; }
            List<UsuarioTypes> list = new List<UsuarioTypes>();
            list = UsuarioDal.RetornaUsuarios();
            if(list.Count > 0) {return list;}else{ return "Não existe nenhum usuario cadastrado!";}
        }

        [HttpPost("/Usuario/CriarUsuario")]
        public object CriarUsuario(string hash,UsuarioTypes usuario)
        {
            if (!Utilitarios.ValidaHash(hash)) { return "Autenticação falhou!"; }
            if (!Utilitarios.VerificaValorNulo(usuario)) { return "Existem Parametros Nulos!"; }
            return "Codigo:" + UsuarioDal.CriarUsuario(usuario);
        }

        [HttpDelete("/Usuario/DeletarUsuario")]
        public object DeletarUsuario(string hash,int codigo)
        {
            if (!Utilitarios.ValidaHash(hash)) { return "Autenticação falhou!"; }
            if (!Utilitarios.VerificaValorNulo(codigo)) { return "Parametro Nulo!"; }
            if(UsuarioDal.DeletarUsuario(codigo)) { return "Usuario excluido com sucesso!"; } else { return "Nao foi possivel excluir usuario!"; }
        }
    }
}


