using InDesignDTO.CC;
using InDesignInterface.CC;
using InDesignRepository.CC;
using InDesingEntity.CC;
using System;
using System.Collections.Generic;
using System.Text;

namespace InDesignDomain.CC
{
    public class DLContact
    {
        public string Create(ContactDto contactDto)
        {
            string response = "";
            if (contactDto.contact != null)
            {
                bool isCreate = new ContactRepository().Create(contactDto);
                if (isCreate)
                {
                    response = "El contacto fue creado exitosamente";
                }
                else
                {
                    response = "No se pudo realizar el registro del contacto. Posiblemente existe u ocurrio una excepciòn";
                }
            }
            else
            {
                response = "La solicitud de creaciòn del contacto no esta diligenciada";
            }
            return response;
        }

        public List<ContactDto> GetAll(ContactDto contactDto)
        {
            List<ContactDto> listContactDto = new List<ContactDto>();
            listContactDto = new ContactRepository().GetAll(contactDto);
            return listContactDto;
        }

        public ContactDto GetById(ContactDto contactDto)
        {
            ContactDto contactDtoResponse = new ContactDto();
            contactDtoResponse = new ContactRepository().GetById(contactDto);
            return contactDtoResponse;
        }

        public string Update(ContactDto contactDto)
        {
            string response = "";
            if (contactDto.contact != null)
            {
                bool isUpdate = new ContactRepository().Update(contactDto);
                if (isUpdate)
                {
                    response = "El contacto fue creado exitosamente";
                }
                else
                {
                    response = "No se pudo realizar el registro del contacto. Posiblemente existe u ocurrio una excepciòn";
                }
            }
            else
            {
                response = "La solicitud de creaciòn del contacto no esta diligenciada";
            }
            return response;
        }
    }
}
