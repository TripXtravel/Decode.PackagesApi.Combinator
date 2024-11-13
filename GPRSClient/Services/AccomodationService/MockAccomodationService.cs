using Cmp.Services.Accommodation.V2;
using Cmp.Types.V1;
using GPRSClient.Services.Interfaces;

namespace GPRSClient.Services.AccomodationService
{
    public class MockAccomodationService : IAccomodationService
    {
        public AccommodationSearchResponse Search(AccommodationSearchRequest request)
        {
            var accomodationResult1 = new AccommodationSearchResult();
            accomodationResult1.ResultId = 1;
            accomodationResult1.QueryId = 1;
            var bookability = new Cmp.Types.V1.Bookability();
            bookability.ConfirmationTime.Hours = 12;
            bookability.ConfirmationTime.Minutes = 0;
            accomodationResult1.Bookability = bookability;
            var cancePenalty = new Cmp.Types.V2.CancelPenalty();
            cancePenalty.Description = "No cancelation";
            var cancelPenalties = new Google.Protobuf.Collections.RepeatedField<Cmp.Types.V2.CancelPenalty>();
            cancelPenalties.Add(cancePenalty);
            var penalties = cancelPenalties;
            var cancelPolicy = new Cmp.Types.V2.CancelPolicy();
            cancelPolicy.CancelPenalties.Add(penalties);
            accomodationResult1.CancelPolicy = cancelPolicy;
            var units = new Google.Protobuf.Collections.RepeatedField<Unit>();
            var unit1 = new Unit();

            var bed1 = new Bed();
            bed1.Type = BedType.King;
            bed1.Count = 1;

            var bed2 = new Bed();
            bed1.Type = BedType.King;
            bed1.Count = 1;

            var beds = new Google.Protobuf.Collections.RepeatedField<Bed>();
            beds.Add(bed1);
            beds.Add(bed2);
            unit1.Beds.Add(beds);

            units.Add(unit1);
            accomodationResult1.Units.Add(units);
            var totalPriceDetail = new Cmp.Types.V2.PriceDetail();

            var accomodationSearchResults = new List<AccommodationSearchResult>();
            var accomodationSearchResponse = new AccommodationSearchResponse();
            foreach (var accomodationSearchResult in accomodationSearchResults)
            {
                accomodationSearchResponse.Results.Add(accomodationSearchResults);
            }
            //return accomodationSearchResponse;
            return new AccommodationSearchResponse();

            //var response = new AccommodationProductInfoResponse();

            //// Create multiple properties with varying data
            //var property1 = CreateProperty(
            //    "Hotel Beach Antalya",
            //    "Hotel Antalya",
            //    CategoryRating._40,
            //    CategoryUnit.Stars,
            //    Cmp.Types.V1.ProductStatus.New,
            //    new[] { "AYT", "GZP" },
            //    "it@tripx.se",
            //    Cmp.Types.V2.EmailType.Support,
            //    new List<(string Code, int Number, Cmp.Types.V2.ProductCodeType Type)>
            //    {
            //        ("ASD12938123", 123, Cmp.Types.V2.ProductCodeType.Supplier),
            //        ("ASD12938124", 124, Cmp.Types.V2.ProductCodeType.Supplier),
            //        ("ASD12938125", 125, Cmp.Types.V2.ProductCodeType.Supplier)
            //    },
            //    123.0, 12331.0
            //);

            //var property2 = CreateProperty(
            //    "Hotel Mountain View",
            //    "Mountain Resorts",
            //    CategoryRating._50,
            //    CategoryUnit.Stars,
            //    Cmp.Types.V1.ProductStatus.Modified,
            //    new[] { "IST", "ADB" },
            //    "contact@mountainview.com",
            //    Cmp.Types.V2.EmailType.Support,
            //    new List<(string Code, int Number, Cmp.Types.V2.ProductCodeType Type)>
            //    {
            //        ("MTV102938", 200, Cmp.Types.V2.ProductCodeType.Icao),
            //        ("MTV102939", 201, Cmp.Types.V2.ProductCodeType.Giata)
            //    },
            //    45.0, 90.0
            //);

            //// Add properties to response
            //response.Properties.Add(property1);
            //response.Properties.Add(property2);

            //return response;
        }

        // Helper method to create a property with all required details
        private PropertyExtendedInfo CreateProperty(
            string name, string chain, CategoryRating categoryRating, CategoryUnit categoryUnit, Cmp.Types.V1.ProductStatus status,
            IEnumerable<string> airportCodes, string emailAddress, Cmp.Types.V2.EmailType emailType,
            IEnumerable<(string Code, int Number, Cmp.Types.V2.ProductCodeType Type)> productCodes,
            double latitude, double longitude)
        {
            var property = new PropertyExtendedInfo();

            SetBasicPropertyInfo(property, name, chain, categoryRating, categoryUnit, status);
            AddAirportCodes(property, airportCodes);
            AddContactEmails(property, emailAddress, emailType);
            AddProductCodes(property, productCodes);
            SetCoordinates(property, latitude, longitude);

            return property;
        }

        // Updated helper methods with parameters
        private void SetBasicPropertyInfo(PropertyExtendedInfo property, string name, string chain, CategoryRating categoryRating, CategoryUnit categoryUnit, Cmp.Types.V1.ProductStatus status)
        {
            property.Property.Name = name;
            property.Property.Chain = chain;
            property.Property.CategoryRating = categoryRating;
            property.Property.CategoryUnit = categoryUnit;
            property.Property.Status = status;
        }

        private void AddAirportCodes(PropertyExtendedInfo property, IEnumerable<string> airportCodes)
        {
            foreach (var airport in airportCodes)
            {
                property.Property.Airports.Add(airport);
            }
        }

        private void AddContactEmails(PropertyExtendedInfo property, string emailAddress, Cmp.Types.V2.EmailType emailType)
        {
            var email = new Cmp.Types.V2.Email
            {
                Address = emailAddress,
                Type = emailType
            };
            property.Property.ContactInfo.Emails.Add(email);
        }

        private void AddProductCodes(PropertyExtendedInfo property, IEnumerable<(string Code, int Number, Cmp.Types.V2.ProductCodeType Type)> productCodes)
        {
            foreach (var (code, number, type) in productCodes)
            {
                property.Property.ProductCodes.Add(new Cmp.Types.V2.ProductCode
                {
                    Code = code,
                    Number = number,
                    Type = type
                });
            }
        }

        private void SetCoordinates(PropertyExtendedInfo property, double latitude, double longitude)
        {
            property.Property.Coordinates = new Cmp.Types.V2.Coordinates
            {
                Latitude = latitude,
                Longitude = longitude
            };
        }

        public AccommodationSearchRequest CreateAccommodationSearchRequest()
        {
            throw new NotImplementedException();
        }

        public AccommodationSearchResult CreateAccommodationSearchResult()
        {
            throw new NotImplementedException();
        }
    }
}
