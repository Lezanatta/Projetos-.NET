namespace ApiNova.Pagination
{
    public abstract class QueryStringParameters
    {
        //Numero da pagina que irá exibir as informações
        public int PageNumber { get; set; } = 1;
        //Maximo de retorno de informações
        public int MaxPageSize = 50;
        //O numero de páginas que será exibido
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
