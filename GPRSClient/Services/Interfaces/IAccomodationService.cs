﻿using Cmp.Services.Accommodation.V2;
using GPRSClient.Models;

namespace GPRSClient.Services.Interfaces
{
    public interface IAccomodationService
    {
        public AccommodationSearchResponse Search(PackagesSearchRequest request);

    }
}
