using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegocioDoGarcia.Model;

namespace NegocioDoGarcia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private GarciaContext _garciaContext;

        public ClienteController(DbContext context)
        {
            _garciaContext = (GarciaContext)context;
        }

        [HttpGet("GetCliente")]
        public IActionResult GetCliente()
        {
            var clientes = _garciaContext.Cliente.Where(a => a.Id > 0).ToList();

            return Ok(clientes);
        }

        [HttpPost("CreateCliente")]
        public IActionResult PostCliente([FromBody] Cliente cliente)
        {
            _garciaContext.Cliente.Add(cliente);
            _garciaContext.SaveChanges();

            return Ok(cliente);
        }

        [HttpPut("EditCliente")]
        public IActionResult EditCliente([FromBody] Cliente cliente)
        {
            var checkClienteExistente = _garciaContext.Cliente.FirstOrDefault(a => a.Id == cliente.Id);

            if (checkClienteExistente == null)
                return BadRequest("Cliente não existe.");

            if (checkClienteExistente.NomeCliente != cliente.NomeCliente && cliente.NomeCliente != string.Empty)
            {
                checkClienteExistente.NomeCliente = cliente.NomeCliente;
            }

            if (checkClienteExistente.Email != cliente.Email && cliente.Email != string.Empty)
            {
                checkClienteExistente.Email = cliente.Email;
            }

            if (checkClienteExistente.Telefone != cliente.Telefone && cliente.Telefone != string.Empty)
            {
                checkClienteExistente.Telefone = cliente.Telefone;
            }

            _garciaContext.Update(checkClienteExistente);
            _garciaContext.SaveChanges();

            return Ok(checkClienteExistente);
        }

        [HttpDelete("DeletarCliente")]
        public IActionResult DeleteCliente([FromBody] Cliente cliente)
        {
            var checkClienteExistente = _garciaContext.Cliente.FirstOrDefault(a => a.Id == cliente.Id);

            if (checkClienteExistente == null)
                return BadRequest("Cliente não Existente.");

            _garciaContext.Remove(checkClienteExistente);
            _garciaContext.SaveChanges();

            return Ok("Cliente excluído");
        }
    }
}