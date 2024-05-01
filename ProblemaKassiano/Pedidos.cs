using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaKassiano
{
    public class Pedidos
    {
        public Pedidos()
        {

        }
        public string Item { get; set; }
        public string Valor { get; set; }
        public DateTime Data { get; set; }
        public bool PedidoProcessado { get; set; }
        public int Prioridade { get; set; }
    }
}
