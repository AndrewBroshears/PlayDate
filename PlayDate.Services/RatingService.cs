using PlayDate.Data;
using PlayDate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Services
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        //Create
        public bool CreateRating(RatingCreate model)
        {
            var entity =
                new Rating()
                {
                    OwnerId = _userId,
                    RatingStar = model.RatingStar,
                    RatingComment = model.RatingComment,
                    ParkId = model.ParkId,
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read
        public IEnumerable<RatingListItem> GetRatings()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ratings
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new RatingListItem
                            {
                                RatingId = e.RatingId,
                                RatingStar = e.RatingStar,
                                RatingComment = e.RatingComment,
                                ParkId = e.ParkId
                            }
                        );
                return query.ToArray();
            }
        }

        //Read Detail
        public RatingDetail GetRatingById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == id && e.OwnerId == _userId);
                return new RatingDetail
                {
                    RatingId = entity.RatingId,
                    RatingStar = entity.RatingStar,
                    RatingComment = entity.RatingComment,
                    ParkId = entity.ParkId
                };
            }
        }

        //Update Edit
        public bool UpdateRating(RatingEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == model.RatingId && e.OwnerId == _userId);
               
                entity.RatingId = model.RatingId;
                entity.RatingStar = model.RatingStar;
                entity.RatingComment = model.RatingComment;
                entity.ParkId = model.ParkId;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteRating(int ratingId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == ratingId && e.OwnerId == _userId);
                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
