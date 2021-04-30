using Avia8r.Data;
using Avia8r.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia8r.Services
{
    public class AircraftService
    {
        //private readonly Guid _userId;
        //public AircraftService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateAircraft(AircraftCreate model)
        {
            var entity =
                new Aircraft()
                {
                    AcTail = model.AcTail,
                    Model = model.AcModel,
                    Manufacturer = model.Manufacturer,
                    Airline = model.Airline
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Aircraft.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AircraftListItem> GetAircraft()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Aircraft
                    .Where(e => e.AcTail != null)
                    .Select(
                        e =>
                        new AircraftListItem
                        {
                            AcTail = e.AcTail,
                            Model = e.Model,
                            Manufacturer = e.Manufacturer,
                            Airline = e.Airline

                        }
                        );
                return query.ToArray();
            }
        }

        public AircraftDetail GetAircraftById(string AcTail)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Aircraft
                    .Single(e => e.AcTail == AcTail);
                return
                    new AircraftDetail
                    {
                        AcTail = entity.AcTail,
                        AcModel = entity.Model,
                        Manufacturer = entity.Manufacturer,
                        Airline = entity.Airline
                    }
            }
        }
    }
}
