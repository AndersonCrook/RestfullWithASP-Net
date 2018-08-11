using RestWithASPNet.Model.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNet.Model
{
    [Table("books")]
    public class BookModel : BaseEntity
    {
        [Column("Author")]
        public string Author { get; set; }

        [Column("LaunchDate")]
        public DateTime LaunchDate { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("Title")]
        public string Title { get; set; }
    }
}
