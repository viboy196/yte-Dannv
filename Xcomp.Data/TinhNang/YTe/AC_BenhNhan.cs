using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
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
    public class AC_BenhNhan
    {
        
        private readonly IBenhNhanRepository _BenhNhanRepository;

        private readonly IUnitOfWork _uow;

        public AC_BenhNhan(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _BenhNhanRepository = services.GetRequiredService<IBenhNhanRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _BenhNhanRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BenhNhan][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<BenhNhan> Create(BenhNhan tc)
        {
            try
            {
                _BenhNhanRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BenhNhan][Create]:" + ex.Message, ex);
            }

        }

        public async Task<BenhNhan> Update(BenhNhan ltc)
        {
            try
            {
                _BenhNhanRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BenhNhan][Update]:" + ex.Message, ex);
            }

        }

        public async Task<BenhNhan> GetById(string id)
        {
            try
            {
                return await _BenhNhanRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BenhNhan][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<BenhNhan>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<BenhNhan>() : (List<BenhNhan>)(await _BenhNhanRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BenhNhan][Get]:" + ex.Message, ex);
            }
            
        }

        
        //---------------------------
        public async Task ThemLog(BenhNhan tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BenhNhan][ThemLog]:" + ex.Message, ex);
            }
        }

        
        /// <summary>
        /// Tạo bệnh nhân cho khoa phòng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        


        /// <summary>
        /// Update thông tin bệnh nhân
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        

        /// <summary>
        /// Thêm tiện ích cho bệnh nhân - thêm liên hệ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        

    }
}
