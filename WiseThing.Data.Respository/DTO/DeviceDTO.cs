using System;
using System.Collections.Generic;
using System.Text;

namespace WiseThing.Data.Respository
{
    public class DeviceDTO
    {
        public int DeviceId { get; set; }
        public string DeviceUniqueIdentifier { get; set; }
        public string DeviceTagName { get; set; }
        public DateTime InputDate { get; set; }
        public string InputBy { get; set; }
    }
}
