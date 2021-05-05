using Avia8r.Data;
using Avia8r.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia8r.Services
{
    public class FlightLegService
    {
        //private readonly Guid _userId;
        //public AircraftService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateFlightLeg(FlightLegCreate model)
        {
            var entity =
                new FlightLeg()
                {
                    TripId = model.TripId,
                    OriginAirport = model.OriginAirport,
                    DestinationAirport = model.DestinationAirport,
                    DepartureDate = model.DepartureDate,
                    AcTail = model.AcTail,
                    ArrivalDate = model.ArrivalDate,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FlightLegs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AircraftListItem> GetFlightLeg()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FlightLegs
                    .Where(e => e.TripId != null)
                    .Select(
                        e =>
                        new FlightLegListItem
                        {
                            TripId = e.TripId,
                            OriginAirport = e.OriginAirport,
                            DestinationAirport = e.DestinationAirport,
                            DepartureDate = e.DepartureDate,
                            AcTail = e.AcTail,
                            ArrivalDate = e.ArrivalDate,
                        }
                        );
                return query.ToArray();
            }
        }

        public FlightLegDetail GetFlightLegById(int TripId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FlightLegs
                    .Single(e => e.TripId == TripId);
                return
                    new FlightLegDetail
                    {
                        TripId = entity.TripId,
                        OriginAirport = entity.OriginAirport,
                        DestinationAirport = entity.DestinationAirport,
                        DepartureDate = entity.DepartureDate,
                        AcTail = entity.AcTail,
                        ArrivalDate = entity.ArrivalDate,
                    };
            }
        }

        public bool UpdateFlightLeg(FlightLegEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FlightLegs
                    .Single(e => e.AcTail == model.AcTail);

                entity.TripId = model.TripId;
                entity.OriginAirport = model.OriginAirport;
                entity.DestinationAirport = model.DestinationAirport;
                entity.DepartureDate = model.DepartureDate;
                entity.AcTail = entity.AcTail;
                entity.ArrivalDate = model.ArrivalDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFlightLeg(int TripId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FlightLegs
                    .Single(e => e.TripId == TripId);

                ctx.FlightLegs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
