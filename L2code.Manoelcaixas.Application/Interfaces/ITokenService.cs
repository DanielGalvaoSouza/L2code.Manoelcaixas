using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Application.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(string userName);
        public void RevokeToken(string token);
    }
}
