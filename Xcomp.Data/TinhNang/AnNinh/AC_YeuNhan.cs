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
    public class AC_YeuNhan
    {
        
        private readonly IYeuNhanRepository _YeuNhanRepository;

        private readonly IUnitOfWork _uow;

        public AC_YeuNhan(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _YeuNhanRepository = services.GetRequiredService<IYeuNhanRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _YeuNhanRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<YeuNhan> Create(YeuNhan tc)
        {
            try
            {
                _YeuNhanRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][Create]:" + ex.Message, ex);
            }

        }

        public async Task<YeuNhan> Update(YeuNhan ltc)
        {
            try
            {
                _YeuNhanRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][Update]:" + ex.Message, ex);
            }

        }

        public async Task<YeuNhan> GetById(string id)
        {
            try
            {
                return await _YeuNhanRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<YeuNhan>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<YeuNhan>() : (List<YeuNhan>)(await _YeuNhanRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<YeuNhan>> GetByCode(string Code)
        {
            try
            {
                return (List<YeuNhan>)(await _YeuNhanRepository.GetAllAsync(c => c.CodeLoaiYeuNhan == Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][GetByCode]:" + ex.Message, ex);
            }
        }
        //---------------------------
        public async Task ThemLog(YeuNhan tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][ThemLog]:" + ex.Message, ex);
            }
        }
        //-------------------------------

        /// <summary>
        /// Tạo bệnh nhân cho khoa phòng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public async Task<YeuNhan> Create_YeuNhan(YeuNhanRequest model)
        //{
        //    try
        //    {
        //        var nd = await AC.NguoiDung.GetById(model.IdNguoiTao);
        //        var lyn = await AC.LoaiYeuNhan.GetByCode(model.CodeLoaiYeuNhan);

        //        var yn = new YeuNhan()
        //        {
        //            Name = model.Ten,
        //            Phone = model.SoDienThoai,
        //            GioiThieu = model.GioiThieu,
        //            CreatedBy = model.IdNguoiTao,
        //            CodeLoaiYeuNhan = lyn.Code,
        //            LoaiYeuNhan = lyn.Name,
        //        };

        //        await Create(yn);

        //        var lg = await AC.Log.Create(new Log
        //        {
        //            LoaiLog = LoaiLog.Tao_YeuNhan,
        //            IdNguoiDung = model.IdNguoiTao,
        //            IdDoiTuong = yn.Id,
        //            NoiDung = "Tạo yếu nhân",
        //            Data = new BsonDocument
        //            {
        //                {"Name",yn.Name }
        //            }
        //        });

        //        if (yn.Phone != null) lg.Data.Set("Phone", yn.Phone);
        //        if (yn.GioiThieu != null) lg.Data.Set("GioiThieu", yn.GioiThieu);

        //        await ThemLog(yn, lg);

        //        //Đưa bệnh nhân vào danh sách bệnh nhân của phòng hoặc khoa
        //        var cv = await AC.CongViec.GetById(model.IdCongViec);
        //        var pb = await AC.PhongBan.GetById(cv.IdPhongBan);
        //        //await AC.PhongBan.Them_DoiTuong(pb, yn);


        //        return yn;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][Create_YeuNhan]:" + ex.Message, ex);
        //    }

        //}

        ///// <summary>
        /// Update thông tin bệnh nhân
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public async Task<YeuNhan> Update_YeuNhan(YeuNhanRequest model)
        //{
        //    try
        //    {
        //        var yn = await AC.YeuNhan.GetById(model.Id);
                

        //        var lg = new Log
        //        {
        //            LoaiLog = LoaiLog.Update_YeuNhan,
        //            IdNguoiDung = model.IdNguoiTao,
        //            IdDoiTuong = yn.Id,
        //            NoiDung = "Update thông tin yếu nhân nhân: ",
        //            Data = new BsonDocument()
        //        };

        //        if (yn.Name != model.Ten)
        //        {
        //            lg.NoiDung += "[Name]";
        //            lg.Data.Set("Name", model.Ten);
        //            yn.Name = model.Ten;
        //        }

        //        if (yn.Phone != model.SoDienThoai)
        //        {
        //            lg.NoiDung += "[Phone]";
        //            if (model.SoDienThoai != null) lg.Data.Set("Phone", model.SoDienThoai);
        //            yn.Phone = model.SoDienThoai;
        //        }

        //        if (yn.GioiThieu != model.GioiThieu)
        //        {
        //            lg.NoiDung += "[GioiThieu]";
        //            if (model.GioiThieu != null) lg.Data.Set("GioiThieu", model.GioiThieu);
        //            yn.GioiThieu = model.GioiThieu;
        //        }

        //        if (yn.TrangThaiHoSo != model.TrangThai)
        //        {
        //            lg.NoiDung += "[TrangThai]";
        //            if (model.TrangThai != null) lg.Data.Set("TrangThai", model.TrangThai);
        //            yn.TrangThaiHoSo = model.TrangThai;
        //        }

        //        if (yn.CodeLoaiYeuNhan != model.CodeLoaiYeuNhan)
        //        {
        //            lg.NoiDung += "[CodeLoaiYeuNhan]";
        //            if (model.CodeLoaiYeuNhan != null) lg.Data.Set("CodeLoaiYeuNhan", model.CodeLoaiYeuNhan);
        //            var lyn = await AC.LoaiYeuNhan.GetByCode(model.CodeLoaiYeuNhan);
        //            yn.CodeLoaiYeuNhan = model.CodeLoaiYeuNhan;
        //            yn.LoaiYeuNhan = lyn.Name;
        //        }

        //        await AC.Log.Create(lg);

        //        //save Update
        //        yn.UpdatedAt = DateTime.Now;
        //        yn.UpdatedBy = model.IdNguoiTao;
        //        await Update(yn);

        //        //Thêm log
        //        await ThemLog(yn, lg);

        //        return yn;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][Update_YeuNhan]:" + ex.Message, ex);
        //    }


        //}

        ///// <summary>
        /// Thêm tiện ích cho bệnh nhân - thêm liên hệ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Them_TienIch(TienIchRequest model)
        {
            try
            {
                var yn = await GetById(model.IdDoiTuong);
                var lti = await AC.LoaiTienIch.GetById(model.IdLoaiTienIch);

                var ti = await AC.TienIch.Create(new TienIch
                {
                    LoaiTienIch = lti.Name,
                    CodeLoaiTienIch = lti.Code,
                    CodeHeThong = lti.CodeHeThong,
                    VaiTroNguoiDung = model.VaiTro,
                    GioiThieu = model.GioiThieu,
                    Name = model.Ten,
                    Phone = model.SoDienThoai

                });

                //await AC.TienIch.Set_DoiTuong(ti, yn);

                if (model.SoDienThoai != null)
                {
                    var nd = await AC.NguoiDung.GetByPhone(model.SoDienThoai);
                    if (nd != null)
                    {
                        await AC.TienIch.Set_NguoiDung(ti, nd);
                    }
                }

                var lg = new Log
                {
                    LoaiLog = LoaiLog.Tao_TienIch,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = yn.Id,
                    NoiDung = "Tạo tiện ích yếu nhân ",
                    Data = new BsonDocument
                {
                    {"Id",ti.Id },
                    {"LoaiTienIch",ti.LoaiTienIch },
                    {"CodeLoaiTienIch",ti.CodeLoaiTienIch }
                }
                };

                if (ti.Name != null) lg.Data.Set("Name", ti.Name);
                if (ti.Phone != null) lg.Data.Set("Phone", ti.Phone);
                if (ti.VaiTroNguoiDung != null) lg.Data.Set("VaiTroNguoiDung", ti.VaiTroNguoiDung);
                if (ti.GioiThieu != null) lg.Data.Set("GioiThieu", ti.GioiThieu);

                await AC.Log.Create(lg);

                await ThemLog(yn, lg);

                lg = new Log
                {
                    LoaiLog = LoaiLog.Tao_TienIch,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = yn.Id,
                    NoiDung = "Tạo tiện ích yếu nhân ",
                    Data = new BsonDocument
                {
                    {"Id",ti.Id },
                    {"LoaiTienIch",ti.LoaiTienIch },
                    {"CodeLoaiTienIch",ti.CodeLoaiTienIch }
                }
                };

                if (ti.Name != null) lg.Data.Set("Name", ti.Name);
                if (ti.Phone != null) lg.Data.Set("Phone", ti.Phone);
                if (ti.VaiTroNguoiDung != null) lg.Data.Set("VaiTroNguoiDung", ti.VaiTroNguoiDung);
                if (ti.GioiThieu != null) lg.Data.Set("GioiThieu", ti.GioiThieu);

                await AC.Log.Create(lg);

                await AC.TienIch.ThemLog(ti, lg);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][Them_TienIch]:" + ex.Message, ex);
            }

        }

        //public async Task<YeuNhan> Update_TienIch(TienIchRequest model)
        //{
        //    try
        //    {
        //        var yn = await AC.YeuNhan.GetById(model.IdDoiTuong);
        //        var ti = await AC.TienIch.GetById(model.Id);

        //        var lg = new Log
        //        {
        //            LoaiLog = LoaiLog.Update_TienIch,
        //            IdNguoiDung = model.IdNguoiTao,
        //            IdDoiTuong = ti.Id,
        //            NoiDung = "Update thông tin tiện ích: ",
        //            Data = new BsonDocument()
        //        };

        //        var lti = await AC.LoaiTienIch.GetById(model.IdLoaiTienIch);
        //        if (ti.CodeLoaiTienIch != lti.Code)
        //        {
        //            lg.NoiDung += "[LoaiTienIch]";
        //            lg.Data.Set("LoaiTienIch", lti.Name);
        //            lg.NoiDung += "[CodeLoaiTienIch]";
        //            lg.Data.Set("CodeLoaiTienIch", lti.Code);
        //            ti.LoaiTienIch = lti.Name;
        //            ti.CodeLoaiTienIch = lti.Code;
        //        }

        //        if (ti.Name != model.Ten)
        //        {
        //            lg.NoiDung += "[Name]";
        //            lg.Data.Set("Name", model.Ten);
        //            ti.Name = model.Ten;
        //        }

        //        if (ti.Phone != model.SoDienThoai)
        //        {
        //            if (ti.IdNguoidung != null)
        //            {
        //                await AC.TienIch.Xoa_NguoiDung(ti, await AC.NguoiDung.GetById(ti.IdNguoidung));
        //            }

        //            lg.NoiDung += "[Phone]";
        //            if (model.SoDienThoai != null) lg.Data.Set("Phone", model.SoDienThoai);
        //            ti.Phone = model.SoDienThoai;

        //            var nd = await AC.NguoiDung.GetByPhone(model.SoDienThoai);
        //            if (nd != null)
        //            {
        //                await AC.TienIch.Set_NguoiDung(ti, nd);
        //            }
        //        }

        //        if (ti.GioiThieu != model.GioiThieu)
        //        {
        //            lg.NoiDung += "[GioiThieu]";
        //            if (model.GioiThieu != null) lg.Data.Set("GioiThieu", model.GioiThieu);
        //            ti.GioiThieu = model.GioiThieu;
        //        }

        //        if (ti.VaiTroNguoiDung != model.VaiTro)
        //        {
        //            lg.NoiDung += "[VaiTroNguoiDung]";
        //            if (model.GioiThieu != null) lg.Data.Set("VaiTroNguoiDung", model.VaiTro);
        //            ti.VaiTroNguoiDung = model.VaiTro;
        //        }

        //        if (ti.TrangThaiHoSo != model.TrangThai)
        //        {
        //            lg.NoiDung += "[TrangThai]";
        //            if (model.TrangThai != null) lg.Data.Set("TrangThai", model.TrangThai);
        //            ti.TrangThaiHoSo = model.TrangThai;
        //        }

        //        await AC.Log.Create(lg);

        //        //save Update
        //        ti.UpdatedAt = DateTime.Now;
        //        ti.UpdatedBy = model.IdNguoiTao;
        //        await AC.TienIch.Update(ti);

        //        //Thêm log
        //        await AC.TienIch.ThemLog(ti, lg);

        //        return yn;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][Update_TienIch]:" + ex.Message, ex);
        //    }

        //}

        public async Task Them_Ca(CaRequest model)
        {
            try
            {
                var yn = await GetById(model.IdDoiTuong);
                var lc = await AC.LoaiCa.GetById(model.IdLoaiCa);

                var ca = await AC.Ca.Create(new Ca
                {
                    CodeLoaiCa = lc.Code,
                    LoaiCa = lc.Name,
                    GioiThieu = lc.GioiThieu

                });

                //await AC.Ca.SetDoiTuong(ca, yn);



                var lg = new Log
                {
                    LoaiLog = LoaiLog.Tao_Ca,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = yn.Id,
                    NoiDung = "Tạo ca cho yếu nhân ",
                    Data = new BsonDocument
                {
                    {"Id",ca.Id },
                    {"LoaiCa",ca.LoaiCa },
                    {"CodeLoaiCa",ca.CodeLoaiCa }
                }
                };


                if (ca.GioiThieu != null) lg.Data.Set("GioiThieu", ca.GioiThieu);

                await AC.Log.Create(lg);

                await ThemLog(yn, lg);

                lg = new Log
                {
                    LoaiLog = LoaiLog.Tao_Ca,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = ca.Id,
                    NoiDung = "Tạo ca cho yếu nhân ",
                    Data = new BsonDocument
                    {
                        {"Id",ca.Id },
                        {"LoaiCa",ca.LoaiCa },
                        {"CodeLoaiCa",ca.CodeLoaiCa }
                    }
                };


                if (ca.GioiThieu != null) lg.Data.Set("GioiThieu", ca.GioiThieu);

                await AC.Log.Create(lg);

                await AC.Ca.ThemLog(ca, lg);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][Them_Ca]:" + ex.Message, ex);
            }


        }


        //public async Task<YeuNhan> Update_Ca(CaRequest model)
        //{
        //    try
        //    {
        //        var yn = await AC.YeuNhan.GetById(model.IdDoiTuong);
        //        var ca = await AC.Ca.GetById(model.Id);

        //        var lg = new Log
        //        {
        //            LoaiLog = LoaiLog.Update_TienIch,
        //            IdNguoiDung = model.IdNguoiTao,
        //            IdDoiTuong = ca.Id,
        //            NoiDung = "Update thông tin ca: ",
        //            Data = new BsonDocument()
        //        };

        //        var lc = await AC.LoaiCa.GetById(model.IdLoaiCa);
        //        if (ca.CodeLoaiCa != lc.Code)
        //        {
        //            lg.NoiDung += "[LoaiCa]";
        //            lg.Data.Set("LoaiCa", lc.Name);
        //            lg.NoiDung += "[CodeLoaiCa]";
        //            lg.Data.Set("CodeLoaiCa", lc.Code);
        //            ca.LoaiCa = lc.Name;
        //            ca.CodeLoaiCa = lc.Code;
        //        }


        //        if (ca.GioiThieu != model.GioiThieu)
        //        {
        //            lg.NoiDung += "[GioiThieu]";
        //            if (model.GioiThieu != null) lg.Data.Set("GioiThieu", model.GioiThieu);
        //            ca.GioiThieu = model.GioiThieu;
        //        }


        //        if (ca.TrangThaiHoSo != model.TrangThai)
        //        {
        //            lg.NoiDung += "[TrangThai]";
        //            if (model.TrangThai != null) lg.Data.Set("TrangThai", model.TrangThai);
        //            ca.TrangThaiHoSo = model.TrangThai;
        //        }

        //        await AC.Log.Create(lg);

        //        //save Update
        //        ca.UpdatedAt = DateTime.Now;
        //        ca.UpdatedBy = model.IdNguoiTao;
        //        await AC.Ca.Update(ca);

        //        //Thêm log
        //        await AC.Ca.ThemLog(ca, lg);

        //        return yn;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Lỗi khi tạo tổ chức [AC_YeuNhan][Update_Ca]:" + ex.Message, ex);
        //    }


        //}
    }
}
