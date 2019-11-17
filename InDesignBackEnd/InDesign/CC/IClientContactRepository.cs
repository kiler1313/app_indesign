using InDesingEntity.CC;
using System;
using System.Collections.Generic;
using System.Text;

namespace InDesignInterface.CC
{
    public interface IClientContactRepository
    {
        List<Client_Contact> GetAll(Client_Contact clientContact);
        Client_Contact GetById(Client_Contact clientContact);
        bool Create(Client_Contact clientContact);
        bool Update(Client_Contact clientContact);
    }
}
