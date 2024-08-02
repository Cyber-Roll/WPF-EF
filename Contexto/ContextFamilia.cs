using Microsoft.EntityFrameworkCore;

namespace Contexto
{
    public class ContextFamilia : DbContext
    {
        ContextFamilia()
        {
        }
        ContextFamilia(DbContextOptions options) : base(options)
        { //intentionally empty. }

        }
    }
}
