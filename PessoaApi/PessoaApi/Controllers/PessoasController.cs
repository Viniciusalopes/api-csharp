using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PessoaApi.Models;
using PessoaApi.CustomJsonResult;
using Microsoft.AspNetCore.Authorization;

namespace PessoaApi.Controllers
{
    // [Authorize]
    // Comentado porque não consegui implementar a autorização
    [Route("api/Pessoas")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly PessoaContext _context;

        public PessoasController(PessoaContext context)
        {
            _context = context;
        }

        #region CRUD

        #region CREATE

        // POST: api/Pessoas/create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("create")]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                if (CpfExists(pessoa.Cpf, pessoa.Id))
                {
                    return ConflictJsonResult.JsonDuplicatedCpf(pessoa.Cpf);
                }

                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion CREATE

        #region READ

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            return await _context.Pessoas.ToListAsync();
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(long id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // GET: api/Pessoas/uf/SP
        [HttpGet("uf/{uf}")]
        public IEnumerable<Pessoa> GetPessoasUf(string uf)
        {
            IEnumerable<Pessoa> pessoas = _context.Pessoas
                .Where(p => string.Equals(p.Uf, uf, StringComparison.OrdinalIgnoreCase));

            return pessoas;
        }

        #endregion READ

        #region UPDATE

        // PUT: api/Pessoas/update/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutPessoa(long id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {

                if (CpfExists(pessoa.Cpf, pessoa.Id))
                {
                    return ConflictJsonResult.JsonDuplicatedCpf(pessoa.Cpf);
                }

                _context.Entry(pessoa).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion UPDATE

        #region DELETE

        // DELETE: api/Pessoas/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Pessoa>> DeletePessoa(long id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            //return pessoa;
            return SuccessJsonResult.JsonExcluded(pessoa);
        }

        #endregion DELETE

        #endregion CRUD

        #region VALIDATE

        private bool PessoaExists(long id)
        {
            return _context.Pessoas.Any(p => p.Id == id);
        }

        private bool CpfExists(string cpf, long id)
        {
            return _context.Pessoas.Any(p => p.Cpf == cpf && p.Id != id);
        }

        #endregion VALIDATE
    }
}
