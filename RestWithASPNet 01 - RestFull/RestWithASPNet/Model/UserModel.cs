namespace RestWithASPNet.Model
{
    //contrato entre atributos
    //ea estrutura da tabela

    public class UserModel
    {
        
        public long? Id { get; set; }
        public string Login { get; set; }
        public string AccessKey { get; set; }
    }
}
