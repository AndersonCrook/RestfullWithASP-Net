using System.ComponentModel.DataAnnotations.Schema;
using RestWithASPNet.Model.Base;

namespace RestWithASPNet.Model
{
    [Table ("persons")]
    public class PersonModel : BaseEntity
    {
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        [Column("Gender")]
        public string Gender { get; set; }
    }
}
