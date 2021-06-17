using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sample.Domain.SeedWork
{
    public class Entity<TKey> : IAggregateRoot
    {
        [Key]
        public TKey Id { get; private set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
