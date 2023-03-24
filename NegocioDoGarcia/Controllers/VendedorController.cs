using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegocioDoGarcia.Model;

namespace NegocioDoGarcia.Controllers
{
    public class VendedorController : Controller
    {
        private GarciaContext _garciaContext;
        public VendedorController(DbContext context)
        {
            _garciaContext = (GarciaContext)context;
        }

        //READ
        [HttpGet("GetVendedor")]
        public IActionResult GetVendedor()
        {
            var vendedores = _garciaContext.Vendedor.Where(a => a.Id > 0).ToList();

            return Ok(vendedores);
        }

        //CREATE
        [HttpPost("CreateVendedor")]
        public IActionResult CreateVendedor([FromBody] Vendedor vendedor)
        {
            _garciaContext.Vendedor.Add(vendedor);
            _garciaContext.SaveChanges();

            return Ok(vendedor);
        }

        //UPDATE
        [HttpPut("EditVendedor")]
        public IActionResult EditVendedor([FromBody] Vendedor vendedor)
        {
            var vendedorDb = _garciaContext.Vendedor.FirstOrDefault(a => a.Id == vendedor.Id);

            if (vendedorDb == null)
            {
                return BadRequest("Vendedor especificado não existe.");
            }

            if (vendedorDb.NomeVendedor != vendedor.NomeVendedor && vendedor.NomeVendedor != string.Empty)
                vendedorDb.NomeVendedor = vendedor.NomeVendedor;

            if (vendedorDb.Email != vendedor.Email && vendedor.Email != string.Empty)
                vendedorDb.Email = vendedor.Email;

            if (vendedorDb.Telefone != vendedor.Telefone && vendedor.Telefone != string.Empty)
                vendedorDb.Telefone = vendedor.Telefone;

            _garciaContext.Update(vendedorDb);
            _garciaContext.SaveChanges();

            return Ok(vendedorDb);
        }

        //DELETE
        [HttpDelete("DeleteVendedor")]
        public IActionResult DeleteVendedor([FromBody] Vendedor vendedor)
        {
            var vendedorDb = _garciaContext.Vendedor.FirstOrDefault(a => a.Id == vendedor.Id);

            if (vendedorDb == null)
            {
                return BadRequest("Vendedor especificado não existe.");
            }

            _garciaContext.Vendedor.Remove(vendedorDb);
            _garciaContext.SaveChanges();
            return Ok($"{vendedorDb.NomeVendedor} excluído.");
        }
    }
}
