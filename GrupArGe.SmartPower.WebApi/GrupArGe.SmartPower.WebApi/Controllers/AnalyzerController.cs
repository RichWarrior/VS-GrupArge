using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GrupArGe.SmartPower.WebApi.Controllers
{
    [RoutePrefix("api/Analyzer")]
    public class AnalyzerController : BaseController
    {
        /// <summary>
        /// Kullanıcıların Analizörlerini Getirir
        /// </summary>
        [Route("MyDevices")]
        [HttpGet]
        public HttpResponseMessage MyDevices()
        {
            result.Data = dbContext.SelectQuery<ModelAnalyzer>("SELECT mds.id, mds.location_name,  GREATEST(mds.capacitive_ratio, mds.inductive_ratio) AS max_of_ratio, mds.last_demand_value, mds.capacitive_ratio, mds.inductive_ratio, mds.comm_device_id, mds.measuring_device_id, mds.date_entry, mds.payment_date, mds.day_of_invoice, mds.ct_ratio, mds.vt_ratio, mds.bill_amount, mds.payment_state, mds.tesisat_no, mds.time_diff, mds.is_meter_time_wrong, mds.has_load_profile_data, mds.last_packet_time, mds.has_instant_values_data, mds.has_harmonic_data, mds.has_sms_service, mds.meter_type_code, mds.sozlesme_gucu, cds.id AS cds_id,   cds.communication_type AS cds_communication_type, cds.location_name AS cds_location_name,cds.data_read_period AS cds_data_read_period, cds.sw_version AS cds_sw_version,cds.last_packet_time AS cds_last_packet_time, cds.iccid FROM measuring_device_settings AS mds JOIN comm_device_settings AS cds ON mds.comm_device_id = cds.comm_device_id JOIN device_type ON device_type.device_type_code = mds.device_type JOIN user_device usr ON usr.device_id = mds.measuring_device_id WHERE 1 = 1 AND device_type.device_category = @category_id AND usr.user_id = @user_id ORDER BY max_of_ratio DESC", new { category_id = 3, user_id = UserId });
            result.IsSuccess = true;
            return Request.CreateResponse(System.Net.HttpStatusCode.OK,result);
        }
        /// <summary>
        /// Bütün Analizörleri Getirir
        /// </summary>
        [Route("AllDevices")]
        [HttpGet]
        public HttpResponseMessage AllDevices()
        {
            result.Data = dbContext.SelectQuery<ModelAnalyzer>("SELECT mds.id, mds.location_name,  GREATEST(mds.capacitive_ratio, mds.inductive_ratio) AS max_of_ratio, mds.last_demand_value, mds.capacitive_ratio, mds.inductive_ratio, mds.comm_device_id, mds.measuring_device_id, mds.date_entry, mds.payment_date, mds.day_of_invoice, mds.ct_ratio, mds.vt_ratio, mds.bill_amount, mds.payment_state, mds.tesisat_no, mds.time_diff, mds.is_meter_time_wrong, mds.has_load_profile_data, mds.last_packet_time, mds.has_instant_values_data, mds.has_harmonic_data, mds.has_sms_service, mds.meter_type_code, mds.sozlesme_gucu, cds.id AS cds_id,   cds.communication_type AS cds_communication_type, cds.location_name AS cds_location_name,cds.data_read_period AS cds_data_read_period, cds.sw_version AS cds_sw_version,cds.last_packet_time AS cds_last_packet_time, cds.iccid FROM measuring_device_settings AS mds JOIN comm_device_settings AS cds ON mds.comm_device_id = cds.comm_device_id JOIN device_type ON device_type.device_type_code = mds.device_type JOIN user_device usr ON usr.device_id = mds.measuring_device_id WHERE 1 = 1 AND device_type.device_category = @category_id ORDER BY max_of_ratio DESC", new { category_id = 3 });
            result.IsSuccess = true;
            return Request.CreateResponse(System.Net.HttpStatusCode.OK,result);
        }
    }
    public class ModelAnalyzer
    {
        public int id { get; set; }
        public string location_name { get; set; }
        public double max_of_ratio { get; set; }
        public double last_demand_value { get; set; }
        public double capacitive_ratio { get; set; }
        public double inductive_ratio { get; set; }
        public string comm_device_id { get; set; }
        public string measuring_device_id { get; set; }
        public DateTime date_entry { get; set; }
        public DateTime payment_date { get; set; }
        public int day_of_invoice { get; set; }
        public int ct_ratio { get; set; }
        public int vt_ratio { get; set; }
        public double bill_amount { get; set; }
        public string payment_state { get; set; }
        public string tesisat_no { get; set; }
        public int time_diff { get; set; }
        public bool is_meter_time_wrong { get; set; }
        public bool has_load_profile_data { get; set; }
        public DateTime? last_packet_time { get; set; }
        public bool has_instant_values_data { get; set; }
        public bool has_harmonic_data { get; set; }
        public bool has_sms_service { get; set; }
        public string meter_type_code { get; set; }
        public int sozlesme_gucu { get; set; }
        public int cds_id { get; set; }
        public string cds_communication_type { get; set; }
        public string cds_location_name { get; set; }
        public int cds_data_read_period { get; set; }
        public string cds_sw_version { get; set; }
        public DateTime? cds_last_packet_time { get; set; }
        public string iccid { get; set; }
    }
}