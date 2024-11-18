using ApiSistemaStreaming.Dto.Vinculo;

namespace ApiSistemaStreaming.Dto.Conteudo
{
    public class ConteudoCriacaoDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public CriadorVinculoDto Criador { get; set; }
    }
}
