using Microsoft.AspNetCore.Mvc;
using Web.Tarefas.Service;

namespace Web.Tarefas.Controllers;

public class TarefasController: Controller
{
    private readonly IServiceTarefas _service;
    public TarefasController(IServiceTarefas service) => _service = service;
    public ActionResult Index() => View();
    public ActionResult Consultar() => View();
    [HttpGet]
    public JsonResult ObterTarefas(DateTime dtInicio, DateTime dtFim) 
        => new (_service.ObterTarefas(dtInicio, dtFim));
}
