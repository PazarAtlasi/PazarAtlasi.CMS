using System;

namespace PazarAtlasi.CMS.Domain.Common
{
    public abstract class Entity<T>
    {
        public T? Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Status Status { get; set; } = Status.Draft;
    }
}