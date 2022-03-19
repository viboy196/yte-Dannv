using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;

namespace Xcomp.Data.Repositories
{
    public class HeThongRepository : BaseRepository<HeThong>, IHeThongRepository
    {
        public HeThongRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<HeThong> GetByCodeHeThongAsync(CodeHeThong CodeHeThong)
        {
            var data = await DbSet.FindAsync(Builders<HeThong>.Filter.Eq("CodeHeThong", CodeHeThong));
            return data.SingleOrDefault();
        }
}
}
