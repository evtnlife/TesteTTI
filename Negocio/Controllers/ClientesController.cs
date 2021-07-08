using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteTTI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ClienteDAO> Get()
        {
            try
            {
                ClienteDAC dac = new ClienteDAC();
                return dac.GetAll().ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
