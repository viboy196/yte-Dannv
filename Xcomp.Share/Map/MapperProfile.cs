using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Domain;
using Xcomp.Share.Models;

namespace Xcomp.Share.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NguoiDung, UserModel>().ReverseMap();

            CreateMap<NguoiDung, CreateUserModel>().ReverseMap();

            CreateMap<NhanVien, NhanVienModel>().ReverseMap();

            CreateMap<Device, DeviceModel>().ReverseMap();
            
            CreateMap<Device, DeviceSendModel>().ReverseMap();

            CreateMap<App, AppModel>().ReverseMap();



        }
    }
}
