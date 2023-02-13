using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using Web.Models;

namespace Web.Controllers
{
    public class AppointmentDtlsController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        AppointmentDetails _appointmentDetail = new AppointmentDetails();
        List<AppointmentDetails> _appointmentdtls = new List<AppointmentDetails>();
        public IActionResult Index()
        {
            return View();
        }

        //public JsonResult UploadAppointments(List<AppointmentDetails> _appointmentdtls)
        //{
        //    _Ap
        //}


        [HttpGet]

        public async Task <List<AppointmentDetails>> GetAppointmentDetails()
        {
            _appointmentdtls = new List<AppointmentDetails>();
            using(var httpClient = new HttpClient(_clientHandler))
            
            {
                httpClient.BaseAddress = new Uri("https://localhost:44372");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                

                using (var response = await httpClient.GetAsync("/api/GetAppointments")) 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _appointmentdtls = JsonConvert.DeserializeObject<List<AppointmentDetails>>(apiResponse);

                }
            }

            return _appointmentdtls;
        }

        [HttpGet]

        public async Task<AppointmentDetails> GetAppointment(int appId)
        {
            _appointmentDetail = new AppointmentDetails();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                httpClient.BaseAddress = new Uri("https://localhost:44372");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await httpClient.GetAsync("api/GetAppointment?appId=" + appId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _appointmentDetail = JsonConvert.DeserializeObject<AppointmentDetails>(apiResponse);

                }
            }

            return _appointmentDetail;
        }

        [HttpPost]

        public async Task<AppointmentDetails> AddUpdateAppointment(AppointmentDetails appointmentDetails)
        {
            _appointmentDetail = new AppointmentDetails();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                httpClient.BaseAddress = new Uri("https://localhost:44372");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(appointmentDetails),Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("/api/CreateAppointment", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _appointmentDetail = JsonConvert.DeserializeObject<AppointmentDetails>(apiResponse);

                }
            }

            return _appointmentDetail;
        }

        [HttpDelete]

        public async Task<string> DeleteAppointment(int appId)
        {
            string message = "";
            using (var httpClient = new HttpClient(_clientHandler))
            {
                httpClient.BaseAddress = new Uri("https://localhost:44372");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await httpClient.DeleteAsync("/api/RemoveAppointment?appId=" + appId))

                {
                    message = await response.Content.ReadAsStringAsync();

                }
            }

            return message;
        }


        [HttpPost]

        public async Task<AppointmentDetails> UploadAllAppointments(AppointmentDetails appointmentDetails)
        {
            _appointmentDetail = new AppointmentDetails();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                httpClient.BaseAddress = new Uri("https://localhost:44372");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(appointmentDetails), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("/api/UploadAppointments", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _appointmentDetail = JsonConvert.DeserializeObject<AppointmentDetails>(apiResponse);

                }
            }

            return _appointmentDetail;
        }


    }
}
