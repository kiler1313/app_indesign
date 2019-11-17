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
        public bool Create(Contact contact)
        {
            bool isCreate = false;
            if (contact != null)
            {
                using (InDesignContext context = new InDesignContext())
                {
                    context.Contact.Add(contact);
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

        public List<Contact> GetAll(Contact contact)
        {
            List<Contact> listClient = new List<Contact>();
            try
            {
                if (contact != null)
                {
                    var predicateBuilder = this.setPredicate(contact);
                    using (InDesignContext context = new InDesignContext())
                    {
                        listClient = context.Contact.AsNoTracking().
                                                                     Where(predicateBuilder).
                                                                     OrderBy(m => m.Id)
                                                                     .ToList();
                    }
                }
                else
                {
                    using (InDesignContext context = new InDesignContext())
                    {
                        listClient = context.Contact.AsNoTracking().
                                                                      OrderBy(m => m.Id)
                                                                      .ToList();
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return listClient;
        }

        public Contact GetById(Contact contact)
        {
            Contact clientContactResponse = new Contact();
            try
            {
                if (contact != null)
                {
                    var predicateBuilder = this.setPredicate(contact);
                    using (InDesignContext context = new InDesignContext())
                    {
                        clientContactResponse = context.Contact.AsNoTracking().
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

        public bool Update(Contact contact)
        {
            bool isUpdate = false;
            if (contact != null)
            {
                using (InDesignContext context = new InDesignContext())
                {
                    context.Contact.Update(contact);
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
