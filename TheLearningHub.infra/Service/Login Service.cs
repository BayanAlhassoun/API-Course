using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
          var result =  _loginRepository.Login(login);  //RESULT = null, Login

            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Belive in your self, keep going and never stop ... you are star and the ski is the limit., Belive in your self, keep going and never stop ... you are star and the ski is the limit ")); // H + P + SC
                var signCred = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim("RoleId" , result.Roleid.ToString()),
                    new Claim("UserId", result.Studentid.ToString())
                };

                var tokenOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signCred);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return token;
            }
        }
    }
}
