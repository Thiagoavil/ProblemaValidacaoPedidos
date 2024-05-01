using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaKassiano
{
    public class Cliente
    {
        public Cliente()
        {

        }
        public string Nome { get; set; }
        public List<Pedidos> ListaPedidos { get; set; }
        public int ValorTotalPedidos { get; set; }
        public bool Premium { get; set; }
        public int Distância { get; set; }
    }
}

