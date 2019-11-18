using InDesignDTO.CC;
using InDesignInterface.CC;
using InDesignModel;
using InDesignRepository.UT;
using InDesingEntity.CC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InDesignRepository.CC
{
    public class ContactRepository : IContactRepository
    {
        public bool Create(ContactDto contactDto)
        {
            bool isCreate = false;
            if (contactDto != null)
            {
                using (InDesignContext context = new InDesignContext())
                {
                    context.Contact.Add(contactDto.contact);
                    int save = context.SaveChanges();
                    if (save > 0)
                    {
                        isCreate = true;
                    }
                    else
                    {
                        isCreate = false;
                    }
                }
            }
            return isCreate;
        }

        public List<ContactDto> GetAll(ContactDto contactDto)
        {
            List<ContactDto> listContactDto = new List<ContactDto>();
            List<Contact> listContact = new List<Contact>();

            try
            {
                if (contactDto != null)
                {
                    var predicateBuilder = this.setPredicate(contactDto.contact);
                    using (InDesignContext context = new InDesignContext())
                    {
                        listContact = context.Contact.AsNoTracking().
                                                                     Where(predicateBuilder).
                                                                     OrderBy(m => m.Id)
                                                                     .ToList();
                    }
                }
                else
                {
                    using (InDesignContext context = new InDesignContext())
                    {
                        listContact = context.Contact.AsNoTracking().
                                                                      OrderBy(m => m.Id)
                                                                      .ToList();
                    }
                }
                listContact.ForEach(contactItem =>
                {
                    ContactDto contactDtoItemAdd = new ContactDto();
                    contactDtoItemAdd.contact = contactItem;
                    listContactDto.Add(contactDtoItemAdd);
                });
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return listContactDto;
        }

        public ContactDto GetById(ContactDto contactDto)
        {
            ContactDto clientContactResponse = new ContactDto();
            try
            {
                if (contactDto != null)
                {
                    var predicateBuilder = this.setPredicate(contactDto.contact);
                    using (InDesignContext context = new InDesignContext())
                    {
                        clientContactResponse.contact = context.Contact.AsNoTracking().
                                                                     Where(predicateBuilder).
                                                                     OrderBy(m => m.Id)
                                                                     .FirstOrDefault();
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return clientContactResponse;
        }

        public bool Update(ContactDto contactDto)
        {
            bool isUpdate = false;
            if (contactDto != null)
            {
                using (InDesignContext context = new InDesignContext())
                {
                    context.Contact.Update(contactDto.contact);
                    int save = context.SaveChanges();
                    if (save > 0)
                    {
                        isUpdate = true;
                    }
                    else
                    {
                        isUpdate = false;
                    }
                }
            }
            return isUpdate;
        }

        private Expression<Func<Contact, bool>> setPredicate(Contact contact)
        {
            var predicateBuilder = PredicateBuilder.True<Contact>();
            if (contact.Id != 0)
            {
                predicateBuilder = predicateBuilder.And(m => m.Id == contact.Id);
            }
            if (!string.IsNullOrWhiteSpace(contact.Name))
            {
                predicateBuilder = predicateBuilder.And(m => m.Name == contact.Name);
            }
            if (!string.IsNullOrWhiteSpace(contact.Address))
            {
                predicateBuilder = predicateBuilder.And(m => m.Address == contact.Address);
            }
            if (!string.IsNullOrWhiteSpace(contact.NumberPhone))
            {
                predicateBuilder = predicateBuilder.And(m => m.NumberPhone == contact.NumberPhone);
            }
            return predicateBuilder;
        }
    }
}
