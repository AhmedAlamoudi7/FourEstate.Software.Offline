using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.Exceptions
{
    public class UserNotActiveExceptionException : Exception
    {
        public UserNotActiveExceptionException():base("User Not Active")
        {

        }
    }
}
