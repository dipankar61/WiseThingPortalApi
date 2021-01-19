﻿using Microsoft.AspNetCore.Http;
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
        

        
        [HttpGet]
        [Route("DeviceList/{userId}")]
        public async Task<ActionResult<IEnumerable<DeviceDTO>>> GetListOfDevicesForUser(int userId)
        {
            try
            {
                var response= await _deviceHandler.GetDevicesforUser(userId);
                if (response != null && response.Count() > 0)
                    return Ok(response);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        [Route("AddDevice")]
        public async Task<ActionResult<string>> AddNewDevice([FromBody] DeviceDTO device)
        {
            try
            {
                if (device != null)
                {
                    var deviceTag= await _deviceHandler.AddNewDevice(device);
                    return Ok(deviceTag);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("UserDeviceAssociation")]
        public async Task<ActionResult<DeviceAssociationResult>> AddDeviceToUser([FromBody] UserDeviceAssociation userDevice)
        {
            try
            {
                if (userDevice != null && userDevice.UserId!=0 && !string.IsNullOrEmpty(userDevice.TagName) && !string.IsNullOrEmpty(userDevice.DeviceName))
                    return Ok(await _deviceHandler.EditDeviceWithUserAssociation(userDevice));
                else
                    return BadRequest();
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

       
    }
}
