namespace usuarios_api.Modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? ImagemUsuario { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Senha { get; set; }
        public bool IsAtivo { get; set; }
    }
}