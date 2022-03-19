using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;

namespace Xcomp.Data.TinhNang
{
    public class AC_Mes
    {

        private readonly IMesRepository _MesRepository;

        private readonly IUnitOfWork _uow;

        public AC_Mes(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _MesRepository = services.GetRequiredService<IMesRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _MesRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Mes][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<Mes> Create(Mes tc)
        {
            try
            {
                _MesRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Mes][Create]:" + ex.Message, ex);
            }

        }

        public async Task<Mes> Update(Mes ltc)
        {
            try
            {
                _MesRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Mes][Update]:" + ex.Message, ex);
            }

        }

        public async Task<Mes> GetById(string id)
        {
            try
            {
                return await _MesRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Mes][GetById]:" + ex.Message, ex);
            }

        }

        public async Task<List<Mes>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<Mes>() : (List<Mes>)(await _MesRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Mes][Get]:" + ex.Message, ex);
            }

        }


        //---------------------------
       
       
        //-------------------------------


    }
}
