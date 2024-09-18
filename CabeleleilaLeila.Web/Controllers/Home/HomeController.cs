using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CabeleleilaLeila.Web.Controllers;

public class HomeController(ISchedulingServiceClient schedulingServiceClient, Helpers.ISession session) : Controller
{
    private readonly ISchedulingServiceClient _schedulingServiceClient = schedulingServiceClient;
    private readonly Helpers.ISession _session = session;

    public async Task<IActionResult> Index()
    {
        var userType = _session.GetUserSession()?.Type;
        ViewBag.UserType = userType;

        if (userType == EnumTypeUser.Admin)
        {
            var allAppointmentsResponse = await _schedulingServiceClient.GetAll();
            var allAppointmentsData = allAppointmentsResponse.Data;

            var today = DateTime.Today;
            var startDateOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
            var endDateOfWeek = startDateOfWeek.AddDays(6); 

            var appointmentsThisWeek = allAppointmentsData?
                .Where(a => a.DateTime.HasValue && a.DateTime.Value.Date >= startDateOfWeek && a.DateTime.Value.Date <= endDateOfWeek)
                .ToList();

            var appointmentsByDay = appointmentsThisWeek?
                .GroupBy(a => a.DateTime!.Value.Date)
                .Select(g => new { Date = g.Key.ToShortDateString(), Count = g.Count() })
                .OrderBy(x => x.Date)
                .ToList();

            var confirmedCount = appointmentsThisWeek?.Count(a => a.Status == EnumStatusScheduling.Confirmed) ?? 0;
            var notConfirmedCount = appointmentsThisWeek?.Count(a => a.Status == EnumStatusScheduling.WaitingConfirmation) ?? 0;

            ViewData["AppointmentsByDay"] = appointmentsByDay;
            ViewData["ConfirmedCount"] = confirmedCount;
            ViewData["NotConfirmedCount"] = notConfirmedCount;
        }

        return View();
    }
}