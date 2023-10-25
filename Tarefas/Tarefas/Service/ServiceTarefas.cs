using System.Text.Json;
using Tarefas.Models;

namespace Web.Tarefas.Service;
public class ServiceTarefas : IServiceTarefas
{
    public List<Tarefa> ObterTarefas(DateTime dtinicio, DateTime dtFim)
    {
        using var http = new HttpClient();
        try
        {
            string apiUrl = "https://localhost:44332/listaTarefas";
            var response = http.GetAsync(apiUrl).Result;
            var apiResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<Tarefa>>(apiResponse);
        }
        catch(Exception)
        {
            throw new Exception("erro ao realizar requisição.");
        }
    }
}
