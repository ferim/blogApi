namespace Shared.RequestFeatures
{
    public class ArticleParameters : RequestParameters
    {
        public ArticleParameters() => OrderBy = "createdDate";
        public DateTime CreationDateMin { get; set; } = new DateTime(2022, 09, 04);//Blog publish date
        public DateTime CreationDateMax { get; set; } = DateTime.Now;
        public bool ValidCreationDate => CreationDateMax > CreationDateMin;
        public string? SearchTerm { get; set; }
    }
}
