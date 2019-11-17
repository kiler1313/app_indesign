using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InDesingEntity.CC
{
    [Table("Client")]
    public class Client
    {
        [Key,Column(Order =0)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string NumberPhone { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
