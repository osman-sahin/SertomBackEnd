using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Shared
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public int Status { get; set; }


        public ResponseModel(string message = "", bool success = false, int status = 400)
        {
            this.Message = message;
            this.Status = status;
            this.Success = success;
        }

    }
}
