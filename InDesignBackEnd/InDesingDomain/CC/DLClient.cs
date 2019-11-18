using InDesignDTO.CC;
using InDesignInterface.CC;
using InDesignRepository.CC;
using InDesingEntity.CC;
using System;
using System.Collections.Generic;
using System.Text;

namespace InDesignDomain.CC
{
    public class DLClient 
    {
        public string Create(ClientDto clientDto)
        {
            string response = "";
            if (clientDto.client != null)
            {
                bool isCreate = new ClientRepository().Create(clientDto);
                if (isCreate)
                {
                    response = "El cliente fue creado exitosamente";
                }
                else
                {
                    response = "No se pudo realizar el registro del cliente. Posiblemente existe u ocurrio una excepciòn";
                }
            }
            else
            {
                response = "La solicitud de creaciòn del cliente no esta diligenciada";
            }
            return response;
        }

        public List<ClientDto> GetAll(ClientDto clientDto)
        {
            List<ClientDto> listClientDto = new List<ClientDto>();
            listClientDto = new ClientRepository().GetAll(clientDto);
            return listClientDto;
        }

        public ClientDto GetById(ClientDto clientDto)
        {
            ClientDto clientDtoResponse = new ClientDto();
            clientDtoResponse = new ClientRepository().GetById(clientDto);
            return clientDtoResponse;
        }

        public string Update(ClientDto clientDto)
        {
            string response = "";
            if (clientDto.client != null)
            {
                bool isUpdate = new ClientRepository().Update(clientDto);
                if (isUpdate)
                {
                    response = "El cliente fue actualizado exitosamente";
                }
                else
                {
                    response = "No se pudo realizar la actualizaciòn del cliente. Posiblemente no existe u ocurrio una excepciòn";
                }
            }
            else
            {
                response = "La solicitud de actualizaciòn del cliente no esta diligenciada";
            }
            return response;
        }
    }
}
