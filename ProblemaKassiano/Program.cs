using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaKassiano
{

    public class Program
    {
        public static void Main(string[] args)
        {
            new Program();
        }

        List<Cliente> clientes = new List<Cliente>();
        List<Pedidos> pedidos = new List<Pedidos>();
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
                        Adiciona10ClientesAleatorios();
                        break;
                    case 6:
                        AdicionarPedidosAleatoriosNosClientesExistentes();
                        break;
                    case 7:
                        Console.WriteLine("Saindo do programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Por favor, selecione uma opção válida.");
                        break;
                }
            }
        }

        private void Adiciona10ClientesAleatorios()
        {
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                clientes.Add(new Cliente() { Distância = rand.Next(10000), Nome = gerarNomeAleatorio(), Premium = rand.Next(2) == 1 });
            }
        }

        private void AdicionarCliente()
        {
            //Fazer regra para adicionar clientes especificos
        }

        private void AdicionarPedidosAleatoriosNosClientesExistentes()
        {
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                var pedido = new Pedidos() { Data = gerarDataAleatoria(), Item = gerarNomeAleatorio(), PedidoProcessado = rand.Next(2) == 1, Valor = rand.Next(10000)};

                //Adiciona esse pedido em um cliente aleatório da lista
                clientes[rand.Next(clientes.Count - 1)].ListaPedidos.Add(pedido);
            }
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
            Console.WriteLine("5 - Adicionar 10 Clientes Aleatorios");
            Console.WriteLine("6 - Adicionar pedidos aleatorios nos clientes existentes");
            Console.WriteLine("7 - Sair");
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
        private string gerarNomeAleatorio()
        {
            string randomName = Path.GetRandomFileName();
            return randomName.Replace(".", "");
        }

        //gera uma data aleatória dentro do ano atual
        private DateTime gerarDataAleatoria()
        {
            Random random = new Random();
            int ano = DateTime.Now.Year;
            DateTime dataInicial = new DateTime(ano, 1, 1);
            DateTime dataFinal = new DateTime(ano + 1, 1, 1).AddDays(-1);
            int range = (dataFinal - dataInicial).Days;

            return dataInicial.AddDays(random.Next(range + 1));
        }
    }
}
