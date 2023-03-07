using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estoqueMVC2.Models
{
    public class ProdutoItemEstoqueViewModel
    {
        //lista de produtos
        public List<Produto> Produtos { get; set; }
        //lista de itens de estoque
        public List<ItemEstoque> ItensEstoque { get; set; }

        //lista de relatorios
        public List<Relatorio> Relatorios { get; set; }
    }
}