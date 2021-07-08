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
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(ILogger<ProdutosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ProdutoDAO> Get()
        {
            ProdutoDAC dac = new ProdutoDAC();
            return dac.GetAll().ToArray();
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<ProdutoDAO>> Insert(ProdutoDAO produto)
        {
            try
            {
                ProdutoDAC dac = new ProdutoDAC();
                List<string> errors = new List<string>();
                if (string.IsNullOrEmpty(produto.Name))
                    errors.Add("Nome preenchido está invalido.");
                if (produto.Price <= 0)
                    errors.Add("Preço invalido.");

                if (errors.Count > 0)
                    return Ok(new Negocio.Models.Response(Negocio.Models.Response.Type.Fail, errors));
                else
                {
                    var result = await dac.Insert(produto);
                    return Ok(new Negocio.Models.Response(Negocio.Models.Response.Type.Success, new List<string>() { "Produto inserido com sucesso!" }));
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        [Route("update")]

        public async Task<ActionResult<ProdutoDAO>> Update(ProdutoDAO produto)
        {
            try
            {
                ProdutoDAC dac = new ProdutoDAC();
                var result = await dac.Update(produto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        [Route("delete")]

        public async Task<ActionResult<ProdutoDAO>> Delete(ProdutoDAO produto)
        {
            try
            {
                ProdutoDAC dac = new ProdutoDAC();
                var result = await dac.Delete(produto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
