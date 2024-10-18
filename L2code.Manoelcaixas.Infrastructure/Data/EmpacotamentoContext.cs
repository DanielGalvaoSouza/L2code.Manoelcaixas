using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Infrastructure.Data
{
    public class EmpacotamentoContext : DbContext
    {
        public EmpacotamentoContext(DbContextOptions<EmpacotamentoContext> options) : base(options)
        {

        }

    }
}
