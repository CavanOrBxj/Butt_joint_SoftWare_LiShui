using System;

namespace GRPlatForm
{
    [Serializable]
    public class DeviceInfoReport
    {
        public string RPTStartTime;

        public string RPTEndTime;

        public Device Device;
    }

    public class Device
    {
        public string DeviceID;

        public string DeviceCategory;

        public string DeviceType;

        public string DeviceName;

        public string AreaCode;

        public string AdminLevel;

        public string DeviceState;
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude;
        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude;
    }

}
