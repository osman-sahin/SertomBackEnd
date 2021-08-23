using Core.IServices;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Enum;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class LogService : ILogService
    {
        #region Fields


        private readonly ILogger _logger;
        private readonly MedyanaDbContext _dbContext;

        #endregion

        #region Ctor

        public LogService(ILogger<LogService> logger, MedyanaDbContext dbContext)
        {
            this._logger = logger;
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public void Error(string message)
        {
            Log log = new Log() {
                Text = message,
                Type = LogTypes.Error,
                Date = DateTime.Now
            };

            LogCreate(log);
        }

        public void Info(string message)
        {
            Log log = new Log()
            {
                Text = message,
                Type = LogTypes.Error,
                Date = DateTime.Now
            };

            LogCreate(log);
        }

        public async void LogCreate(Log log)
        {
            await _dbContext.Logs.AddAsync(log);
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
