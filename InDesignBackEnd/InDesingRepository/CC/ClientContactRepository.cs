using InDesignInterface.CC;
using Microsoft.EntityFrameworkCore;
using InDesignModel;
using InDesignRepository.UT;
using InDesingEntity.CC;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace InDesignRepository.CC
{
    public class ClientContactRepository : IClientContactRepository
    {
        public bool Create(Client_Contact clientContact)
        {
            bool isCreate = false;
            if (clientContact != null)
            {
                using (InDesignContext context = new InDesignContext())
                {
                    context.Client_Contact.Add(clientContact);
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

        public List<Client_Contact> GetAll(Client_Contact clientContact)
        {
            List<Client_Contact> listClientContact = new List<Client_Contact>();
            try
            {
                if (clientContact != null)
                {
                    var predicateBuilder = this.setPredicate(clientContact);
                    using (InDesignContext context = new InDesignContext())
                    {
                        listClientContact =     context.Client_Contact.AsNoTracking().
                                                                     Where(predicateBuilder).
                                                                     OrderBy(m => m.IdClient)
                                                                     .ToList();
                    }
                }
                else
                {
                    using (InDesignContext context = new InDesignContext())
                    {
                        listClientContact = context.Client_Contact.AsNoTracking().
                                                                      OrderBy(m => m.IdClient)
                                                                      .ToList();
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return listClientContact;
        }

        public Client_Contact GetById(Client_Contact clientContact)
        {
            Client_Contact clientContactResponse = new Client_Contact();
            try
            {
                if (clientContact != null)
                {
                    var predicateBuilder = this.setPredicate(clientContact);
                    using (InDesignContext context = new InDesignContext())
                    {
                        clientContactResponse = context.Client_Contact.AsNoTracking().
                                                                     Where(predicateBuilder).
                                                                     OrderBy(m => m.IdClient)
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

        public bool Update(Client_Contact clientContact)
        {
            bool isUpdate = false;
            if (clientContact != null)
            {
                using (InDesignContext context = new InDesignContext())
                {
                    context.Client_Contact.Update(clientContact);
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

        private Expression<Func<Client_Contact, bool>> setPredicate(Client_Contact clientContact)
        {
            var predicateBuilder = PredicateBuilder.True<Client_Contact>();
            if (clientContact.IdClient != 0)
            {
                predicateBuilder = predicateBuilder.And(m => m.IdClient == clientContact.IdClient);
            }
            if (clientContact.IdContact != 0)
            {
                predicateBuilder = predicateBuilder.And(m => m.IdContact == clientContact.IdContact);
            }
            return predicateBuilder;
        }
    }
}
