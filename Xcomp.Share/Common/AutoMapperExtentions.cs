using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Xcomp.Share.Common
{
    public static class AutoMapperExtentions
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            #region Add automapper
            var assembly = Assembly.GetAssembly(typeof(AutoMapperExtentions));
            services.AddAutoMapper(assembly);
            #endregion
        }
    }   
}
