using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WiseThing.Data.Respository;

namespace WiseThing.Portal.Business
{ 
   public class DeviceHandler : IDeviceHandler
   {
        private readonly IUserDeviceRepository _userDeviceRepo;
        private readonly IDeviceRepository _devicerepo;
        public DeviceHandler(IUserDeviceRepository userDeviceRepo, IDeviceRepository deviceRepo)
        {
            _userDeviceRepo = userDeviceRepo;
            _devicerepo = deviceRepo;
        }
       public Task<string> AddNewDevice(DeviceDTO device)
       {
        throw new NotImplementedException();
       }
        public async Task EditDeviceWithUserAssociation(UserDeviceAssociation userDevice)
        {
            int userId = 0;
            var deviceId = await _devicerepo.IsDeviceTagExist(userDevice.TagName);
            if (deviceId>0)
            {
                userId = await _devicerepo.GetUserIdbyDeviceId(deviceId);
                if (userId==0)
                {
                    var userdeviceDto = new UserDeviceDTO()
                    {
                        UserId = userDevice.UserId,
                        DeviceId = deviceId

                    };
                   await _devicerepo.EditDevice(userdeviceDto, userDevice.UserName, userDevice.DeviceName);
                }
            }
        }

       
       public async Task<IEnumerable<DeviceDTO>> GetDevicesforUser(int userId)
       {
            return await _devicerepo.GetDevicesByuserId(userId);
       }
  }
}
