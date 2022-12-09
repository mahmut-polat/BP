using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Domain.Common
{
    public interface IEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
