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

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity =
                new Character()
                {
                    Name = model.Name,
                    ActorName = model.ActorName,
                    WeaponOfChoice = model.WeaponOfChoice,
                    Features = model.Features
                };

            using (var context = new ApplicationDbContext())
            {
                context.Characters.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public IEnumerable<CharacterDetail> GetCharacters()
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
                                    Features = e.Features
                                });
                return query.ToArray();
            }
        }

        public CharacterDetail GetCharacterById( int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Characters
                        .Single(e => e.CharacterId ==id);
                return
                    new CharacterDetail
                    {
                        Name = entity.Name,
                        ActorName = entity.ActorName,
                        WeaponOfChoice = entity.WeaponOfChoice,
                        Features = entity.Features
                    };
            }
        }

        public bool UpdateCharacter(CharacterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == model.CharacterId && e.AddedByUserId == _userId);

                entity.Name = model.Name;
                entity.ActorName = model.ActorName;
                entity.WeaponOfChoice = model.WeaponOfChoice;
                entity.Features = model.Features;

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
