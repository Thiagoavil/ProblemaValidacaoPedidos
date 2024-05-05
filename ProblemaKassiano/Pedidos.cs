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
            Id = Guid.NewGuid();  
            PedidoProcessado = false;
            Prioridade = 0;
        }
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string Item { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public bool PedidoProcessado { get; set; }
        public int Prioridade { get; set; }
    }
}
