using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CabeleleilaLeila.Web.Controllers;

public class SchedulingController(ISchedulingServiceClient schedulingServiceClient) : Controller
{
    private readonly ISchedulingServiceClient _schedulingServiceClient = schedulingServiceClient;

    public async Task<IActionResult> Index()
    {
        var response = await _schedulingServiceClient.GetAll();

        if (!response.Success)
        {
            TempData["ErrorMessage"] = response.ErrorMessage;
            return View(new List<OutputScheduling>());
        }

        var listScheduling = response.Data ?? [];

        var schedulingsByPage = listScheduling.OrderByDescending(a => a.DateTime).ToList();

        return View(schedulingsByPage);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(InputCreateScheduling inputCreate)
    {
        if (!ModelState.IsValid)
            return View(inputCreate);

        var response = await _schedulingServiceClient.Create(inputCreate);

        if (response.Success)
            return RedirectToAction("Index");

        TempData["ErrorMessage"] = response.ErrorMessage ?? "Erro ao criar agendamento.";
        return View(inputCreate);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var response = await _schedulingServiceClient.GetById(id);

        if (!response.Success || response.Data == null)
            return NotFound();

        var scheduling = response.Data;
        //var model = new InputUpdateScheduling(scheduling.Description!);

        ViewBag.Id = id;
        //ViewBag.Name = scheduling.Name;
        return View(/*model*/);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, InputUpdateScheduling inputUpdate)
    {
        if (!ModelState.IsValid)
            return View(inputUpdate);

        var response = await _schedulingServiceClient.Update(id, inputUpdate);

        if (response.Success)
            return RedirectToAction("Index");

        TempData["ErrorMessage"] = response.ErrorMessage ?? "Erro ao atualizar o agendamento.";
        return View(inputUpdate);
    }
}