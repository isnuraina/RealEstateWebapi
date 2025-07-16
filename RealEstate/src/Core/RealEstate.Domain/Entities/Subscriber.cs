using RealEstate.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class Subscriber
    {
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Approved { get; set; }
        public DateTime ApprovedAt { get; set; }

    }
}
