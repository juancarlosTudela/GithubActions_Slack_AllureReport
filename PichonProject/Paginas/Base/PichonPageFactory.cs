using Autofac;
using PichonProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PichonProject.Paginas.Base
{
    public class PichonPageFactory:IPageFactory
    {
        private readonly IContainer _container;
        //private readonly string _brand;
        private IHomePage? _homePage;
        private ILoginPage? _loginPage;

        public PichonPageFactory(IContainer container)
        {
            _container = container;
            //_brand=brand;

        }


        public IHomePage HomePage()
        {
            if (_homePage == null)
            {
                _homePage = ResolvePage<IHomePage>();
                return _homePage;
            }
            return _homePage;
        }

        public ILoginPage LoginPage()
        {
            if (_loginPage == null)
            {
                _loginPage = ResolvePage<ILoginPage>();
                return _loginPage;
            }
            return _loginPage;
        }




        //Metodo generico 
        private T ResolvePage<T>() where T : IPages
        {
            var page = _container.Resolve<IEnumerable<T>>();
            var brandpage = page.FirstOrDefault();
            return brandpage;
            //!= null ? brandpage : page.FirstOrDefault(p => p.Brand.Contains("generic"));
        }
    }
}
