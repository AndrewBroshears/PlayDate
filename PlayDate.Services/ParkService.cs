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
        private readonly string _userId;

        public ParkService(string userId)
        {
            _userId = userId;
        }

        //Create
        public bool CreatePark(ParkCreate model)
        {
            var entity =
                new Park()
                {
                    UserId = _userId,
                    ParkName = model.ParkName,
                    ParkAddress = model.ParkAddress,
                    AmenityId = model.AmenityId,
                    CreatedUtc = DateTimeOffset.Now
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Parks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get
        public IEnumerable<ParkListItem> GetParks()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Parks
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new ParkListItem
                                {
                                    ParkId = e.ParkId,
                                    ParkName = e.ParkName,
                                    ParkAddress = e.ParkAddress,
                                    AmenityId = e.AmenityId,
                                    Ratings = e.Ratings
                                }
                        );
                return query.ToArray();
            }
        }

        //Read Detail
        public ParkDetail GetParkById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parks
                        .Single(e => e.ParkId == id && e.UserId == _userId);
                return
                new ParkDetail
                {
                    ParkId = entity.ParkId,
                    ParkName = entity.ParkName,
                    ParkAddress = entity.ParkAddress,
                    AmenityId = entity.AmenityId,
                    Ratings = entity.Ratings,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        //Update Edit 
        public bool UpdatePark(ParkEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parks
                        .Single(e => e.ParkId == model.ParkId && e.UserId == _userId);

                entity.ParkName = model.ParkName;
                entity.ParkAddress = model.ParkAddress;
                entity.AmenityId = model.AmenityId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Delete 
        public bool DeletePark(int parkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parks
                        .Single(e => e.ParkId == parkId && e.UserId == _userId);

                ctx.Parks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
