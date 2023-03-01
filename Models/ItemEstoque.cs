using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estoqueMVC2.Models
{
    public class ItemEstoque
    {
        public int ItemEstoqueId { get; set; }
        public int Quantidade { get; set; }
        //relacionamento muitos para 1
        public int ProdutoId { get; set; }     
        public Produto Produto { get; set; }

        //relacionamento muitos para 1
        public int EstoqueId { get; set; }
        public Estoque Estoque { get; set; }



    }
}