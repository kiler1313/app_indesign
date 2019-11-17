using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InDesingEntity.CC;
using Microsoft.AspNetCore.Mvc;

namespace InDesignREST.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        [Route("Create")]
        [HttpPost]
        public void Create(Client client)
        {
        }

        [Route("Update")]
        [HttpPost]
        public void Update(Client client)
        {
        }

        [Route("GetAll")]
        [HttpPost]
        public void GetAll(Client client)
        {
        }

        [Route("GetById")]
        [HttpPost]
        public void GetById(Client client)
        {
        }

    }
}
