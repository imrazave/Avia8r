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

        public bool CreateAircraft(AircraftCreate model)
        {
            var entity =
                new Aircraft()
                {
                    AcTail = model.AcTail,
                    AcModel = model.AcModel,
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
                            AcModel = e.AcModel,
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
                        AcModel = entity.AcModel,
                        Manufacturer = entity.Manufacturer,
                        Airline = entity.Airline
                    };
            }
        }

        public bool UpdateAircraft(AircraftEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Aircraft
                    .Single(e => e.AcTail == model.AcTail);

                entity.AcTail = model.AcTail;
                entity.AcModel = model.AcModel;
                entity.Manufacturer = model.Manufacturer;
                entity.Airline = model.Airline;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAC(string AcTail)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Aircraft
                    .Single(e => e.AcTail == AcTail);

                ctx.Aircraft.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
