namespace ProjectPage.Models
{
    public class ProjectViewModel
    {
        public string? Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Img { get; set; }
        public List<ShowcaseItem>? ShowcaseItems { get; set; }
    }
}
