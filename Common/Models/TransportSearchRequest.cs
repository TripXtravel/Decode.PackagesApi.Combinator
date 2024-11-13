namespace PackagesApi.Combinator.Models
{
    public class TransportSearchRequest
    {
        public IEnumerable<Traveller> Travellers { get; set; }
        public SearchParameters SearchParameters { get; set; }
    }
}