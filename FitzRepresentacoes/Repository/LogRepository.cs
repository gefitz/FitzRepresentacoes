using FitzRepresentacoes.Context;
using FitzRepresentacoes.Models;

namespace FitzRepresentacoes.Repository
{
    public class LogRepository
    {
        private readonly AppDbContext _context;
        private readonly LogModel _log;

        public LogRepository(AppDbContext context, LogModel log)
        {
            _context = context;
            _log = log;
        }

        public void Error(string message, bool SalvarLog)
        {
            if (!string.IsNullOrEmpty(message)) { _log.Messagem = message; }
            if (SalvarLog)
            {
                _log.InnerExecption = "";
                _log.dthErro = DateTime.Now;
                _context.Logs.Add(_log);
                _context.SaveChanges();
            }
            _log.Messagem = message;
            

        }
        public void Error(Exception exception)
        {
            if (exception != null)
            {
                _log.Messagem = exception.Message;
                _log.InnerExecption = "";
                if (exception.InnerException != null)
                    _log.InnerExecption = exception.InnerException.ToString();

                _log.dthErro = DateTime.Now;
                _context.Logs.Add(_log);
                _context.SaveChanges();
                _log.Messagem = exception.Message;
            }
        }
    }
}
