using InDesingEntity.CC;
using System.Collections.Generic;

namespace InDesignInterface.CC
{
    public interface IClientRepository
    {
        List<Client> GetAll(Client client);
        Client GetById(Client client);
        bool Create(Client client);
        bool Update(Client client);
    }
}
