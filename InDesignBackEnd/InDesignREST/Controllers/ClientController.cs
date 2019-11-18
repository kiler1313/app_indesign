using InDesignApplication.CC;
using InDesignDTO.CC;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InDesignREST.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public string Create(ClientDto clientDto)
        {
            return new SFClient().Create(clientDto);
        }

        [Route("Update")]
        [HttpPost]
        public string Update(ClientDto clientDto)
        {
            return new SFClient().Update(clientDto);
        }

        [Route("GetAll")]
        [HttpPost]
        public List<ClientDto> GetAll(ClientDto clientDto)
        {
            return new SFClient().GetAll(clientDto);
        }

        [Route("GetById")]
        [HttpPost]
        public ClientDto GetById(ClientDto clientDto)
        {
            return new SFClient().GetById(clientDto);
        }

    }
}
