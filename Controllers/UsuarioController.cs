using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sisconve.Models;
using Sisconve.Persistencia;
using Sisconve.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sisconve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IConfiguration config;
        private readonly IPersistenciaOrden per;
        public UsuarioController(IConfiguration _config, PersistenciaOrden _per)
        {
            this.per = _per;
            config = _config;
        }
        
    }
}
