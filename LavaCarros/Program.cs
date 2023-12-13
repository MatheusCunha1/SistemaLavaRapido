using System;
using LavaCarros.Data;
using LavaCarros.Repositories;

class Program
{
    static CarroContext context = new CarroContext();
    static CarroRepository carroRepository = new CarroRepository(context);
    static ServicoLavagemRepository servicoLavagemRepository = new ServicoLavagemRepository(context);

    static void Main(string[] args)
    {
        while (true)
        {
            MostrarMenu();

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        AdicionarCarro();
                        break;
                    case 2:
                        MostrarCarros();
                        break;
                    case 3:
                        AdicionarServicoLavagem();
                        break;
                    case 4:
                        MostrarTiposLavagem();
                        break;
                    case 5:
                        LavagemENotaFiscal();
                        break;
                    case 6:
                        EncerrarPrograma();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Por favor, insira um número válido.");
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("|        SISTEMA- CARMENU        |");
        Console.WriteLine("=================================");
        Console.WriteLine("| [1]-Adicionar carros           |");
        Console.WriteLine("| [2]-Consultar carros           |");
        Console.WriteLine("| [3]-Adicionar serviço lavagem  |");
        Console.WriteLine("| [4]-Consultar serviços         |");
        Console.WriteLine("| [5]-Lavar Carro                |");
        Console.WriteLine("| [6]-Encerrar                   |");
        Console.WriteLine("=================================");
    }

    static void AdicionarCarro()
    {
        Console.WriteLine("Insira o nome do dono:");
        string dono = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Insira a placa do carro:");
        string placa = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Insira o modelo do carro:");
        string modelo = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Escolha o tipo de lavagem:");
        MostrarTiposLavagem();
        if (int.TryParse(Console.ReadLine(), out int tipoLavagemId))
        {
            var carro = new Carro(dono, placa, modelo)
            {
                TipoLavagemId = tipoLavagemId
            };

            carroRepository.AdicionarCarro(carro);

            Console.WriteLine("Carro adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Tipo de lavagem inválido. Tente novamente.");
        }
    }

    static void MostrarCarros()
    {
        var carros = carroRepository.ConsultarCarros();

        Console.WriteLine("Carros no banco:");
        foreach (var carro in carros)
        {
            Console.WriteLine($"Dono: {carro.Dono}, Placa: {carro.Placa}, Modelo: {carro.Modelo}");
        }
    }

    static void AdicionarServicoLavagem()
    {
        Console.WriteLine("Insira o tipo de lavagem:");
        string tipoLavagem = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Insira os detalhes da lavagem:");
        string detalhesLavagem = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Insira o custo da lavagem:");
        if (decimal.TryParse(Console.ReadLine(), out decimal custo))
        {
            var servicoLavagem = new ServicoLavagem
            {
                Tipo = tipoLavagem,
                Detalhes = detalhesLavagem,
                Valor = custo
            };

            servicoLavagemRepository.AdicionarServicoLavagem(servicoLavagem);

            Console.WriteLine("Serviço de lavagem adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Custo inválido. Tente novamente.");
        }
    }

    static void MostrarTiposLavagem()
    {
        var tiposLavagem = servicoLavagemRepository.ConsultarServicosLavagem();

        Console.WriteLine("Tipos de lavagem disponíveis:");
        foreach (var tipoLavagem in tiposLavagem)
        {
            Console.WriteLine($"[{tipoLavagem.Id}] - {tipoLavagem.Tipo} - Custo: {tipoLavagem.Valor}");

            if (!string.IsNullOrEmpty(tipoLavagem.Detalhes))
            {
                Console.WriteLine($"Detalhes: {tipoLavagem.Detalhes}");
            }
        }
    }

    static void LavagemENotaFiscal()
    {
        using (var context = new CarroContext())
        {
            var carroRepository = new CarroRepository(context);
            var servicoLavagemRepository = new ServicoLavagemRepository(context);

            var carros = carroRepository.ConsultarCarros();

            if (carros.Any())
            {
                Console.WriteLine("Carros disponíveis para lavagem:");
                foreach (var carro in carros)
                {
                    Console.WriteLine($"[{carro.Id}] - {carro.Modelo} ({carro.Placa})");
                }

                Console.WriteLine("Escolha o número do carro que você deseja lavar:");
                if (int.TryParse(Console.ReadLine(), out int escolhaCarroId))
                {
                    var carroEscolhido = carros.FirstOrDefault(c => c.Id == escolhaCarroId);

                    if (carroEscolhido != null)
                    {
                        // Obter os detalhes da lavagem para o tipo do carro escolhido
                        string tipoLavagem = carroEscolhido.TipoLavagem?.TipoLavagem ?? string.Empty;

                        // Obter os detalhes da lavagem para o tipo do carro escolhido
                        ServicoLavagem? detalhesLavagem = !string.IsNullOrEmpty(tipoLavagem)
                            ? servicoLavagemRepository.ObterDetalhesLavagem(tipoLavagem)
                            : null;

                        if (detalhesLavagem != null)
                        {
                            // Simular a lavagem
                            SimularLavagem(carroEscolhido, detalhesLavagem);

                            // Gera a nota fiscal
                            GerarNotaFiscal(carroEscolhido, detalhesLavagem);

                            // Remove o carro do banco de dados
                            carroRepository.RemoverCarro(carroEscolhido.Id);
                        }
                        else
                        {
                            Console.WriteLine($"Tipo de lavagem não encontrado para o carro {carroEscolhido.Modelo}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Carro escolhido não encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Número inválido. Operação cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Nenhum carro encontrado para lavagem.");
            }
        }
    }



    static void SimularLavagem(Carro carro, ServicoLavagem detalhesLavagem)
    {
        Console.WriteLine($"Lavando o carro {carro.Modelo}...");
        Console.WriteLine($"Tipo de lavagem: {detalhesLavagem.Tipo}");

        if (!string.IsNullOrEmpty(detalhesLavagem.Detalhes))
        {
            Console.WriteLine("Detalhes da lavagem:");
            string[] passos = detalhesLavagem.Detalhes.Split(", ");
            foreach (var passo in passos)
            {
                Console.WriteLine(passo);
                Thread.Sleep(2000);
            }
        }

        Console.WriteLine($"Carro {carro.Modelo} lavado com sucesso! Valor: {detalhesLavagem.Valor:C}");
    }

    static void GerarNotaFiscal(Carro carro, ServicoLavagem detalhesLavagem)
    {
        Console.WriteLine($"Nota fiscal gerada para o carro {carro.Modelo}. Valor: {detalhesLavagem.Valor:C}");
    }

    static void EncerrarPrograma()
    {
        Console.WriteLine("Encerrando o programa. Até logo!");
        Environment.Exit(0);
    }
}


