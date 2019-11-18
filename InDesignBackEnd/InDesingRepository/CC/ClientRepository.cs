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
    public class ClientRepository : IClientRepository
    {
        public bool Create(ClientDto clientDto)
        {
            bool isCreate = false;
            if (clientDto != null)
            {
                using (InDesignContext context = new InDesignContext())
                {
                    context.Client.Add(clientDto.client);
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

        public List<ClientDto> GetAll(ClientDto clientDto)
        {
            List<ClientDto> listClientDto = new List<ClientDto>();
            List<Client> listClient = new List<Client>();
            try
            {
                if (clientDto != null)
                {
                    var predicateBuilder = this.setPredicate(clientDto.client);
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
                listClient.ForEach(clientItem => 
                {
                    ClientDto clientDtoItemAdd = new ClientDto();
                    clientDtoItemAdd.client = clientItem;
                    listClientDto.Add(clientDtoItemAdd);
                });
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return listClientDto;
        }

        public ClientDto GetById(ClientDto clientDto)
        {
            ClientDto clientContactResponse = new ClientDto();
            try
            {
                if (clientDto != null)
                {
                    var predicateBuilder = this.setPredicate(clientDto.client);
                    using (InDesignContext context = new InDesignContext())
                    {
                        clientContactResponse.client = context.Client.AsNoTracking().
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

        public bool Update(ClientDto clientDto)
        {
            bool isUpdate = false;
            if (clientDto != null)
            {
                using (InDesignContext context = new InDesignContext())
                {
                    context.Client.Update(clientDto.client);
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
