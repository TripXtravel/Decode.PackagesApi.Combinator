﻿using Cmp.Services.Transport.V2;
using GPRSClient.Models;
using GPRSClient.Services.Interfaces;

namespace GPRSClient.Services.FlightsService
{
    public class GRPCFlightsService : IFlightsService
    {
        public TransportSearchResponse Search(PackagesSearchRequest transportSearchRequest)
        {
            throw new NotImplementedException();
        }
    }
}
