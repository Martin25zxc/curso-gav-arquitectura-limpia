using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.Contracts.Persistance;

public interface IUnitOfWork
{
    Task Persistir();
    Task Reversar();
}
