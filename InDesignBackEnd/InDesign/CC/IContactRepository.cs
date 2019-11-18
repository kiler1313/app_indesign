using InDesignDTO.CC;
using InDesingEntity.CC;
using System.Collections.Generic;

namespace InDesignInterface.CC
{
    public interface IContactRepository
    {
        List<ContactDto> GetAll(ContactDto contactDto);
        ContactDto GetById(ContactDto contactDto);
        bool Create(ContactDto contactDto);
        bool Update(ContactDto contactDto);
    }
}
