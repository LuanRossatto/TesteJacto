using NSwag.Annotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ProjetoJacto.Types
{
    public class UsuarioTypes
    {
        [OpenApiIgnore]
        internal int codigo { get; set; }
        public string? nome { get; set; }
        public string? senha { get; set; }
        public string? email { get; set; }
        public string? celular { get; set; }
    }

}
