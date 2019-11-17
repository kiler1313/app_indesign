using InDesingEntity.CC;
using System;
using System.Collections.Generic;
using System.Text;

namespace InDesignDTO.CC
{
    public class CreateClientContactDto
    {
        public Client client { get; set; }

        public List<Contact> listContact { get; set; }
    }

    public class AssignClientContactDto
    {
        public Client_Contact clientContact { get; set; }
    }
}
