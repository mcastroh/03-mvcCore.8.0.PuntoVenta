using Microsoft.EntityFrameworkCore;
using WebPuntoVenta.Data.Context;

namespace WebPuntoVenta
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("CnSqlServer"));
            });

            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));

            //services.AddScoped<ICorreoService, CorreoService>();
            //services.AddScoped<IUtilidadesService, UtilidadesService>();
            //services.AddScoped<IRolService, RolService>();
            //services.AddScoped<IFireBaseService, FireBaseService>();
            //services.AddScoped<IUsuarioService, UsuarioService>();
            //services.AddScoped<IEmpresaService, EmpresaService>();
            //services.AddScoped<IArticuloService, ArticuloService>();

            ////services.AddScoped<IVentaRepository, VentaRepository>();
            ////services.AddScoped<IVentaService, VentaService>();

            //services.AddScoped<IOrdenCompraRepository, OrdenCompraRepository>();
            //services.AddScoped<IOrdenCompraService, OrdenCompraService>();

            //services.AddScoped<ITablasBaseService, TablasBaseService>();


            return services;
        }


    }
}
