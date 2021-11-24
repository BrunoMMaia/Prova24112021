using System;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/formapagamento")]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly DataContext _context;
        public FormaPagamentoController(DataContext context)
        {
            _context = context;
        }

        //POST: api/formapagamento/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] FormaPagamento FormaPagamento)
        {
            _context.FormaPagamento.Add(FormaPagamento);
            _context.SaveChanges();
            return Created("", FormaPagamento);
        }

        //GET: api/FormaPagamento/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.FormaPagamento
            .ToList());


        //DELETE: /api/delete/delete/tipo
        [HttpDelete]
        [Route("delete/{tipo}")]
        public IActionResult Delete([FromRoute] string tipo)
        {
            FormaPagamento FormaPagamento = _context.FormaPagamento.FirstOrDefault(FormaPagamento => FormaPagamento.Tipo == tipo);

            if (FormaPagamento == null)
            {
                return NotFound();
            }
            _context.FormaPagamento.Remove(FormaPagamento);
            _context.SaveChanges();
            return Ok(_context.FormaPagamento.ToList());
        }

    }
}