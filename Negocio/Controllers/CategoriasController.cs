using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;

namespace TesteTTI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(ILogger<CategoriasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CategoriaDAO> Get()
        {
            try
            {
                CategoriaDAC dac = new CategoriaDAC();
                return dac.GetAll().ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
