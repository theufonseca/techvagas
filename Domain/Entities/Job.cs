using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public string Country { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
