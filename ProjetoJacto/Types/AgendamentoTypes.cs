using Microsoft.VisualBasic;

namespace ProjetoJacto.Types
{
    public class AgendamentoTypes
    {
        internal int codigo { get; set; }
        public int idusuario { get; set; }
        public string? cliente { get; set; }
        internal DateTime? datacadastro { get; set; }
        public DateTime? datainicio { get; set; }
        public DateTime? datafinal { get; set; }
        public string? cep { get; set; }
        public string? endereco { get; set; }
        public string? numero { get; set; }
        public string? bairro { get; set; }
        public string? cidade { get; set; }
        public string? uf { get; set; }
        public string? complemento { get; set; }
        public string? detalhes { get; set; }
        public string? finalizado { get; set; }
        public DateTime? datafinalizacao { get; set; }
    }
}