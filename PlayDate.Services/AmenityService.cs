using PlayDate.Data;
using PlayDate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Services
{
    public class AmenityService
    {
        private readonly Guid _userId;

        public AmenityService(Guid userId)
        {
            _userId = userId;
        }

        //Create
        public bool CreateAmenity(AmenityCreate model)
        {
            var entity =
                new Amenity()
                {
                    OwnerId = _userId,
                    AmenityType = model.AmenityType
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Amenities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read
        public IEnumerable<AmenityListItem> GetAmenities()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Amenities
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new AmenityListItem
                            {
                                AmenityId = e.AmenityId,
                                AmenityType = e.AmenityType
                            }
                        );
                return query.ToArray();
            }
        }

        //Read Detail
        public AmenityDetail GetAmenityById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Amenities
                        .Single(e => e.AmenityId == id && e.OwnerId == _userId);
                return new AmenityDetail
                {
                    AmenityId = entity.AmenityId,
                    AmenityType = entity.AmenityType
                };
            }
        }

        //Update Edit
        public bool UpdateAmenity(AmenityEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Amenities
                       .Single(e => e.AmenityId == model.AmenityId && e.OwnerId == _userId);

                entity.AmenityId = model.AmenityId;
                entity.AmenityType = model.AmenityType;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteAmenity(int AmenityId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Amenities
                        .Single(e => e.AmenityId == AmenityId && e.OwnerId == _userId);
                ctx.Amenities.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
