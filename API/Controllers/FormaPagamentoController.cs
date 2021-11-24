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

        //GET: api/produto/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.FormaPagamento
            .Include(p => p.Tipo)
            .ToList());


        //DELETE: /api/produto/delete/bolacha
       /* [HttpDelete]
        [Route("delete/{tipo}")]
        public IActionResult Delete([FromRoute] string tipo)
        {
            //Expressão lambda
            //Buscar um objeto na tabela de produtos com base no nome
            FormaPagamento FormaPagamento = _context.FormaPagamento.FirstOrDefault(formapagamento => formapagamento.Tipo == tipo);

            if (FormaPagamento == null)
            {
                return NotFound();
            }
            _context.formaspagamento.Remove(formapagamento);
            _context.SaveChanges();
            return Ok(_context.formaspagamento.ToList());
        }

        */
    }
}