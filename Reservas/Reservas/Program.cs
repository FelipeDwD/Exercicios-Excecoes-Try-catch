using System;

namespace Reservas
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");

            try
            {
                Console.Write("Número do quarto: ");
                int numeroQuarto = int.Parse(Console.ReadLine());

                Console.Write("Data de entrada (dd/mm/aaaa): ");
                DateTime dataEntrada = DateTime.Parse(Console.ReadLine(), culture);

                Console.Write("Data de saída: (dd/mm/aaaa): ");
                DateTime dataSaida = DateTime.Parse(Console.ReadLine(), culture);

                Reserva reserva = new Reserva(numeroQuarto, dataEntrada, dataSaida);

                Console.WriteLine(reserva);

                Console.Write("Nova data de entrada: ");
                dataEntrada = DateTime.Parse(Console.ReadLine(), culture);

                Console.Write("Nova data de saída: ");
                dataSaida = DateTime.Parse(Console.ReadLine(), culture);

                reserva.AlterarDatas(dataEntrada, dataSaida);

                Console.WriteLine(reserva);
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Você inseriu número do quarto ou data em formato errado!");
            }
            
        }
    }
}
