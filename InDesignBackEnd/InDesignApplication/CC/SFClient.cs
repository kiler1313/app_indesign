using InDesignDomain.CC;
using InDesignDTO.CC;
using InDesignInterface.CC;
using InDesingEntity.CC;
using System;
using System.Collections.Generic;
using System.Text;

namespace InDesignApplication.CC
{
    public class SFClient
    {
        public string Create(ClientDto clientDto)
        {
            return new DLClient().Create(clientDto);
        }

        public List<ClientDto> GetAll(ClientDto clientDto)
        {
            return new DLClient().GetAll(clientDto);
        }

        public ClientDto GetById(ClientDto clientDto)
        {
            return new DLClient().GetById(clientDto);
        }

        public string Update(ClientDto clientDto)
        {
            return new DLClient().Update(clientDto);
        }
    }
}
