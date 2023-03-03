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
        //categoria só pode ser: Alimento, Bebida, Limpeza, Higiene

        public List<ItemEstoque> ItensEstoque { get; set; } = new List<ItemEstoque>();

    }
}