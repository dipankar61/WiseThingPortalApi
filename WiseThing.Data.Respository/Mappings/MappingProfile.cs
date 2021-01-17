using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace WiseThing.Data.Respository
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Device, DeviceDTO>();
            CreateMap<DeviceDTO, User>();
            CreateMap<Userdevice, UserDeviceDTO>();
            CreateMap<UserDeviceDTO, Userdevice>();
        }
    }
}
