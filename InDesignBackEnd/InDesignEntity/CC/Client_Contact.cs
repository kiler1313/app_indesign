using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InDesingEntity.CC
{
    [Table("Client_Contact")]
    public class Client_Contact
    {
        public int IdClient { get; set; }

        public int IdContact { get; set; }
    }
}
