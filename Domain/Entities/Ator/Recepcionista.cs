namespace Domain.Entities.Ator
{
    public class Recepcionista: Usuario
    {
        private string _senha;

        public string Senha { get => null ; set => _senha = value; }


        public string GetSenha() => _senha;
    }
}
