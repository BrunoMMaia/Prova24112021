using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Venda
    {
        public Venda() => CriadoEm = DateTime.Now;
        public int VendaId { get; set; }

        public int ItemVendaId { get; set; }
        public string Cliente { get; set; }
        public List<ItemVenda> Itens { get; set; }

        public ItemVenda VendaItem { get; set; }

        public FormaPagamento FormaPagamento { get; set; }

        public int IdFormaPagamento { get; set; }


        public DateTime CriadoEm { get; set; }
    }
}