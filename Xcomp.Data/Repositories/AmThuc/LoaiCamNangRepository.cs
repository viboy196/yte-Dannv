using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Domain;

namespace Xcomp.Data.Repositories
{
    public class LoaiCamNangRepository : BaseRepository<LoaiCamNang>, ILoaiCamNangRepository
    {
        public LoaiCamNangRepository(IMongoContext context) : base(context)
        {
        }

         
    }
}
