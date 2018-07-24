using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GrupArGe.SmartPower.WebApi.Controllers
{
    [RoutePrefix("api/Devices")]
    public class DevicesController : BaseController
    {
        /// <summary>
        /// Kullanıcı cihazlarını getirir
        /// </summary>
        [Route("MyDevices")]
        [HttpGet]
        public HttpResponseMessage MyDevices()
        {
            result.Data = dbContext.SelectQuery<ModelDevice>("SELECT measuring_settings.id as meaasuring_device_id,measuring_settings.measuring_device_id AS measuring_device_id,measuring_settings.location_name AS location_name,measuring_settings.last_packet_time AS measuring_last_packet_time,measuring_settings.comm_device_id AS comm_device_id,comm_settings.last_packet_time AS comm_last_packet_time FROM user_device usr_device INNER JOIN measuring_device_settings measuring_settings ON measuring_settings.measuring_device_id = usr_device.device_id INNER JOIN comm_device_settings comm_settings ON comm_settings.comm_device_id = measuring_settings.comm_device_id WHERE usr_device.user_id =@id", new { id = this.UserId });
            result.IsSuccess = true;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        /// <summary>
        /// Bütün Cihazları Getirir
        /// </summary>
        [Route("AllDevices")]
        [HttpGet]      
        public HttpResponseMessage AllDevices()
        {
            result.Data = dbContext.SelectQuery<ModelDevice>("SELECT measuring_settings.id as meaasuring_device_id,measuring_settings.measuring_device_id AS measuring_device_id,measuring_settings.location_name AS location_name,measuring_settings.last_packet_time AS measuring_last_packet_time,measuring_settings.comm_device_id AS comm_device_id,comm_settings.last_packet_time AS comm_last_packet_time FROM user_device usr_device INNER JOIN measuring_device_settings measuring_settings ON measuring_settings.measuring_device_id = usr_device.device_id INNER JOIN comm_device_settings comm_settings ON comm_settings.comm_device_id = measuring_settings.comm_device_id");
            result.IsSuccess = true;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        /// <summary>
        /// Cihaz Kategorilerini Getirir
        /// </summary>
        /// <returns></returns>
        [Route("GetDeviceCategory")]
        [HttpGet]
        public HttpResponseMessage GetDeviceCategory()
        {
            result.Data = dbContext.SelectQuery<ModelCategory>("SELECT * FROM device_categories");
            result.IsSuccess = true;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        /// <summary>
        /// Cihaz Tiplerini Getirir
        /// </summary>
        [Route("GetDeviceType")]
        [HttpGet]
        public HttpResponseMessage GetDeviceType()
        {
            result.Data = dbContext.SelectQuery<ModelDeviceType>("SELECT * FROM device_type");
            result.IsSuccess = true;
            return Request.CreateResponse(HttpStatusCode.OK,result);
        }
    }
    public class ModelDevice
    {
        //MyDevices , GetAllDevices
        public int meaasuring_device_id { get; set; }
        public string measuring_device_id { get; set; }
        public string location_name { get; set; }
        public DateTime measuring_last_packet_time { get; set; }
        public string comm_device_id { get; set; }
        public DateTime comm_last_packet_time { get; set; }
    }
    public class ModelCategory
    {
        //GetDeviceCategory
        public int device_category { get; set; }
        public string device_category_name { get; set; }
    }
    public class ModelDeviceType
    {
        //GetDeviceType
        public int id { get; set; }
        public string device_name { get; set; }
        public string device_type_code { get; set; }
        public int device_category { get; set; }
        public string stage_svc_count { get; set; }
        public string supported_alarm_types { get; set; }
        public string protocol { get; set; }
        public int protocol_id { get; set; }
        public int order { get; set; }
    }
}
