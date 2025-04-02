namespace Portfolio.Api.DTOs
{
    //public class SpeciesDetail
    //{
    //    public Class1[] SpeciesDetails { get; set; }

    //}


    public class SpeciesDetail
    {
        public Speciesdata speciesData { get; set; }
        public int taxonId { get; set; }
        public object parentId { get; set; }
        public string swedishName { get; set; }
        public string scientificName { get; set; }
        public object category { get; set; }
        public int sortOrder { get; set; }
    }

    public class Speciesdata
    {
        public string characteristic { get; set; }
        public string characteristicAsHtml { get; set; }
        public DateTime characteristicChangedDate { get; set; }
        public string spreadAndStatus { get; set; }
        public string spreadAndStatusAsHtml { get; set; }
        public DateTime spreadAndStatusChangedDate { get; set; }
        public string ecology { get; set; }
        public string ecologyAsHtml { get; set; }
        public DateTime ecologyChangedDate { get; set; }
        public string threat { get; set; }
        public string threatAsHtml { get; set; }
        public DateTime threatChangedDate { get; set; }
        public string conservationMeasures { get; set; }
        public string conservationMeasuresAsHtml { get; set; }
        public DateTime conservationMeasuresChangedDate { get; set; }
        public string other { get; set; }
        public string otherAsHtml { get; set; }
        public DateTime otherChangedDate { get; set; }
    }

}
