namespace ApiSistemaStreaming.Models
{
    public class ResponseModel<T>
    {
        //T? significa que o dado pode ser nulo, exemplo quando não encontrar nada dentro do banco, quando der um erro etc 
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
