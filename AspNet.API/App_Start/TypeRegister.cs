using AspNet.API.Controllers;
using Raique.Authenticate.Common.Config;
using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Controllers;
using Raique.Database.SqlServer.Contracts;
using Raique.JWT;
using Raique.JWT.Protocols;
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
            #region Configuração
            Raique.DependencyInjection.Repository.SetSingleton<IDatabaseConfig, SqlServerConnection>();
            Raique.DependencyInjection.Repository.SetSingleton<IJWTConfig, JWTConfig>();
            #endregion

            #region Repositórios
            Raique.DependencyInjection.Repository.SetSingleton<IAppRepository, AppRepossitoryImpl>();
            Raique.DependencyInjection.Repository.SetSingleton<ITokenRepository, TokenRepositoryImpl>();
            Raique.DependencyInjection.Repository.SetSingleton<IUserRepository, UserRepositoryImpl>();
            #endregion

            #region Controllers Base
            Raique.DependencyInjection.Repository.SetSingleton<IAppControler, AppControllerImpl>();
            Raique.DependencyInjection.Repository.SetTransiente<IUserController, UserControllerImpl>();
            Raique.DependencyInjection.Repository.SetTransiente<ILoginController, LoginControllerImpl>();
            Raique.DependencyInjection.Repository.SetTransiente<ITokenController, TokenControllerImpl>();
            #endregion

            #region Controllers
            Raique.DependencyInjection.Repository.SetTransiente<UserController, UserController>();
            Raique.DependencyInjection.Repository.SetTransiente<AppController, AppController>();
            Raique.DependencyInjection.Repository.SetTransiente<LoginController, LoginController>();
            Raique.DependencyInjection.Repository.SetTransiente<TokenController, TokenController>();
            #endregion

            #region Token
            Raique.DependencyInjection.Repository.SetSingleton<ITokenCreator, TokenCreatorImpl>();
            Raique.DependencyInjection.Repository.SetSingleton<ITokenInfoExtractor, TokenInfoExtractorImpl>();
            #endregion
        }



    }
}