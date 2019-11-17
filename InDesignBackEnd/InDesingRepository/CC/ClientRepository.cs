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
    public class ClientRepository : IClientRepository
    {
        public bool Create(Client client)
        {
            bool isCreate = false;
            if (client != null)
            {
                using (InDesignContext context = new InDesignContext())
                {
                    context.Client.Add(client);
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

        public List<Client> GetAll(Client client)
        {
            List<Client> listClient = new List<Client>();
            try
            {
                if (client != null)
                {
                    var predicateBuilder = this.setPredicate(client);
                    using (InDesignContext context = new InDesignContext())
                    {
                        listClient = context.Client.AsNoTracking().
                                                                     Where(predicateBuilder).
                                                                     OrderBy(m => m.Id)
                                                                     .ToList();
                    }
                }
                else
                {
                    using (InDesignContext context = new InDesignContext())
                    {
                        listClient = context.Client.AsNoTracking().
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

        public Client GetById(Client client)
        {
            Client clientContactResponse = new Client();
            try
            {
                if (client != null)
                {
                    var predicateBuilder = this.setPredicate(client);
                    using (InDesignContext context = new InDesignContext())
                    {
                        clientContactResponse = context.Client.AsNoTracking().
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

        public bool Update(Client client)
        {
            bool isUpdate = false;
            if (client != null)
            {
                using (InDesignContext context = new InDesignContext())
                {
                    context.Client.Update(client);
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

        private Expression<Func<Client, bool>> setPredicate(Client client)
        {
            var predicateBuilder = PredicateBuilder.True<Client>();
            if (client.Id != 0)
            {
                predicateBuilder = predicateBuilder.And(m => m.Id == client.Id);
            }
            if (!string.IsNullOrWhiteSpace(client.Name))
            {
                predicateBuilder = predicateBuilder.And(m => m.Name == client.Name);
            }
            if (!string.IsNullOrWhiteSpace(client.Address))
            {
                predicateBuilder = predicateBuilder.And(m => m.Address == client.Address);
            }
            if (!string.IsNullOrWhiteSpace(client.NumberPhone))
            {
                predicateBuilder = predicateBuilder.And(m => m.NumberPhone == client.NumberPhone);
            }
            if (client.CreationDate != null)
            {
                predicateBuilder = predicateBuilder.And(m => m.CreationDate == client.CreationDate);
            }
            return predicateBuilder;
        }
    }
}
