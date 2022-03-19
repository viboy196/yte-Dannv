using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;

namespace Xcomp.Data.IRepositories
{
    public interface IHeThongRepository: IRepository<HeThong>
    {
        Task<HeThong> GetByCodeHeThongAsync(CodeHeThong CodeHeThong);
        
    }
}
