using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estoqueMVC2.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataValidade { get; set; }

        //um para um com relatorio
        public Relatorio Relatorio { get; set; }
        public int? RelatorioId { get; set; }

        //um para muitos com itemEstoque
        public List<ItemEstoque> ItensEstoque { get; set; } = new List<ItemEstoque>();

    }
}