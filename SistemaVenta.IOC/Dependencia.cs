using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.DAL.Implementacion;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.BLL.Implementacion;
using SistemaVenta.BLL.Interfaces;



namespace SistemaVenta.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DbventaContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });

            // mitienda-16bc8.appspot.com
            // api web  AIzaSyCzCHeqFb8UzFXC2ibqCLjqehUyio_gm6Y

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();

            services.AddScoped<ICorreoService, CorreoService>();
            services.AddScoped<iFireBaseService, FireBaseService>();

            services.AddScoped<IUtilidadesServices, UtilidadesServices>();
            services.AddScoped<IRolService, RolServices>();


            services.AddScoped<IUsuarioService, UsuarioService>();



        }
    }
}
