using Infrastructure.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public LogTypes Type { get; set; }
        public DateTime Date { get; set; }
    }
}
