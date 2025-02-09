using FitzRepresentacoes.Context;
using FitzRepresentacoes.Models;

namespace FitzRepresentacoes.Repository
{
    public class LogRepository
    {
        private readonly LogModel _logModel;
        private readonly AppDbContext _context;

        public LogRepository(LogModel logModel, AppDbContext context)
        {
            _logModel = logModel;
            _context = context;
        }

        public void Error(string message, bool SalvarLog)
        {
            if (!string.IsNullOrEmpty(message)) { _logModel.Messagem = message; }
            if (SalvarLog)
            {
                _logModel.InnerExecption = "";
                _logModel.dthErro = DateTime.Now;
                _context.Logs.Add(_logModel);
                _context.SaveChanges();
            }

        }
        public void Error(Exception exception)
        {
            if (exception != null)
            {
                _logModel.Messagem = exception.Message;
                _logModel.InnerExecption = "";
                if (exception.InnerException != null)
                    _logModel.InnerExecption = exception.InnerException.ToString();

                _logModel.dthErro = DateTime.Now;
                _context.Logs.Add(_logModel);
                _context.SaveChanges();
            }
        }
    }
}
