using InDesingEntity.CC;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InDesignREST.Controllers
{
    [Route("api/Contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        [Route("Create")]
        [HttpPost]
        public void Create(Contact contact)
        {
        }

        [Route("Update")]
        [HttpPost]
        public void Update(Contact contact)
        {
        }

        [Route("GetAll")]
        [HttpPost]
        public void GetAll(Contact contact)
        {
        }

        [Route("GetById")]
        [HttpPost]
        public void GetById(Contact contact)
        {
        }

    }
}
