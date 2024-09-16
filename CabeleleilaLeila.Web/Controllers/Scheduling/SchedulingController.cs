﻿using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CabeleleilaLeila.Web.Controllers;

public class SchedulingController(ISchedulingServiceClient schedulingServiceClient, Helpers.ISession session) : Controller
{
    private readonly ISchedulingServiceClient _schedulingServiceClient = schedulingServiceClient;
    private readonly Helpers.ISession _session = session;

    public async Task<IActionResult> Index()
    {
        var response = await _schedulingServiceClient.GetAll();

        if (!response.Success)
        {
            TempData["ErrorMessage"] = response.ErrorMessage;
            return View(new List<OutputScheduling>());
        }

        var listScheduling = response.Data?.OrderByDescending(a => a.DateTime).ToList() ?? [];
        var user = _session.GetUserSession()!;

        if(user.Type == EnumTypeUser.Default)
            listScheduling = listScheduling.Where(x => x.UserId == user.Id).Select(x => x).ToList();

        ViewBag.UserType = user.Type;

        return View(listScheduling);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.UserId = _session.GetUserSession()!.Id;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(InputCreateScheduling inputCreate)
    {
        if (!ModelState.IsValid)
            return View(inputCreate);

        var response = await _schedulingServiceClient.Create(inputCreate);

        if (response.Success)
        {
            TempData["SuccessMessage"] = "Agendamento criado com sucesso. Aguarde a confirmação da Leila.";
            return RedirectToAction("Index");
        }

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
        var model = new InputUpdateScheduling(scheduling.DateTime!.Value, scheduling.Service, scheduling.Observation);

        ViewBag.Id = id;
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, InputUpdateScheduling inputUpdate)
    {
        if (!ModelState.IsValid)
            return View(inputUpdate);

        var response = await _schedulingServiceClient.Update(id, inputUpdate);

        if (response.Success)
        {
            TempData["SuccessMessage"] = "Agendamento atualizado com sucesso.";
            return RedirectToAction("Index");
        }

        TempData["ErrorMessage"] = response.ErrorMessage ?? "Erro ao atualizar o agendamento.";
        return View(inputUpdate);
    }

    [HttpGet]
    public async Task<IActionResult> Confirm(long id)
    {
        if (!ModelState.IsValid)
            return View();

        var response = await _schedulingServiceClient.Confirm(id);

        if (response.Success)
        {
            TempData["SuccessMessage"] = "Agendamento confirmado com sucesso.";
            return RedirectToAction("Index");
        }

        TempData["ErrorMessage"] = response.ErrorMessage ?? "Erro ao confirmar agendamento.";
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> View(int id)
    {
        var response = await _schedulingServiceClient.GetById(id);

        if (!response.Success || response.Data == null)
            return NotFound();

        var scheduling = response.Data;

        ViewBag.Id = id;
        return View(scheduling);
    }
}