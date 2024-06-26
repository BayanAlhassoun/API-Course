using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;

namespace TheLearningHub.core.IService
{
    public interface ILoginService
    {
        string Login(Login login);
    }
}
