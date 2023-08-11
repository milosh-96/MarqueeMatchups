using MarqueeMatchups.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarqueeMatchups.Core.Services
{
    public interface IJwtTokenGeneratorService
    {
        string CreateToken(ApplicationUser user);
    }
}
