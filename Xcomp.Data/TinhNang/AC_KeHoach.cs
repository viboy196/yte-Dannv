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
    public class AC_KeHoach
    {
        
        private readonly IKeHoachRepository _KeHoachRepository;

        private readonly IUnitOfWork _uow;

        public AC_KeHoach(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _KeHoachRepository = services.GetRequiredService<IKeHoachRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _KeHoachRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<KeHoach> Create(KeHoach tc)
        {
            try
            {
                _KeHoachRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][Create]:" + ex.Message, ex);
            }

        }

        public async Task<KeHoach> Update(KeHoach ltc)
        {
            try
            {
                _KeHoachRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][Update]:" + ex.Message, ex);
            }

        }

        public async Task<KeHoach> GetById(string id)
        {
            try
            {
                return await _KeHoachRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<KeHoach>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<KeHoach>() : (List<KeHoach>)(await _KeHoachRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<KeHoach>> GetByCode(string Code)
        {
            try
            {
                return (List<KeHoach>)(await _KeHoachRepository.GetAllAsync(c => c.CodeLoaiKeHoach == Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][GetByCode]:" + ex.Message, ex);
            }
        }
        //---------------------------
        public async Task ThemLog(KeHoach tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][ThemLog]:" + ex.Message, ex);
            }
        }

        public async Task Them_Viec(KeHoach KeHoach, Viec viec)
        {
            try
            {
                await Update(KeHoach.ThemViec(viec.Id));
                await AC.Viec.Update(viec.SetKeHoach(KeHoach.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][Them_Viec]:" + ex.Message, ex);
            }
            
        }

        public async Task<KeHoach> Update_DanDo(ViecRequest model)
        {
            try
            {
                var kh = await GetById(model.IdKeHoach);
                kh.DanDo = model.DanDo;
                await Update(kh);
                return kh;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][Update_DanDo]:" + ex.Message, ex);
            }
            
        }

        public async Task<KeHoach> Xoa_Viec(string IdViec)
        {
            try
            {
                var v = await AC.Viec.GetById(IdViec);
                var kh = await GetById(v.IdKeHoach);
                await Update(kh.XoaViec(v.Id));
                await AC.Viec.Remove(v.Id);
                return kh;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][Xoa_Viec]:" + ex.Message, ex);
            }
            
        }

        public async Task<KeHoach> ThemKeHoachTheoCa(string Idca, string Idlkh)
        {
            try
            {
                var ca = await AC.Ca.GetById(Idca);
                var lkh = await AC.LoaiKeHoach.GetById(Idlkh);

                var kh = await AC.KeHoach.Create(new KeHoach
                {
                    LoaiKeHoach = lkh.Name,
                    CodeLoaiKeHoach = lkh.Code
                });
                await AC.Ca.Them_KeHoach(ca, kh);
                return kh;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_KeHoach][ThemKeHoachTheoCa]:" + ex.Message, ex);
            }
            
        }


    }
}
