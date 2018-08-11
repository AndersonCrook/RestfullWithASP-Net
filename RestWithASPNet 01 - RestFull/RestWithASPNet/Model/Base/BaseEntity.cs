using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RestWithASPNet.Model.Base
{
    //contrato entre atributos
    //ea estrutura da tabela
   // [DataContract]
    public class BaseEntity
    {
        [Column("id")]
        public long? Id { get; set; }

    }
}
