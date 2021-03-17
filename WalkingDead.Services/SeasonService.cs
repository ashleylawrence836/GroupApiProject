using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingDead.Data;
using WalkingDead.Models;
using WalkingDeadCharacters.Data;

namespace WalkingDead.Services
{
    public class SeasonService
    {
        private readonly Guid _userId;

        public SeasonService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSeason(SeasonCreate model)
        {
            var entity =
                new Season()
                {
                    SeasonId = model.SeasonId,
                    StartingLocationId = model.StartingLocationId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Seasons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SeasonDetail> GetSeasons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Seasons
                    .Select(
                        e =>
                        new SeasonDetail
                        {
                            SeasonId = e.SeasonId
                        });

                return query.ToList();
            }

        }

        public SeasonDetail GetSeasonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Seasons
                    .Single(e => e.SeasonId == id);
                return
                    new SeasonDetail
                    {
                        SeasonId = entity.SeasonId
                    };
            }
        }

        public bool UpdateSeason(SeasonEdit model, int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {


                var entity =
                    ctx
                    .Seasons
                    .Single(e => e.SeasonId == Id);

                if (model.SeasonId != 0)
                {
                entity.SeasonId = model.SeasonId;
                }

                if (model.StartingLocationId != 0)
                {
                    entity.StartingLocationId = model.StartingLocationId;
                }
                

                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeleteSeason(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Seasons
                    .Single(e => e.SeasonId == seasonId);

                ctx.Seasons.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}


