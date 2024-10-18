using Microsoft.EntityFrameworkCore;

namespace L2code.Manoelcaixas.Infrastructure.Data
{
    public class EmpacotamentoContext : DbContext
    {
        public EmpacotamentoContext(DbContextOptions<EmpacotamentoContext> options) : base(options)
        {

        }

    }
}
