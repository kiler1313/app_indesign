using InDesignDTO.CC;
using InDesingEntity.CC;
using System.Collections.Generic;

namespace InDesignInterface.CC
{
    public interface IClientRepository
    {
        List<ClientDto> GetAll(ClientDto clientDto);
        ClientDto GetById(ClientDto clientDto);
        bool Create(ClientDto clientDto);
        bool Update(ClientDto clientDto);
    }
}
