using InDesingEntity.CC;
using System.Collections.Generic;

namespace InDesignInterface.CC
{
    public interface IContactRepository
    {
        List<Contact> GetAll(Contact contact);
        Contact GetById(Contact contact);
        bool Create(Contact contact);
        bool Update(Contact contact);
    }
}
