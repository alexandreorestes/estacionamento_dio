using System;
using System.Collections.Generic;

class Program
{
    static List<string> veiculos = new List<string>();
    static double taxaEstacionamento;
    static double valorHoraAdicional;

    static void Main()
    {
        Console.Write("Digite a taxa de estacionamento: ");
        taxaEstacionamento = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite o valor da hora adicional: ");
        valorHoraAdicional = Convert.ToDouble(Console.ReadLine());

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Adicionar veiculos");
            Console.WriteLine("2 - Listar veiculos");
            Console.WriteLine("3 - Remover veiculos");
            Console.WriteLine("4 - Encerrar Programa");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Adicionarveiculos();
                    break;
                case "2":
                    Listarveiculos();
                    break;
                case "3":
                    Removerveiculos();
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void Adicionarveiculos()
    {
        Console.Write("Digite o veiculo a ser adicionado: ");
        string novo_veiculo = Console.ReadLine();
        veiculos.Add(novo_veiculo);
        Console.WriteLine("Veículo adicionado com sucesso!");
    }

    static void Listarveiculos()
    {
        Console.WriteLine("Veiculos:");
        for (int i = 0; i < veiculos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {veiculos[i]}");
        }
    }

    static void Removerveiculos()
    {
        Listarveiculos();
        Console.Write("Digite o número do veiculo a ser removido: ");
        int indice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indice >= 0 && indice < veiculos.Count)
        {
            Console.WriteLine($"Confirme as horas adicionais utilizadas para {veiculos[indice]}:");
            int horasAdicionais = Convert.ToInt32(Console.ReadLine());

            double valorTotal = taxaEstacionamento + (horasAdicionais * valorHoraAdicional);

            Console.WriteLine($"Total a ser pago: {valorTotal}");

            Console.WriteLine($"Confirmar pagamento para remover {veiculos[indice]}?");
            Console.Write("Digite 'sim' para confirmar ou 'nao' para cancelar: ");
            string confirmacao = Console.ReadLine();

            if (confirmacao.ToLower() == "sim")
            {
                veiculos.RemoveAt(indice);
                Console.WriteLine("Veiculo removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Remoção cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Índice inválido. Tente novamente.");
        }
    }
}

