using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzen.Domain.Exceptions
{
    public class LoginNotFoundAccountException (string email) : Exception($"Not found account with email {email}");
}
