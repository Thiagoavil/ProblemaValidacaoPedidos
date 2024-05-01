using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaKassiano
{

    public class Program
    {
        List<Cliente> clientes = new List<Cliente>();

        public Program()
        {
            Rodar();
        }
        public void Rodar()
        {
            int opcao;

            while (true)//Loop Infinito
            {
                opcao = RespostaTela();

                // Aqui você pode adicionar a lógica para lidar com cada opção selecionada
                switch (opcao)
                {
                    case 1:
                        AdicionarCliente();
                        break;
                    case 2:
                        AdicionarPedido();
                        break;
                    case 3:
                        ProcessarPedidos();
                        break;
                    case 4:
                        ListarPedidosPorCliente();
                        break;
                    case 5:
                        Console.WriteLine("Saindo do programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Por favor, selecione uma opção válida.");
                        break;
                }

            }
        }

        private void AdicionarCliente()
        {
            //Fazer regra para adicionar clientes
        }

        private void AdicionarPedido()
        {
            //Fazer regra para adicionar pedidos
        }

        private void ProcessarPedidos()
        {
            //Fazer regra para processar pedidos
        }

        private void ListarPedidosPorCliente()
        {
            //Fazer regra para listar pedidos dos clientes
        }

        //Chama o método sempre que quiser mostrar a tela de menu
        public int RespostaTela()
        {
            int opcao;

            Console.Clear(); // Limpa a tela antes de exibir o menu

            // Exibindo o menu
            Console.WriteLine("=====================================");
            Console.WriteLine("            Menu Principal            ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1 - Adicionar Cliente");
            Console.WriteLine("2 - Adicionar Pedido");
            Console.WriteLine("3 - Processar Pedidos");
            Console.WriteLine("4 - Listar Pedidos Por Cliente");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("=====================================");
            Console.Write("Por favor, selecione uma opção: ");

            // Solicitando a escolha do usuário e tentando converter para int
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Entrada inválida! Por favor, insira um número correspondente à opção desejada.");
                opcao = RespostaTela(); // Chama recursivamente o método para obter uma entrada válida
            }

            return opcao;


        }
    }

}
