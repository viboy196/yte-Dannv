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
    public class AC_Forum
    {

        private readonly IForumRepository _ForumRepository;

        private readonly IUnitOfWork _uow;

        public AC_Forum(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _ForumRepository = services.GetRequiredService<IForumRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _ForumRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Forum][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<Forum> Create(Forum tc)
        {
            try
            {
                _ForumRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Forum][Create]:" + ex.Message, ex);
            }

        }

        public async Task<Forum> Update(Forum ltc)
        {
            try
            {
                _ForumRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Forum][Update]:" + ex.Message, ex);
            }

        }

        public async Task<Forum> GetById(string id)
        {
            try
            {
                return await _ForumRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Forum][GetById]:" + ex.Message, ex);
            }

        }

        public async Task<List<Forum>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<Forum>() : (List<Forum>)(await _ForumRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Forum][Get]:" + ex.Message, ex);
            }

        }


        //---------------------------
        public async Task ThemLog(Forum tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Forum][ThemLog]:" + ex.Message, ex);
            }
        }

        //-------------------------------


    }
}
