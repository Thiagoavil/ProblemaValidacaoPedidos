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
            //Inicia a lista zerada
            ListaPedidos = new List<Pedidos>();
            Id = Guid.NewGuid();
        }

        public void ProcessarValorDosPedidos()
        {
            double valorTotal= 0;

            foreach(Pedidos pedido in ListaPedidos)
            {
                valorTotal =+ pedido.Valor;
            }

            this.ValorTotalPedidos = valorTotal;
        }
        public Guid Id { get; set; }    
        public string Nome { get; set; }
        public List<Pedidos> ListaPedidos { get; set; }
        public double ValorTotalPedidos { get; set; }
        public bool Premium { get; set; }
        public int Distância { get; set; }
    }
}

