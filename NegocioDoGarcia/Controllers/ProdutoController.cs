using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegocioDoGarcia.Model;

namespace NegocioDoGarcia.Controllers
{
    public class ProdutoController : Controller
    {
        private GarciaContext _garciaContext;
        public ProdutoController(DbContext context)
        {
            _garciaContext = (GarciaContext)context;
        }

        [HttpGet("GetProduto")]
        public IActionResult GetProduto()
        {
            var produtos = _garciaContext.Produto.Where(a => a.Id > 0).ToList();

            return Ok(produtos);
        }

        [HttpPost("CriarProduto")]
        public IActionResult PostProduto([FromBody] Produto produto)
        {
            _garciaContext.Add(produto);
            _garciaContext.SaveChanges();

            return Ok(produto);
        }

        [HttpPut("EditarProduto")]
        public IActionResult EditarProduto([FromBody] Produto produto)
        {
            var checkProdutoExistente = _garciaContext.Produto.FirstOrDefault(a => a.Id == produto.Id);

            if (checkProdutoExistente == null)
            {
                return BadRequest("Produto inexistente.");
            }

            if (checkProdutoExistente.Preco != produto.Preco && produto.Preco > 0)
                checkProdutoExistente.Preco = produto.Preco;

            if (checkProdutoExistente.Descricao != produto.Descricao && produto.Descricao != string.Empty)
                checkProdutoExistente.Descricao = produto.Descricao;

            if (checkProdutoExistente.NomeProduto != produto.NomeProduto && produto.NomeProduto != string.Empty)
                checkProdutoExistente.NomeProduto = produto.NomeProduto;

            _garciaContext.Update(checkProdutoExistente);
            _garciaContext.SaveChanges();
            return Ok(checkProdutoExistente);
        }

        [HttpDelete("DeletarProduto")]
        public IActionResult DeletarProduto([FromBody] Produto produto)
        {
            var checkProdutoExistente = _garciaContext.Produto.FirstOrDefault(a => a.Id == produto.Id);

            if (checkProdutoExistente == null)
                return BadRequest("Produto inexistente.");

            _garciaContext.Remove(checkProdutoExistente);
            _garciaContext.SaveChanges();

            return Ok("Produto deletado.");
        }

        [HttpPost("TestePost")]
        public IActionResult Testezao([FromBody] string teste, [FromBody] int teste2, [FromBody] string teste3, [FromBody] string test4)
        {
            return Ok();
        }
    }
}
