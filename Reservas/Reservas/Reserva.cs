using System;
using System.Collections.Generic;
using System.Text;

namespace Reservas
{
    class Reserva
    {
        public int NumeroDoQuarto { get; private set; }

        public DateTime DataEntrada { get; private set; }

        public DateTime DataSaida { get; private set; }

        public int DiasDeReserva { get; private set; }

        public Reserva(int numeroDoQuarto, DateTime dataEntrada, DateTime dataSaida)
        {
            NumeroDoQuarto = numeroDoQuarto;
            SetDatas(dataEntrada, dataSaida);
        }

        public void SetDatas(DateTime dataEntrada, DateTime dataSaida)
        {
            bool validarDatas = ValidarReserva(dataEntrada, dataSaida);

            if (validarDatas)
            {
                DataEntrada = dataEntrada;
                DataSaida = dataSaida;
                DiasDeReserva = DiasReserva(dataEntrada, dataSaida);
            }           
        }

        public void AlterarDatas(DateTime dataEntrada, DateTime dataSaida)
        {
            bool validarDatas = ValidarReserva(dataEntrada, dataSaida);
            bool dataFutura = dataEntrada > DataEntrada;

            if (validarDatas && dataFutura)
            {
                SetDatas(dataEntrada, dataSaida);
            }
            else
            {
                throw new DomainException("A nova data de entrada precisa ser posterior a atual!");
            }

        }


        public bool ValidarReserva(DateTime dataEntrada, DateTime dataSaida)
        {
            DateTime now = DateTime.Now;            

            if (dataEntrada > dataSaida)
            {
                throw new DomainException("Data de entrada é maior que saída!");
            }
            if(dataEntrada < now || dataSaida < now)
            {
                throw new DomainException("Datas já passou, favor registrar datas futuras");               
            }
            return true;
        }

        private int DiasReserva(DateTime dataEntrada, DateTime dataSaida)
        {
            TimeSpan dias = dataSaida.Subtract(dataEntrada);
            return (int) dias.TotalDays;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Quarto: ");
            sb.AppendLine(NumeroDoQuarto.ToString());
            sb.Append("Entrada: ");
            sb.AppendLine(DataEntrada.ToString("dd/MM/yyyy"));
            sb.Append("Saída: ");
            sb.AppendLine(DataSaida.ToString("dd/MM/yyyy"));
            sb.Append("Total de dias: ");
            sb.AppendLine(DiasDeReserva.ToString());

            return sb.ToString();
        }
    }
}
