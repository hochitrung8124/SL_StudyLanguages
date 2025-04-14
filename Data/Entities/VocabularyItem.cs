using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class VocabularyItem
{
    public Guid VocabItemId { get; set; }

    public Guid UserId { get; set; }

    public string Word { get; set; } = null!;

    public string? Meaning { get; set; }

    public string? Topic { get; set; }

    public string? ImageUrl { get; set; }

    public string? AudioUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<SpacedRepetitionLog> SpacedRepetitionLogs { get; set; } = new List<SpacedRepetitionLog>();

    public virtual User User { get; set; } = null!;
}
