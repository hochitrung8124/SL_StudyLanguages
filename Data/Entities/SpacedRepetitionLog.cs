using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class SpacedRepetitionLog
{
    public Guid Id { get; set; }

    public Guid VocabItemId { get; set; }

    public DateTime ReviewDate { get; set; }

    public int? IntervalDays { get; set; }

    public bool? Success { get; set; }

    public virtual VocabularyItem VocabItem { get; set; } = null!;
}
