using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estoqueMVC2.Models
{
    public class Relatorio
    {
        public int RelatorioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public int Quantidade { get; set; }

        //Entrada ou Saida
        public string Tipo { get; set; }
        //um relatorio pode ter varios itens de estoque
        public List<ItemEstoque> ItensEstoque { get; set; } = new List<ItemEstoque>();
        //um relatorio pode ter varios produtos
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        //um relatorio só pode ter um estoque
        public Estoque Estoque { get; set; }
        public int EstoqueId { get; set; }

    }
}