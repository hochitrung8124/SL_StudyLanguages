namespace Data.Data
{
    public class SpacedRepetitionLog
    {
        public Guid SpacedRepetitionLogId { get; set; }
        public Guid VocalbularyId { get; set; }
        public DateOnly ReviewDate { get; set; }
        public DateOnly Intervaldays { get; set; }
        public Boolean Success { get; set; }

        public virtual ICollection<VocabularyItem> VocabularyItems { get; set; } = new List<VocabularyItem>();
    }
}
