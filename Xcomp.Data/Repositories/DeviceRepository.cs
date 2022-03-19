using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Domain;

namespace Xcomp.Data.Repositories
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(IMongoContext context) : base(context)
        {
             
        }

        public async Task<Device?> GetByCodeAsync(string code)
        {
            if (code == null) return null;
           
            var data = await DbSet.Find(x => x.Code == code).FirstOrDefaultAsync();
            return data != null ? data : null;
        }
    }
}
