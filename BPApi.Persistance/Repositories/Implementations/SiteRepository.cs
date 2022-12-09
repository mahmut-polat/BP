using BPApi.Application.Interfaces.Repositories;
using BPApi.Domain.Entities;
using BPApi.Infrastructure.DataReader;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPApi.Persistance.Repositories.Implementations
{
    public class SiteRepository : ISiteRepository
    {
        private static readonly string JSON_PATH = "../bp-stations.json";

        private readonly IDataReader<ExternalSite> _jsonReader;

        public SiteRepository(IDataReader<ExternalSite> jsonReader)
        {
            _jsonReader = jsonReader;
        }

        public async Task<IList<Site>> GetAll()
        {
            var sites = new List<Site>();   
            var externalSites = _jsonReader.Read(JSON_PATH);

            foreach(var externalSite in externalSites)
            {
                var site = new Site();

                site.Id = externalSite.Id;
                site.SiteName = externalSite.Location;
                site.Latitude = externalSite.Lat;
                site.Longitude = externalSite.Lng;
                site.HasMotorWaySite = externalSite.Flag_MotorwaySite;
                site.SiteType = externalSite.Key_SiteType;
                site.Location = externalSite.Location;
                site.CreatedBy = "First Employee";
                site.CreatedDate = DateTime.Now;
                site.IsActive = true;

                sites.Add(site);
            }

            return sites;
        }
    }
}
