using System;
using System.Collections.Generic;
using System.Text;

namespace Reservas
{
    class DomainException : ApplicationException
    {
        public DomainException(string mensagem) : base(mensagem)
        {

        } 
        
    }
}
