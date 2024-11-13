using Cmp.Services.Accommodation.V2;
using Cmp.Types.V2;
using GPRSClient.Services.Interfaces;
using PackagesApi.Combinator.Models;
using System.Runtime.CompilerServices;

namespace GPRSClient.Services.AccomodationService
{
    public class GRPCAccomodationService : IAccomodationService
    {
        public AccommodationProductInfoResponse Search(AccomodationRequest request)
        {
            AccommodationSearchRequest accommodationSearchRequest = new AccommodationSearchRequest();
            //accommodationSearchRequest.SearchParametersGeneric.Language = Language.En;
            //accommodationSearchRequest.SearchParametersGeneric.Currency = request.Currency;
            AccommodationSearchQuery accommodationSearchQuery = new AccommodationSearchQuery();
            accommodationSearchQuery.TravelPeriod = new Cmp.Types.V1.TravelPeriod();
            accommodationSearchQuery.TravelPeriod.StartDate = new Cmp.Types.V1.Date();
            accommodationSearchQuery.TravelPeriod.StartDate = ToDate(request.SearchParameters.DepartureDate);
            accommodationSearchQuery.TravelPeriod.EndDate = ToDate(request.SearchParameters.ReturnDate);
            BasicTraveller basicTraveller = new BasicTraveller();
            foreach (var traveller in request.Traveller)
            {
                basicTraveller.Birthdate = ToDate(traveller.Birthdate);
                accommodationSearchQuery.Travellers.Add(basicTraveller);

            }


            return new AccommodationProductInfoResponse();
        }


        Cmp.Types.V1.Date ToDate(DateTime datetime)
        {
            var date = new Cmp.Types.V1.Date();
            date.Day = datetime.Day;
            date.Month = datetime.Month;
            date.Year = datetime.Year;
            return date;
        }
    }
}
