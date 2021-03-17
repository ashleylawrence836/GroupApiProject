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
                                    CharacterId = e.CharacterId,
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
                        Details = entity.Details,
                        CharacterId = entity.CharacterId,
                        FirstEpisodeId = entity.FirstEpisodeId,
                        LastEpisodeId = entity.LastEpisodeId,
                    };
            }
        }


        public bool UpdateCharacter(CharacterEdit model, int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == Id && e.AddedByUserId == _userId);

                entity.Name = model.Name;
                entity.ActorName = model.ActorName;
                entity.WeaponOfChoice = model.WeaponOfChoice;
                entity.Details = model.Details;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteCharacter(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Character deleteCharacter = ctx.Characters.Single(d => d.CharacterId == characterId && d.AddedByUserId == _userId);

                ctx.Characters.Remove(deleteCharacter);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
