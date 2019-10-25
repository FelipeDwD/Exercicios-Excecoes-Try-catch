using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Entidades
{
    class DomainException : ApplicationException
    {
        public DomainException(string mensagem) : base(mensagem)
        {

        }
    }
}
