using InDesignDTO.CC;
using InDesignDomain.CC;
using InDesignInterface.CC;
using InDesingEntity.CC;
using System;
using System.Collections.Generic;
using System.Text;

namespace InDesignApplication.CC
{
    public class SFContact 
    {
        public string Create(ContactDto contactDto)
        {
            return new DLContact().Create(contactDto);
        }

        public List<ContactDto> GetAll(ContactDto contactDto)
        {
            return new DLContact().GetAll(contactDto);
        }

        public ContactDto GetById(ContactDto contactDto)
        {
            return new DLContact().GetById(contactDto);
        }

        public string Update(ContactDto contactDto)
        {
            return new DLContact().Update(contactDto);
        }
    }
}
