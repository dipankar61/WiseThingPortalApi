using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WiseThing.Data.Respository;

namespace WiseThing.Portal.Business
{
    public interface IDeviceHandler
    {
        Task EditDeviceWithUserAssociation(UserDeviceAssociation userDevice);
        Task<string> AddNewDevice(DeviceDTO device);
        Task<IEnumerable<DeviceDTO>> GetDevicesforUser(int userId);

    }
}
