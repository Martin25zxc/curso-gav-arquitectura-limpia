using ArquitecturaLimpiaOdont.Identity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Identity;
            
public class OdontIdentityDbContext : IdentityDbContext<Usuario>
{
    public OdontIdentityDbContext(DbContextOptions<OdontIdentityDbContext> options)
        : base(options)
    {
    }

    protected OdontIdentityDbContext()
    {
    }
}
