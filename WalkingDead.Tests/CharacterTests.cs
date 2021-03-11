using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingDead.Data;
using WalkingDead.Models;
using WalkingDead.Services;

namespace WalkingDead.Tests
{
    [TestClass]
    public class CharacterTests
    {

        private CharacterService CreateCharacterService()
        {

            var characterService = new CharacterService();
            return characterService;

        }

        [TestMethod]

        public void TestAddCharacter()
        {
            var characterService = CreateCharacterService();
            CharacterCreate testCharacterOne = new CharacterCreate();
            testCharacterOne.Name = "Rick Grimes";
            testCharacterOne.ActorName = "Andrew Lincoln";
            testCharacterOne.WeaponOfChoice = "Gun";
            testCharacterOne.Details = "Kind of a grump";
            testCharacterOne.FirstEpisodeId = 1;
            testCharacterOne.LastEpisodeId = 1;

            bool wasAdded = characterService.CreateCharacter(testCharacterOne);

            Assert.IsTrue(wasAdded);
            
        }

        public void TestGetCharacterById()
        {
            var characterService = CreateCharacterService();
            CharacterDetail testCharacterOne = new CharacterDetail();
            testCharacterOne.Name = "Rick Grimes";
            testCharacterOne.ActorName = "Andrew Lincoln";

            CharacterDetail actualCharacter = characterService.GetCharacterById(1);

            Assert.AreEqual(testCharacterOne.ActorName, actualCharacter.ActorName);

        }

        public void TestGetCharacters()
        {
            var characterService = CreateCharacterService();
            CharacterDetail testCharacterOne = new CharacterDetail();
            testCharacterOne.Name = "Rick Grimes";
            testCharacterOne.ActorName = "Andrew Lincoln";

            List<CharacterDetail> actualCharacters = characterService.GetCharacters();

            Assert.AreEqual(1, actualCharacters.Count);

        }
        
        public void TestUpdateandDeleteCharacter()
        {
            var characterService = CreateCharacterService();
            CharacterEdit testCharacterOne = new CharacterEdit();
            testCharacterOne.Name = "Rick Grimes";
            testCharacterOne.ActorName = "Andrew Lincoln";
        
            bool wasUpdated = characterService.UpdateCharacter(testCharacterOne, 1);

            Assert.IsTrue(wasUpdated);

            bool wasDeleted = characterService.DeleteCharacter(1);
            
            Assert.IsTrue(wasDeleted);

        }
    }
}


