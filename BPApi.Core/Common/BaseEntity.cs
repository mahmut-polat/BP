using System;

namespace BPApi.Domain.Common
{
    public class BaseEntity : IEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
