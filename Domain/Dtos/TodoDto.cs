using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string? TodoName { get; set; }
        public Status Status { get; set; }
        public string StatusName { get { return Status.ToString(); } }
    }
    public enum Status
    {
        Todo = 1,
        InProgres = 2,
        Complete = 3,
    }
}
