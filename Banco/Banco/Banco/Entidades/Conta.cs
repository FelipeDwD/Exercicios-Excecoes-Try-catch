using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Banco.Entidades
{
    class Conta
    {
        public int Numero { get; private set; }

        public string Titular { get; private set; }

        public double Saldo { get; private set; }

        public double LimiteSaque { get; private set; }

        public Conta(int numero, string titular, double saldoInicial, double limiteSaque)
        {
            Numero = numero;
            Titular = titular;
            Depositar(saldoInicial);
            LimiteSaque = limiteSaque;
        }

        private void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor > LimiteSaque)
            {
                throw new DomainException("Valor solicitado é maior que o valor limite!");
            }

            if (valor > Saldo)
            {
                throw new DomainException("Saldo insuficiente!");
            }

            Saldo -= valor;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Número: ");
            sb.AppendLine(Numero.ToString());
            sb.Append("Titular: ");
            sb.AppendLine(Titular);
            sb.Append("Saldo: ");
            sb.AppendLine(Saldo.ToString("F2", CultureInfo.InvariantCulture));
            sb.Append("Limite para Saque: ");
            sb.AppendLine(LimiteSaque.ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
