using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Domain;

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message)
    {
    }
}
