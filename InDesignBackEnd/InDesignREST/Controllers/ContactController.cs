using InDesignApplication.CC;
using InDesignDTO.CC;
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
        public string Create(ContactDto contactDto)
        {
            return new SFContact().Create(contactDto);
        }

        [Route("Update")]
        [HttpPost]
        public string Update(ContactDto contactDto)
        {
            return new SFContact().Update(contactDto);
        }

        [Route("GetAll")]
        [HttpPost]
        public List<ContactDto> GetAll(ContactDto contactDto)
        {
            return new SFContact().GetAll(contactDto);
        }

        [Route("GetById")]
        [HttpPost]
        public ContactDto GetById(ContactDto contactDto)
        {
            return new SFContact().GetById(contactDto);
        }

    }
}
