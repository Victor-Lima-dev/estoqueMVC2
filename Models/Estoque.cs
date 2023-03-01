using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estoqueMVC2.Models
{
    public class Estoque
    {
        public int EstoqueId { get; set; }
       
       //relacionamento 1 para muitos
        public List<ItemEstoque> ItensEstoque { get; set; } = new List<ItemEstoque>();
    }
}