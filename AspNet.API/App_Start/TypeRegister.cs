using AspNet.API.Controllers;
using Raique.Authenticate.Common.Config;
using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Controllers;
using Raique.Database.SqlServer.Contracts;
using Raique.Microservices.Authenticate.Infra.SqlServer;
using Raique.Microservices.Authenticate.Protocols;
using System.Web.Http;

namespace AspNet.API.App_Start
{
    public static class TypeRegister
    {
        public static void StartControllerDependencyInjectory()
        {
            //Passado para o WebApiConfig
            //GlobalConfiguration.Configuration.DependencyResolver = new DependencyResolver(GlobalConfiguration.Configuration.DependencyResolver);
        }
        public static void Init()
        {
            #region Configuração de banco de dados
            Raique.DependencyInjection.Repository.SetSingleton<IDatabaseConfig, SqlServerConnection>();
            #endregion

            #region Repositórios
            Raique.DependencyInjection.Repository.SetSingleton<IAppRepository, AppRepossitoryImpl>();
            Raique.DependencyInjection.Repository.SetSingleton<ITokenRepository, TokenRepositoryImpl>();
            Raique.DependencyInjection.Repository.SetSingleton<IUserRepository, UserRepositoryImpl>();
            #endregion

            #region Controllers Base
            Raique.DependencyInjection.Repository.SetSingleton<IAppControler, AppControllerImpl>();
            Raique.DependencyInjection.Repository.SetTransiente<IUserController, UserControllerImpl>();
            #endregion

            #region Controllers
            Raique.DependencyInjection.Repository.SetTransiente<UserController, UserController>();
            Raique.DependencyInjection.Repository.SetTransiente<AppController, AppController>();
            #endregion
        }



    }
}