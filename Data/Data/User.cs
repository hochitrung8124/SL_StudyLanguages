using Data.Data;
using System;

namespace Data.Data
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateOnly CreatedAtUser { get; set; }
        public virtual ICollection<VocabularyItem> VocabularyItems { get; set; } = new List<VocabularyItem>();

    }
}
