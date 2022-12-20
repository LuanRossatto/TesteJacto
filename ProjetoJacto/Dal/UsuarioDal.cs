using ProjetoJacto.Types;
using MySql.Data.MySqlClient;
using ProjetoJacto.Conexao;

namespace ProjetoJacto.Dal
{
   
    public class UsuarioDal
    {
        
        public static UsuarioTypes ValidaUsuario(int codigo, string senha)
        {
            UsuarioTypes usuario = new UsuarioTypes();
            MySqlCommand cmd = ConexaoDados.ConexaoMysql();
            cmd.CommandText = "select * from usuarios where codigo=@codigo and senha=@senha";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@codigo", MySqlDbType.Int64).Value = codigo;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = senha;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {                    
                    usuario.codigo = (int)dr["codigo"];
                    usuario.nome = (string)dr["nome"];
                    usuario.email = (string)dr["email"];
                    usuario.senha = (string)dr["senha"];
                    usuario.celular = (string)dr["celular"];
                }
               
            }
            return usuario;
        }
        public static List<UsuarioTypes> RetornaUsuarios()
        {           
            List<UsuarioTypes> list = new List<UsuarioTypes>();
            MySqlCommand cmd = ConexaoDados.ConexaoMysql();
            cmd.CommandText = "select * from usuarios";
            cmd.Parameters.Clear();    
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    UsuarioTypes usuario = new UsuarioTypes();
                    usuario.codigo = (int)dr["codigo"];
                    usuario.nome = (string)dr["nome"];
                    usuario.email = (string)dr["email"];
                    usuario.senha = (string)dr["senha"];
                    usuario.celular = (string)dr["celular"];
                    list.Add(usuario);
                }

            }
            return list;
        }
        public static int CriarUsuario(UsuarioTypes usuario)
        {
            MySqlCommand cmd = ConexaoDados.ConexaoMysql();
            cmd.CommandText = "Insert into Usuarios (nome,senha,email,celular) values (@nome,@senha,@email,@celular); Select max(codigo) from usuarios ";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = usuario.nome;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = usuario.senha;
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = usuario.email;
            cmd.Parameters.Add("@Celular", MySqlDbType.VarChar).Value = usuario.celular;
            return (int)cmd.ExecuteScalar();           
        }

        public static bool DeletarUsuario(int codigo)
        {
            MySqlCommand cmd = ConexaoDados.ConexaoMysql();
            cmd.CommandText = "Delete from usuarios where codigo=@codigo";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@codigo", MySqlDbType.Int64).Value = codigo;
            return (int)cmd.ExecuteNonQuery() > 0;
        }
    }
}
