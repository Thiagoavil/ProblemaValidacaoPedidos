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
        List<Cliente> UltimosClientesAtendidos = new List<Cliente>();
        public Program()
        {
            AdicionarClientesIniciais();
            AdicionarPedidosAleatoriosNosClientesExistentes();
            Rodar();
        }
        public void Rodar()
        {
            int opcao;

            while (true)//Loop Infinito
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
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
                        Console.WriteLine("Pressione enter para continuar");
                        Console.ReadKey();
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
            Console.WriteLine("Digite o nome do Cliente: ");
            var nome = Console.ReadLine();

            bool premium = opcaoPremium();

            Console.WriteLine("Digite a distancia do Cliente: ");
            int distancia = int.Parse(Console.ReadLine());

            clientes.Add(new Cliente()
            {
                Nome = nome,
                Premium = premium,
                Distância = distancia
            });

        }
        private bool opcaoPremium()
        {
            Console.WriteLine($"Digite 1 para Cliente{Console.ForegroundColor = ConsoleColor.Yellow}Premium");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Digite 2 para Cliente{Console.ForegroundColor = ConsoleColor.Green} Normal");
            Console.ForegroundColor = ConsoleColor.White;
            // Solicitando a escolha do usuário e tentando converter para int
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                return true;
            }

            return false;
        }
        private void AdicionarPedidosAleatoriosNosClientesExistentes()
        {
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                var pedido = new Pedidos() { Data = gerarDataAleatoria(), Item = gerarNomeAleatorio(), PedidoProcessado = rand.Next(2) == 1, Valor = rand.Next(10000) };

                //Adiciona esse pedido em um cliente aleatório da lista
                var index = rand.Next(clientes.Count - 1);
                clientes[index].ListaPedidos.Add(pedido);
                pedido.ClienteId = clientes[index].Id;
            }
        }
        private void AdicionarClientesIniciais()
        {
            clientes.Add(new Cliente()
            {
                Nome = GerarNomeExistenteAleatorio(),
                Premium = true,
                Distância = 130
            });

            clientes.Add(new Cliente()
            {
                Nome = GerarNomeExistenteAleatorio(),
                Premium = false,
                Distância = 160
            });

            clientes.Add(new Cliente()
            {
                Nome = GerarNomeExistenteAleatorio(),
                Premium = false,
                Distância = 200
            });

            clientes.Add(new Cliente()
            {
                Nome = GerarNomeExistenteAleatorio(),
                Premium = true,
                Distância = 190
            });
        }

        private void AdicionarPedido()
        {
            //Verificação para ver se existem clientes criados
            if (clientes.Count > 0)
            {
                int cont = 0;
                Console.WriteLine("Selecione o Cliente:");
                foreach (Cliente cliente in clientes)
                {
                    Console.WriteLine($"{cont} - {cliente.Nome}");
                    cont++;
                }
                var opcao = int.Parse(Console.ReadLine());

                var clienteSelecionado = clientes[opcao];

                Console.WriteLine("Digite o nome do pedido");
                var nome = Console.ReadLine();

                Console.WriteLine("Digite o valor do pedido");
                int valor = int.Parse(Console.ReadLine());

                clienteSelecionado.ListaPedidos.Add(new Pedidos()
                {
                    Item = nome,
                    Valor = valor,
                    Data = DateTime.Now,
                    ClienteId = clienteSelecionado.Id
                });

                clienteSelecionado.ProcessarValorDosPedidos();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=====================================");
                Console.WriteLine("       Nenhum Cliente Cadastrado     ");
                Console.WriteLine("=====================================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pressione Enter para Continuar");
                Console.Read();
            }
        }

        private void ProcessarPedidos()
        {
            //Fazer regra para processar pedidos
            pedidos.Clear();
            List<Pedidos> todosOsPedidos = SelecionarTodosOsPedidos();

            //ordena pela data
            todosOsPedidos = todosOsPedidos.OrderByDescending(p => p.Data).ToList();

            Pedidos[] pedidosParaProcessar = new Pedidos[5];

            todosOsPedidos.CopyTo(0, pedidosParaProcessar, 0, 5);

            UltimoCliente(pedidosParaProcessar);

            if (ultimosClientesPremium())
            {
                PrioridadeNormal(pedidosParaProcessar);
            }
            else
                PrioridadePremium(pedidosParaProcessar);



        }
        private void PrioridadeNormal(Pedidos[] pedidos)
        {
            foreach (Pedidos pedido in pedidos)
            {
                Cliente clienteSelecionado = clientes.FirstOrDefault(x => x.Id == pedido.ClienteId);
                if (clienteSelecionado.Premium)
                {

                }
                else
                    pedido.Prioridade++;
            }
        }
        private void PrioridadePremium(Pedidos[] pedidos)
        {
            foreach (Pedidos pedido in pedidos)
            {
                Cliente clienteSelecionado = clientes.FirstOrDefault(x => x.Id == pedido.ClienteId);
                if (clienteSelecionado.Premium)
                {
                    pedido.Prioridade++;
                }
            }
        }
        private bool ultimosClientesPremium()
        {
            int clientesPremium = 0; 
            foreach(Cliente cliente in UltimosClientesAtendidos)
            {
                if(cliente.Premium)
                {
                    clientesPremium++;
                }
            }

            if(clientesPremium ==5)
            {
                return true;
            }
            else
                return false; 
        }
        private void UltimoCliente(Pedidos[] pedidos)
        {
            foreach (Pedidos pedido in pedidos)
            {
                if (pedido.ClienteId != UltimosClientesAtendidos.LastOrDefault().Id)
                {
                    pedido.Prioridade++;
                }
            }
        }
        public List<Pedidos> SelecionarTodosOsPedidos()
        {
            List<Pedidos> pedidos = new List<Pedidos>();
            foreach (Cliente cliente in clientes)
            {
                foreach (Pedidos pedido in cliente.ListaPedidos)
                {
                    if (pedido.PedidoProcessado)
                    {

                    }
                    else
                    {
                        pedidos.Add(pedido);
                    }
                }
            }
            return pedidos;
        }

        private void ListarPedidosPorCliente()
        {
            if (clientes.Count > 0)
            {
                int contadorClientes = 0;
                foreach (Cliente cliente in clientes)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Cliente: {contadorClientes} - {cliente.Nome}");
                    Console.ForegroundColor = ConsoleColor.White;
                    int contadorPedidos = 0;
                    List<Pedidos> pedidosPorData = cliente.ListaPedidos.OrderBy(p => p.Data).ToList();
                    foreach (Pedidos pedido in pedidosPorData)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{contadorPedidos} Nome: {pedido.Item}");
                        Console.WriteLine($"---- {pedido.PedidoProcessado}");
                        Console.WriteLine($"---- {pedido.Data}");
                        Console.ForegroundColor = ConsoleColor.White;
                        contadorPedidos++;
                    }
                    contadorClientes++;
                }

            }
            else
            {
                Console.WriteLine("Nenhum Cliente Cadastrado");
            }

            Console.WriteLine();
            Console.WriteLine("Digite enter para continuar");
            Console.ReadLine();
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
            Console.WriteLine("3 - Processar 5 Pedidos");
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
                Console.WriteLine("Pressione enter para continuar");
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

        private string GerarNomeExistenteAleatorio()
        {
            Random rand = new Random();
            string[] nomes = { "João", "Maria", "Pedro", "Ana", "Lucas", "Julia", "Marcos", "Carla", "Fernanda", "Rafael", "Mariana", "Luiza" }; // Adicione mais nomes conforme necessário
            string[] sobrenomes = { "Silva", "Santos", "Oliveira", "Souza", "Pereira", "Ferreira", "Almeida", "Costa", "Araujo", "Ribeiro", "Carvalho" }; // Adicione mais sobrenomes conforme necessário

            string nome = nomes[rand.Next(nomes.Length)];
            string sobrenome = sobrenomes[rand.Next(sobrenomes.Length)];

            return nome + " " + sobrenome;
        }
    }
}
