using Avia8r.Data;
using Avia8r.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia8r.Services
{
    public class MxEventService
    {

        public bool CreateMxEvent(MxEventCreate model)
        {
            var entity =
                new MxEvent()
                {
                    MxId = model.MxId,
                    AcTail = model.AcTail,
                    TypeOfMx = model.TypeOfMx,
                    MxDescription = model.MxDescription,
                    ManHours = model.ManHours,
                    HoursOutOfService = model.HoursOutOfService,
                    Cost = model.Cost
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MaintenanceEvent.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MxEventListItem> GetMxEvent()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .MaintenanceEvent
                    .Where(e => e.MxId != null)
                    .Select(
                        e =>
                        new MxEventListItem
                        {
                            MxId = e.MxId,
                            AcTail = e.AcTail,
                            TypeOfMx = e.TypeOfMx,
                            MxDescription = e.MxDescription,
                            ManHours = e.ManHours,
                            HoursOutOfService = e.HoursOutOfService,
                            Cost = e.Cost
                        }
                        );
                return query.ToArray();
            }
        }

        public MxEventDetail GetMxEventById(int MxId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MaintenanceEvent
                    .Single(e => e.MxId == MxId);
                return
                    new MxEventDetail
                    {
                        MxId = entity.MxId,
                        AcTail = entity.AcTail,
                        TypeOfMx = entity.TypeOfMx,
                        MxDescription = entity.MxDescription,
                        ManHours = entity.ManHours,
                        HoursOutOfService = entity.HoursOutOfService,
                        Cost = entity.Cost
                    };
            }
        }

        public bool UpdateMxEvent(MxEventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MaintenanceEvent
                    .Single(e => e.MxId == model.MxId);

                entity.MxId = model.MxId;
                entity.AcTail = model.AcTail;
                entity.TypeOfMx = model.TypeOfMx;
                entity.MxDescription = model.MxDescription;
                entity.ManHours = model.ManHours;
                entity.HoursOutOfService = model.HoursOutOfService;
                entity.Cost = model.Cost;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMx(int MxId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MaintenanceEvent
                    .Single(e => e.MxId == MxId);

                ctx.MaintenanceEvent.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
