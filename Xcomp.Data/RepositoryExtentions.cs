using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Xcomp.Data
{
    public static class RepositoryExtentions
    {
        public static void AddDataRepositories(this IServiceCollection services)
        {
            #region Đăng ký các repository
            var assembly = Assembly.GetAssembly(typeof(RepositoryExtentions));
            var classes = assembly.ExportedTypes
               .Where(a => !a.Name.StartsWith("I") && a.Name.EndsWith("Repository"));
            foreach (Type implement in classes)
            {
                foreach (var @interface in implement.GetInterfaces())
                {
                    services.AddScoped(@interface, implement);
                }
            }
            #endregion
        }
    }
}
