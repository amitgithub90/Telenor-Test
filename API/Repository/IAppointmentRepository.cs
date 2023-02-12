using System.Collections.Generic;
using API.Models;
using Microsoft.Extensions.Hosting;

namespace API.Repository
{
    public interface IAppointmentRepository
    {

        Task<List<Appointment>> GetAppointments();
        Task<Appointment> GetAppointment(int? postId);

        Task<int> AddAppointment(Appointment appointment);

        Task<int> DeleteAppointment(int? postId);

        Task UpdateAppointment(Appointment appointment);

        //Task<IEnumerable<Appointment>> GetAppoinments();
        //Task<Appointment> GetAppoinment(int? id);

        //Task<Appointment> PutAppoinment(int? id, Appointment appoinment);

        //Task<Appointment> PostAppoinment(Appointment appoinment);

        //bool DeleteAppoinment(int? id);
    }
}
