using CNRInnovaV1.Api.Aplicacion.Servicios;
using CNRInnovaV1.Api.Comun;
using CNRInnovaV1.Api.Comun.Servicios;
using CNRInnovaV1.Api.Dominio;
using CNRInnovaV1.Api.Dominio.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.DI
{
    
    public class InjectionDependency
    {
        /// <summary>
        /// manejo de inyeccion de dependencias
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterProfile(IServiceCollection services)
        {
            #region Inyeccion de Dependencia Aplicacion
            services.AddTransient<IAuthApp, AuthApp>();


            #endregion

            #region Inyeccion de Dependencia Dominio
            services.AddTransient<IAuthDom, AuthDom>();


            #endregion

            #region Inyeccion de Dependencia CapaComun

            services.AddTransient<ITokenJWTComm, TokenJWTComm>();
            services.AddTransient<IEncryptComm, EncryptComm>();
            services.AddTransient<IToolDataComm, ToolDataComm>();

            #endregion
        }
    }
}
