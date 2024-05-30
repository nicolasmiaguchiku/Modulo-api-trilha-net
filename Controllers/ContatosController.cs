using Microsoft.AspNetCore.Mvc;
using ModeloApi.Context;
using ModeloApi.Entities;

namespace ModeloApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class ContatosController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatosController(AgendaContext context)
        {
            _context = context;
        }

        // Create add contato
        [HttpPost]
       public IActionResult Create(Contatos contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new {id = contato.Id}, contato);
        }

        // Obter Contato por Id
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);
            if(contato == null)
            {
                return NotFound();
            }
            return Ok(contato); 
        }

        // Obter por nome
        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));

            if(contatos == null)
            {
                return NotFound();
            }

            return Ok(contatos);
        }


        // Atualizar contato por ID
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contatos contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
            {
                return NotFound();
            }

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);

        }

        //Deletar por Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contato = _context.Contatos.Find(id);

            if(contato == null)
            {
                return NotFound();
            }

            _context.Remove(contato);
            _context.SaveChanges();

            return Ok(contato);
        }
    }
}
    