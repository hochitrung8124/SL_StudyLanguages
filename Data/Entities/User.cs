using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<VocabularyItem> VocabularyItems { get; set; } = new List<VocabularyItem>();
}
