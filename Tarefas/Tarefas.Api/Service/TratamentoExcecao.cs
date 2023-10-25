using Biblioteca.Tarefas.Exceptions;

namespace Tarefas.Api.Service
{
    public class TratamentoExcecao
    {
        private const int _notExisteExcecao = 0;
        private const int _existeExcecao = 1;
        public string ?Descricao { get; set; }
        public int IcExcecao { get; set; }
        public Object ? Resultado { get; set; }
        public static TratamentoExcecao TratarExcecaoTarefaException<T>(Func<T> func)
        {
            try
            {
                var resultado = func.Invoke();
                return new TratamentoExcecao()
                {
                    Descricao = string.Empty,
                    IcExcecao = _notExisteExcecao,
                    Resultado = resultado
                };

            }catch(TarefaException e)
            {
                return new TratamentoExcecao()
                {
                    Descricao = e.Message,
                    IcExcecao = _existeExcecao,
                };
            }
        } 
        public static TratamentoExcecao TratarExcecaoTarefaException(Action action)
        {
            try
            {
                action.Invoke();
                return new TratamentoExcecao()
                {
                    Descricao = string.Empty,
                    IcExcecao = _notExisteExcecao,
                };
            }catch(CdTarefaException e)
            {
                return new TratamentoExcecao()
                {
                    Descricao = e.Message,
                    IcExcecao = _existeExcecao,
                };
            }
            catch(DataBaseException e)
            {
                return new TratamentoExcecao()
                {
                    Descricao = e.Message,
                    IcExcecao = _existeExcecao,
                };
            }
        }
    }
}
