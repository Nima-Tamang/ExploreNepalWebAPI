﻿using IdentityFour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityFour.Interfaces
{
        public interface ITokenService
        {
            string CreateToken(AppUser user);
        }
    
}
