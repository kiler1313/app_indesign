using InDesignDTO.CC;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InDesignREST.Controllers
{
    [Route("api/ClientContact")]
    [ApiController]
    public class ClientContactController : ControllerBase
    {

        [Route("Create")]
        [HttpPost]
        public void Create(CreateClientContactDto createClientContactDto)
        {
        }

        [Route("Assign")]
        [HttpPost]
        public void Assign(AssignClientContactDto assignClientContactDto)
        {
        }
    }
}
