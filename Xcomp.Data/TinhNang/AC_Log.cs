using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;

namespace Xcomp.Data.TinhNang
{
    public class AC_Log
    {
        
        private readonly ILogRepository _LogRepository;

        private readonly IUnitOfWork _uow;

        public AC_Log(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LogRepository = services.GetRequiredService<ILogRepository>();

        }

        public async Task RemoveAll()
        {
            _LogRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<Log> Create(Log ltc)
        {
            _LogRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<Log> Update(Log ltc)
        {
            _LogRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<Log> GetById(string id)
        {   
            return await _LogRepository.GetByIdAsync(id);
        }

        public async Task<List<Log>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<Log>() : (List<Log>)(await _LogRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }


        //---------------------------


    }
}
