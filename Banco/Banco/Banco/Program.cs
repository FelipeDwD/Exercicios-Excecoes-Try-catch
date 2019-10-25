using System;
using System.Globalization;
using Banco.Entidades;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados da conta");

            try
            {
                Console.Write("Número: ");
                int numero = int.Parse(Console.ReadLine());

                Console.Write("Titular: ");
                string titular = Console.ReadLine();

                Console.Write("Saldo inicial: ");
                double saldoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Limite para saque: ");
                double limiteSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Conta conta = new Conta(numero, titular, saldoInicial, limiteSaque);

                Console.WriteLine(conta);

                Console.Write("Digite um valor para saque: ");
                double valorSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                conta.Sacar(valorSaque);

                Console.WriteLine(conta);
            }
            catch (DomainException e)
            {
                Console.WriteLine($"Erro saque: {e.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Digite o formato certo para entrada de dados!");
            }
            catch (Exception)
            {
                Console.WriteLine("Erro");
            }
            


        }
    }
}
