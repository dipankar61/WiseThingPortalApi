using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseThing.Data.Respository;
using WiseThing.Portal.Business;



namespace WiseThingPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceHandler _deviceHandler;
        public DeviceController(IDeviceHandler deviceHandler)
        {
            _deviceHandler = deviceHandler;
        }
        

        
        [HttpGet("{userId}")]
        public async Task<IEnumerable<DeviceDTO>> GetListOfDevicesForUser(int userId)
        {
            return await _deviceHandler.GetDevicesforUser(userId);
        }


        [HttpPost]
        public async Task<string> AddNewDevice([FromBody] DeviceDTO device)
        {
            return await _deviceHandler.AddNewDevice(device);
        }

        [HttpPost]
        public async Task<DeviceAssociationResult> AddDeviceToUser([FromBody] UserDeviceAssociation userDevice)
        {
            return await _deviceHandler.EditDeviceWithUserAssociation(userDevice);
        }

       
    }
}
