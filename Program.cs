using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Threading;
using System.Linq;

class Program
{
    private static Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

    static void Main()
    {
        string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";

        bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
        bandasRegistradas.Add("Beatles", new List<int>());


        ExibirOpcoesDoMenu();
        ExibirMensagemDeBoasVindas(mensagemDeBoasVindas);
    }

    static void ExibirLogo()
    {
        Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
Boas vindas ao Screen Sound!");

    }

    static void ExibirMensagemDeBoasVindas(string mensagem)
    {
        Console.Clear();

        Console.WriteLine(mensagem);
    }

    static void ExibirOpcoesDoMenu()
    {
        ExibirLogo();

        Console.WriteLine("\nDigite 1 para regisrar uma banda");
        Console.WriteLine("Digite 2 para mostrar todas as bandas");
        Console.WriteLine("Digite 3 para avaliar uma banda");
        Console.WriteLine("Digite 4 para exibir a média de uma banda");
        Console.WriteLine("Digite -1 para sair");
        Console.Write("\nDigite a opção desejada: ");

        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);


        switch (opcaoEscolhidaNumerica)
        {
            case 1:
                RegistrarBanda();
                break;
            case 2:
                MostrarBandasRegistradas();
                break;
            case 3:
                AvaliarUmaBanda();
                break;
            case 4:
                ExibirAMediaDeUmaBanda();
                break;
            case -1:
                Console.WriteLine("Tchau tchau :)");
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }

    static void RegistrarBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Registrar uma banda");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        bandasRegistradas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

    static void MostrarBandasRegistradas()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

    static void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        Console.Clear();
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }
    static void AvaliarUmaBanda()
    {
        //digite uma banda que deseja avaliar;
        //se a banda existir no dicionário >> atribuir uma nota para a banda;
        //senão volta para o menu principal;

        Console.Clear();
        ExibirTituloDaOpcao("Avaliar banda");
        Console.Write("Digite um nome da banda que deseja avaliar:");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
            int nota = int.Parse(Console.ReadLine()!);
            bandasRegistradas[nomeDaBanda].Add(nota);
            Console.WriteLine($"\nA {nota} foi realizada com sucesso para a banda {nomeDaBanda}");
            Thread.Sleep(4000);
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
    }
    static void ExibirAMediaDeUmaBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibir média da banda");
        Console.Write("Digite o nome da banda que deseja ver a média: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            List<int> notas = bandasRegistradas[nomeDaBanda];
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
                Console.WriteLine($"\n A média da banda {nomeDaBanda} é {notasDaBanda.Average()}");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

        }

        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}
  