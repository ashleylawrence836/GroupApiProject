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
    public class CharacterService
    {
        private readonly Guid _userId;

        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public CharacterService() { }

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity =
                new Character()
                {
                    AddedByUserId = _userId,
                    Name = model.Name,
                    ActorName = model.ActorName,
                    WeaponOfChoice = model.WeaponOfChoice,
                    Details = model.Details,
                    FirstEpisodeId = model.FirstEpisodeId,
                    LastEpisodeId = model.LastEpisodeId
                };

            using (var context = new ApplicationDbContext())
            {
                context.Characters.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public List<CharacterDetail> GetCharacters()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                        .Characters
                        .Select(
                            e =>
                                new CharacterDetail
                                {
                                    Name = e.Name,
                                    ActorName = e.ActorName,
                                    WeaponOfChoice = e.WeaponOfChoice,
                                    Details = e.Details,
                                    FirstEpisodeId = e.FirstEpisodeId,
                                    LastEpisodeId = e.LastEpisodeId,
                                });
                return query.ToList();
            }
        }

        public CharacterDetail GetCharacterById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Characters
                        .Single(e => e.CharacterId == id);
                return
                    new CharacterDetail
                    {
                        Name = entity.Name,
                        ActorName = entity.ActorName,
                        WeaponOfChoice = entity.WeaponOfChoice,
                        Details = entity.Details
                    };
            }
        }


        public bool UpdateCharacter(CharacterEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == id && e.AddedByUserId == _userId);

                entity.Name = model.Name;
                entity.ActorName = model.ActorName;
                entity.WeaponOfChoice = model.WeaponOfChoice;
                entity.Details = model.Features;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteCharacter(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == characterId && e.AddedByUserId == _userId);

                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
