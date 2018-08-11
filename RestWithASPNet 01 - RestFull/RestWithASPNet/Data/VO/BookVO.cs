using System;
using System.Runtime.Serialization;

namespace RestWithASPNet.Data.VO
{
    [DataContract]
    public class BookVO 
    {
        [DataMember (Order =1, Name ="Identificador")]
        public long? Id { get; set; }

        [DataMember(Order = 2, Name = "Autor")]
        public string Author { get; set; }

        [DataMember(Order = 3, Name = "Data")]
        public DateTime LaunchDate { get; set; }

        [DataMember(Order = 4, Name = "Preço")]
        public decimal Price { get; set; }

        [DataMember(Order = 5, Name = "Titulo")]
        public string Title { get; set; }
    }
}
