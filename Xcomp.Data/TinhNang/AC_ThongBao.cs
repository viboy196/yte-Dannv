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
    public class AC_ThongBao
    {
        
        private readonly IThongBaoRepository _ThongBaoRepository;

        private readonly IUnitOfWork _uow;

        public AC_ThongBao(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _ThongBaoRepository = services.GetRequiredService<IThongBaoRepository>();

        }

        public async Task RemoveAll()
        {
            _ThongBaoRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<ThongBao> Create(ThongBao ltc)
        {
            _ThongBaoRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<ThongBao> Update(ThongBao ltc)
        {
            _ThongBaoRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<ThongBao> GetById(string id)
        {   
            return await _ThongBaoRepository.GetByIdAsync(id);
        }

        public async Task<List<ThongBao>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<ThongBao>() : (List<ThongBao>)(await _ThongBaoRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }


        //---------------------------

        public async Task XuLyThongBao(string idtb, string luachon)
        {
            var tb = await AC.ThongBao.GetById(idtb);
            if (tb.Loai == LoaiThongBao.Tao_NhanVien)
            {
                tb.DaXuLy = true;

                var nv = await AC.NhanVien.GetById(tb.IdDoiTuongNhan);

                if (luachon == "Chấp nhận")
                {
                    tb.KetQua = "Chấp nhận lời mời";
                    nv.TrangThai_NhanVienTraLoi = TrangThaiNhanVien_NhanVienTraLoi.ChapNhan;
                    nv.TrangThai_NhanVienLamViec = TrangThaiNhanVien_NhanVienLamViec.DangLamViec;
                }
                else
                if (luachon == "Từ chối")
                {
                    tb.KetQua = "Từ chối lời mời";
                    nv.TrangThai_NhanVienTraLoi = TrangThaiNhanVien_NhanVienTraLoi.TuChoi;
                }
                tb.DaXuLy = true;

                var nd = await AC.NguoiDung.GetById(nv.IdNguoiDung);
                var lg = await AC.Log.Create(new Log
                {
                    LoaiLog = LoaiLog.Tao_NhanVien,
                    IdDoiTuong = nv.Id,
                    IdNguoiDung = nv.IdNguoiDung,
                    NoiDung = nd.Name + " " + tb.KetQua + " trở thành nhân viên",
                    Data = new BsonDocument { { "IdThongBao", tb.Id } }
                });
                await AC.NhanVien.ThemLog(nv, lg);

                await AC.ThongBao.Update(tb);
                await AC.NhanVien.Update(nv);
            }
            else
            if (tb.Loai == LoaiThongBao.Tao_CongViec)
            {
                tb.DaXuLy = true; tb.DaDoc = true;

                var cv = await AC.CongViec.GetById(tb.IdDoiTuongNhan);

                if (luachon == "Chấp nhận")
                {
                    tb.KetQua = "Chấp nhận lời mời";
                    cv.TrangThai_NhanVienTraLoi = TrangThaiNhanVien_NhanVienTraLoi.ChapNhan;
                    cv.TrangThai_NhanVienLamViec = TrangThaiNhanVien_NhanVienLamViec.DangLamViec;
                }
                else
                if (luachon == "Từ chối")
                {
                    tb.KetQua = "Từ chối lời mời";
                    cv.TrangThai_NhanVienTraLoi = TrangThaiNhanVien_NhanVienTraLoi.TuChoi;
                }
                tb.DaXuLy = true; tb.DaDoc = true;

                var nv = await AC.NhanVien.GetById(cv.IdNhanVien);
                var lg = await AC.Log.Create(new Log
                {
                    LoaiLog = LoaiLog.Tao_CongViec,
                    IdDoiTuong = cv.Id,
                    IdNguoiDung = nv.IdNguoiDung,
                    NoiDung = nv.Name + " " + tb.KetQua + " trở thành nhân viên",
                    Data = new BsonDocument { { "IdThongBao", tb.Id } }
                });
                await AC.CongViec.ThemLog(cv, lg);


                await AC.ThongBao.Update(tb);
                await AC.CongViec.Update(cv);



            }
        }

    }
}
