using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;
using TheLearningHub.core.IRepository;
using TheLearningHub.core.IService;

namespace TheLearningHub.infra.Service
{
    public class Login_Service : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
public Login_Service(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public string Login(Login login)
        {
          var result =  _loginRepository.Login(login);  

            if (result == null)
            {
                return null;
            }
            else
            {
                //Generate Token
                return "Token";
            }
        }
    }
}
