namespace SistemaBancario.Models
{
    public class Usuario
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public bool PrimeiraTrocaRealizada { get; set; }

        public Usuario(string nome, string senha, bool primeiraTroca)
        {
            NomeUsuario = nome;
            Senha = senha;
            PrimeiraTrocaRealizada = primeiraTroca;
        }
    }
}
