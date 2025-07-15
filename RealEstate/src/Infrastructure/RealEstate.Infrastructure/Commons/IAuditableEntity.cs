using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Commons
{
    public interface IAuditableEntity
    {
        DateTime CreateAt { get; set; }
        int? CreatedBy { get; set; }
        DateTime? LastModifiedAt { get; set; }
        int? LastModifiedBy { get; set; }
        DateTime? DeleteAt { get; set; }
        int? DeletedBy { get; set; }
    }
}
