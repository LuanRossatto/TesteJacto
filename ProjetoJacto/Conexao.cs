using System.Data;
using MySql.Data.MySqlClient;
 
namespace ProjetoJacto.Conexao
{
    public class ConexaoDados
    {
        public static MySqlCommand ConexaoMysql()
        {
           MySqlCommand Conn = new MySqlCommand();           
            Conn.Connection = new MySqlConnection($"server=localhost;uid=Admin;pwd=Qu1m3rr4_@;database=projetojacto;");
           if(Conn.Connection.State!= ConnectionState.Open)
            {
                Conn.Connection.Open();
            }
           return Conn;
        }
    }
}
