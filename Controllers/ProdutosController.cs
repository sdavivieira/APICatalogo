using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutosRepository _produtosRepositorio;

        public ProdutosController(ProdutosRepository produtosRepositorio)
        {
            _produtosRepositorio = produtosRepositorio;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                var Produto = _produtosRepositorio.Get();
                return Ok(Produto);

            }
            catch
            {
                return BadRequest("Produtos não encontrados");
            }

        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var Produto = _produtosRepositorio.GetById(id);
                return Ok(Produto);
            }
            catch
            {
                return BadRequest("Produto não encontrado");
            }
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            try
            {
                var Produto = _produtosRepositorio.AddProduto(produto);
                return Ok(Produto);
            }
            catch
            {
                return BadRequest("Produto não adicionado");
            }

        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            try
            {
                var Produto = _produtosRepositorio.PutProdutoById(id, produto);
                return Ok(Produto);
            }
            catch (Exception e)
            {
                return BadRequest("API não pode executar essa operação");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Produto> Delete(int id)
        {
            try
            {
                 _produtosRepositorio.DeleteProduto(id);
            }
            catch (Exception e)
            {
                return BadRequest("O produto não pode ser excluído");
            }
            return Ok();
        }
    }
}
