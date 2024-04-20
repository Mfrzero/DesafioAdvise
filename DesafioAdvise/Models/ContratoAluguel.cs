//Essas são as classes de modelos de dados que representam as entidades do domínio da aplicação. Cada modelo normalmente mapeia para uma tabela no banco de dados.
namespace Imobiliaria.Api.Models
{
    public class ContratoAluguel
    {
        public int ContratoAluguelId { get; set; }
        public int InquilinoId { get; set; }
        public Inquilino Inquilino { get; set; }
        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }
        public int CorretorId { get; set; }
        public Corretor Corretor { get; set; }
        public int ProprietarioId { get; set; }
        public Proprietario Proprietario { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
