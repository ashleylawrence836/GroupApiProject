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
                    Location = model.Location
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
                            SeasonId = e.SeasonId,
                            Location = e.Location
                        });
                return query.ToArray();
            }

        }
    }

}
