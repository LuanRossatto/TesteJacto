using ProjetoJacto.Types;
using MySql.Data.MySqlClient;
using ProjetoJacto.Conexao;
using System.Reflection.Metadata.Ecma335;
using System.Data;

namespace ProjetoJacto.Dal
{
    public class AgendamentoDal
    {
        public static Dictionary<int, AgendamentoTypes> RetornaAgendamentos(int codigo,bool semfiltrousuario=false)
        {
            Dictionary<int, AgendamentoTypes> list = new Dictionary<int, AgendamentoTypes>();           
            MySqlCommand cmd = ConexaoDados.ConexaoMysql();
            cmd.CommandText = "select * from agendamentos where ";
            if (semfiltrousuario)
            {
                cmd.CommandText += "codigo=@codigo";
            }
            else
            {
                cmd.CommandText += "idusuario=@codigo";
            }
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@codigo", MySqlDbType.Int64).Value = codigo;
            using(var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    AgendamentoTypes agendamento= new AgendamentoTypes();                    
                    agendamento.codigo = (int)dr["codigo"];
                    agendamento.idusuario = (int)dr["idusuario"];
                    agendamento.cliente = dr?["cliente"] as string;
                    agendamento.datacadastro = (DateTime)dr["datacadastro"];
                    agendamento.datainicio = (DateTime)dr["datainicio"];
                    agendamento.datafinal = (DateTime)dr["datafinal"];
                    agendamento.detalhes = dr?["detalhes"] as string;
                    agendamento.finalizado = dr?["finalizado"] as string;
                    agendamento.datafinalizacao = (dr.IsDBNull("datafinalizacao")) ? null: (DateTime)dr["datafinalizacao"];
                    agendamento.cep = dr?["cep"] as string;
                    agendamento.endereco = dr?["endereco"] as string;
                    agendamento.numero = dr?["numero"] as string;
                    agendamento.bairro = dr?["bairro"] as string;
                    agendamento.cidade = dr?["cidade"] as string;
                    agendamento.uf = dr?["uf"] as string;
                    agendamento.complemento = dr?["complemento"] as string;                    

                    list.Add(agendamento.codigo,agendamento);
                }
            }
            return list;
        }

        public static bool CriarAgendamento(AgendamentoTypes agendamento)
        {
            MySqlCommand cmd = ConexaoDados.ConexaoMysql();
            cmd.CommandText = "insert into agendamentos (codigo,idusuario,cliente,datacadastro,datainicio,datafinal,cep,endereco," +
                "numero,bairro,cidade,uf,complemento,detalhes) select ifnull(max(codigo),0) + 1,@idusuario,@cliente," +
                "@datacadastro,@datainicio,@datafinal,@cep,@endereco,@numero,@bairro,@cidade,@uf,@complemento,@detalhes from agendamentos";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@idusuario", MySqlDbType.Int64).Value = agendamento.idusuario;
            cmd.Parameters.Add("@cliente", MySqlDbType.VarChar).Value = agendamento.cliente;
            cmd.Parameters.Add("@datacadastro", MySqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@datainicio", MySqlDbType.DateTime).Value = agendamento.datainicio;
            cmd.Parameters.Add("@datafinal", MySqlDbType.DateTime).Value = agendamento.datafinal;
            cmd.Parameters.Add("@detalhes", MySqlDbType.VarChar).Value = agendamento.detalhes;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = agendamento.cep;
            cmd.Parameters.Add("@endereco", MySqlDbType.VarChar).Value = agendamento.endereco;
            cmd.Parameters.Add("@numero", MySqlDbType.VarChar).Value = agendamento.numero;
            cmd.Parameters.Add("@bairro", MySqlDbType.VarChar).Value = agendamento.bairro;
            cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = agendamento.cidade;
            cmd.Parameters.Add("@uf", MySqlDbType.VarChar).Value = agendamento.uf;
            cmd.Parameters.Add("@complemento", MySqlDbType.VarChar).Value = agendamento.complemento;
            
            return (int)cmd.ExecuteNonQuery() > 0;
        }

        public static bool AtualizaAgendamento(AgendamentoTypes agendamento, int codigo)
        {
            MySqlCommand cmd = ConexaoDados.ConexaoMysql();
            cmd.CommandText = "update agendamentos set cliente=@cliente, datainicio=@datainicio, datafinal=@datafinal, cep=@cep," +
                "endereco=@endereco,numero=@numero,bairro=@bairro,cidade=@cidade,uf=@uf,complemento=@complemento,detalhes=@detalhes,finalizado=@finalizado,datafinalizacao=@datafinalizacao where codigo=@codigo";
            cmd.Parameters.Clear();          
            cmd.Parameters.Add("@cliente", MySqlDbType.VarChar).Value = agendamento.cliente;         
            cmd.Parameters.Add("@datainicio", MySqlDbType.DateTime).Value = agendamento.datainicio;
            cmd.Parameters.Add("@datafinal", MySqlDbType.DateTime).Value = agendamento.datafinal;
            cmd.Parameters.Add("@detalhes", MySqlDbType.VarChar).Value = agendamento.detalhes;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = agendamento.cep;
            cmd.Parameters.Add("@endereco", MySqlDbType.VarChar).Value = agendamento.endereco;
            cmd.Parameters.Add("@numero", MySqlDbType.VarChar).Value = agendamento.numero;
            cmd.Parameters.Add("@bairro", MySqlDbType.VarChar).Value = agendamento.bairro;
            cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = agendamento.cidade;
            cmd.Parameters.Add("@uf", MySqlDbType.VarChar).Value = agendamento.uf;
            cmd.Parameters.Add("@complemento", MySqlDbType.VarChar).Value = agendamento.complemento;
            cmd.Parameters.Add("@codigo", MySqlDbType.Int64).Value = codigo;
            cmd.Parameters.Add("@finazalido", MySqlDbType.VarChar).Value = agendamento.finalizado;
            cmd.Parameters.Add("@datafinalizacao", MySqlDbType.DateTime).Value = agendamento.datafinalizacao;
            return (int)cmd.ExecuteNonQuery() > 0;
        }

        public static bool ExcluirAgendamento(int codigo)
        {
            MySqlCommand cmd = ConexaoDados.ConexaoMysql();
            cmd.CommandText = "delete from agendamentos where codigo=@codigo";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@codigo", MySqlDbType.Int64).Value = codigo;
            return (int)cmd.ExecuteNonQuery() > 0;
        }
        
    }
}
