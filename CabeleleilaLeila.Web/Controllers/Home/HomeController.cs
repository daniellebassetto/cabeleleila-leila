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
        var userType = _session.GetUserSession()!.Type;
        ViewBag.UserType = userType;

        if (userType == EnumTypeUser.Admin)
        {
            var allAppointments = await _schedulingServiceClient.GetAll();
            var allAppointmentsData = allAppointments.Data;

            var appointmentsByDay = allAppointmentsData?
                .GroupBy(a => a.DateTime!.Value.Date)
                .Select(g => new { Date = g.Key.ToShortDateString(), Count = g.Count() })
                .OrderBy(x => x.Date)
                .ToList();

            var confirmedCount = allAppointmentsData?.Count(a => a.Status == EnumStatusScheduling.Confirmed) ?? 0;
            var notConfirmedCount = allAppointmentsData?.Count(a => a.Status == EnumStatusScheduling.WaitingConfirmation) ?? 0;

            ViewData["AppointmentsByDay"] = appointmentsByDay;
            ViewData["ConfirmedCount"] = confirmedCount;
            ViewData["NotConfirmedCount"] = notConfirmedCount;
        }

        return View();
    }
}