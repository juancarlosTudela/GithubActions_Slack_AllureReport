using PichonProject.Paginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PichonProject.Interfaces
{
    public interface ILoginPage : IPages
    {
        LoginPage insertDataLogin_Error();
        LoginPage insertDataLogin_Successful();
        LoginPage goLoginPage();
        void validarTxtErrorUser();
        void validateSuccessfulLogin();
        void clickButtonLogin();
    }
}
