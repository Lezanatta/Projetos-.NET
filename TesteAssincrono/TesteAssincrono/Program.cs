Console.WriteLine("Inicio" + DateTime.Now.ToString("HH:mm:ss"));
var texto = await ObterString();
Console.WriteLine("Metodo apos a chamada");
Console.WriteLine("Segundo Metodo apos a chamada");
Console.WriteLine("Segundo Metodo apos a chamada" + texto);


async Task<string> ObterString()
{
    var texto = await ConsultarDados();  
    Console.WriteLine("Terminou" + DateTime.Now.ToString("HH:mm:ss"));
    return texto;
}

async Task<string> ConsultarDados()
{
    Console.WriteLine("Consultando dados");
    await Task.Delay(20000);
    return "texto retornado " + DateTime.Now.ToString("HH:mm:ss");
}