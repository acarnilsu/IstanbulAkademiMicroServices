using System;
using System.Collections.Generic;
using System.Text;

namespace AkademiECommerce.Shared.Services
{
    public interface ISharedIdentityService
    {
        public string GetUserID { get;  }
    }
}
