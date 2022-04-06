using PlayDate.Data;
using PlayDate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Services
{
    public class ParkService
    {
        private readonly Guid _userId;

        public ParkService(Guid userId)
        {
            _userId = userId;
        }

        //Create service
        public bool CreatePark(ParkCreate model)
        {
            var entity =
                new Park()
                {
                    OwnerId = _userId,
                    ParkName = model.ParkName,
                    ParkAddress = model.ParkAddress,
                    CreatedUtc = DateTimeOffset.Now
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Parks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read service
        public IEnumerable<ParkListItem> GetParks()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Parks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ParkListItem
                                {
                                    ParkId = e.ParkId,
                                    ParkName = e.ParkName,
                                    ParkAddress = e.ParkAddress
                                }
                        );
                return query.ToArray();
            }
        }

        //Read Detail Service
        public ParkDetail GetParkById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parks
                        .Single(e => e.ParkId == id && e.OwnerId == _userId);
                return
                new ParkDetail
                {
                    ParkId = entity.ParkId,
                    ParkName = entity.ParkName,
                    ParkAddress = entity.ParkAddress,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        //Update Edit Service
        public bool UpdatePark(ParkEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parks
                        .Single(e => e.ParkId == model.ParkId && e.OwnerId == _userId);

                entity.ParkName = model.ParkName;
                entity.ParkAddress = model.ParkAddress;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Delete Service
        public bool DeletePark(int parkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parks
                        .Single(e => e.ParkId == parkId && e.OwnerId == _userId);

                ctx.Parks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
