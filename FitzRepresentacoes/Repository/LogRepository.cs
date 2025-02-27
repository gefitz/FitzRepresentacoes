using FitzRepresentacoes.Context;
using FitzRepresentacoes.Models;

namespace FitzRepresentacoes.Repository
{
    public class LogRepository
    {
        private readonly AppDbContext _context;
        private readonly ReturnModel _ret;

        public LogRepository(AppDbContext context, ReturnModel ret)
        {
            _context = context;
            _ret = ret;
        }

        public void Error(string message, bool SalvarLog)
        {
            LogModel logModel = new LogModel();
            if (!string.IsNullOrEmpty(message)) { logModel.Messagem = message; }
            if (SalvarLog)
            {
                logModel.InnerExecption = "";
                logModel.dthErro = DateTime.Now;
                _context.Logs.Add(logModel);
                _context.SaveChanges();
            }
            _ret.Menssagem = message;

        }
        public void Error(Exception exception)
        {
            LogModel logModel = new LogModel();
            if (exception != null)
            {
                logModel.Messagem = exception.Message;
                logModel.InnerExecption = "";
                if (exception.InnerException != null)
                    logModel.InnerExecption = exception.InnerException.ToString();

                logModel.dthErro = DateTime.Now;
                _context.Logs.Add(logModel);
                _context.SaveChanges();
                _ret.Menssagem = exception.Message;
            }
        }
    }
}
