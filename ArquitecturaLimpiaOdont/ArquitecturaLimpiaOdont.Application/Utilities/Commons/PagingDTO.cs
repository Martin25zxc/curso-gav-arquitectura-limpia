using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.Utilities.Commons;

public class PagingDTO<T>
{
    public List<T> Items { get; set; } = [];
    public int Total { get; set; }
}
