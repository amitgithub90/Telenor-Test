using API.Database;
using API.Models;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace API.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        AppointmentDbContext _db;
        public AppointmentRepository(AppointmentDbContext db)
        {
            _db = db;
        }

        public async Task<List<Appointment>> GetAppointments()
        {
            if (_db != null)
            {
                return await _db.Appoinments.ToListAsync();
            }

            return null;
        }

       

        public async Task<Appointment> GetAppointment(int? AppId)
        {
            if (_db != null)
            {
                return await (from p in _db.Appoinments
                              where p.AppId == AppId
                              select new Appointment
                              {
                                  AppId = p.AppId,
                                  Name = p.Name,
                                  Email = p.Email,
                                  PhoneNo = p.PhoneNo,
                                  StartDate = p.StartDate,
                                  EndDate = p.EndDate,
                                  Date = p.Date
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<int> AddAppointment(Appointment appointment)
        {
            if (_db != null)
            {
                await _db.Appoinments.AddAsync(appointment);
                await _db.SaveChangesAsync();

                return appointment.AppId;
            }

            return 0;
        }

        public async Task<int> DeleteAppointment(int? AppId)
        {
            int result = 0;

            if (_db != null)
            {
                //Find the post for specific post id
                var post = await _db.Appoinments.FirstOrDefaultAsync(x => x.AppId == AppId);

                if (post != null)
                {
                    //Delete that Appoinments
                    _db.Appoinments.Remove(post);

                    //Commit the transaction
                    result = await _db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }


        public async Task UpdateAppointment(Appointment appointment)
        {
            if (_db != null)
            {
                //Delete that Appoinments
                _db.Appoinments.Update(appointment);

                //Commit the transaction
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Appointment>> UploadAppointments(List<Appointment> appointment)
        {
            _db.BulkInsert(appointment);
            return appointment;
        }
    }
}
