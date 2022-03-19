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
    public class AC_Viec
    {
        
        private readonly IViecRepository _ViecRepository;

        private readonly IUnitOfWork _uow;

        public AC_Viec(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _ViecRepository = services.GetRequiredService<IViecRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _ViecRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Viec][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<Viec> Create(Viec tc)
        {
            try
            {
                _ViecRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Viec][Create]:" + ex.Message, ex);
            }

        }

        public async Task<Viec> Update(Viec ltc)
        {
            try
            {
                _ViecRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Viec][Update]:" + ex.Message, ex);
            }

        }

        public async Task<Viec> GetById(string id)
        {
            try
            {
                return await _ViecRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Viec][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task Remove(string Idv)
        {
            try
            {
               _ViecRepository.Remove(Idv);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Viec][Remove]:" + ex.Message, ex);
            }
            
        }
        public async Task<List<Viec>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<Viec>() : (List<Viec>)(await _ViecRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Viec][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<Viec>> GetByCode(string Code)
        {
            try
            {
                return (List<Viec>)(await _ViecRepository.GetAllAsync(c => c.CodeLoaiViec == Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Viec][GetByCode]:" + ex.Message, ex);
            }
        }
        //---------------------------
        public async Task ThemLog(Viec tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Viec][ThemLog]:" + ex.Message, ex);
            }
        }

        public async Task<Viec> Create_Viec(ViecRequest model)
        {
            try
            {
                var lv = await AC.LoaiViec.GetById(model.IdLoaiViec);
                double stt = 0;
                try
                {
                    stt = Convert.ToDouble(model.STT);
                }
                catch { stt = 1; }
                var v = await Create(new Viec
                {
                    CodeLoaiViec = lv.Code,
                    LoaiViec = lv.Name,
                    DanDo = model.DanDo,
                    Stt = stt,
                    ThoiGianText = model.ThoiGian
                });
                var kh = await AC.KeHoach.GetById(model.IdKeHoach);
                await AC.KeHoach.Them_Viec(kh, v);
                return v;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Viec][Create_Viec]:" + ex.Message, ex);
            }
            
        }

        public async Task<Viec> Update_Viec(ViecRequest model)
        {
            try
            {
                var lv = await AC.LoaiViec.GetById(model.IdLoaiViec);

                double stt = 0;

                var v = await GetById(model.IdViec);
                try
                {
                    stt = Convert.ToDouble(model.STT);
                }
                catch { stt = v.Stt; }

                if (v.CodeLoaiViec != lv.Code)
                {
                    v.CodeLoaiViec = lv.Code;
                    v.LoaiViec = lv.Name;
                }
                v.Stt = stt;
                v.ThoiGianText = model.ThoiGian;
                v.DanDo = model.DanDo;

                await Update(v);

                return v;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Viec][Update_Viec]:" + ex.Message, ex);
            }
           
        }


    }
}
