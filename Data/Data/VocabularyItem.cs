namespace Data.Data
{
    public class VocabularyItem
    {
        public Guid VocabularyId { get; set; }
        public Guid UserId { get; set; }
        public string Word { get; set; }
        public string Meaning { get; set; }
        public string Topic { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdateAt { get; set; }

    }
}
