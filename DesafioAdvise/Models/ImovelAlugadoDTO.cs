namespace Imobiliaria.Api.Models
{
    public class ImovelAlugadoDTO
    {
        public int ImovelId { get; set; }
        public string Endereco { get; set; }
        public string ProprietarioNome { get; set; }
        public string CorretorNome { get; set; }
        public string InquilinoNome { get; set; }
    }
}
