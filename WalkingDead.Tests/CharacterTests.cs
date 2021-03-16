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

        // PLEASE RUN TestCreateEpisode() METHOD FIRST
        [TestMethod]

        public void TestAddandDeleteCharacter()
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

            bool wasDeleted = characterService.DeleteCharacter(1);

            Assert.IsTrue(wasDeleted);

        }


        [TestMethod]
        public void AddCharacter()
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

        [TestMethod]
        public void TestGetCharacters()
        {
            var characterService = CreateCharacterService();
            CharacterDetail testCharacterOne = new CharacterDetail();
            testCharacterOne.Name = "Rick Grimes";
            testCharacterOne.ActorName = "Andrew Lincoln";

            List<CharacterDetail> actualCharacters = characterService.GetCharacters();

            Assert.AreEqual(1, actualCharacters.Count);

        }

        [TestMethod]
        public void TestGetCharacterById()
        {
            var characterService = CreateCharacterService();
            CharacterDetail testCharacterOne = new CharacterDetail();
            testCharacterOne.Name = "Rick Grimes";
            testCharacterOne.ActorName = "Andrew Lincoln";

            CharacterDetail actualCharacter = characterService.GetCharacterById(2);

            Assert.AreEqual(testCharacterOne.ActorName, actualCharacter.ActorName);

        }

        [TestMethod]
        public void TestUpdateMethod()
        {
            var characterService = CreateCharacterService();
            CharacterEdit testCharacterOne = new CharacterEdit(
                "Rick Sanchez",
                "Andrew Lincoln",
                "Leader",
                "Gun");

            Assert.IsTrue(characterService.UpdateCharacter(testCharacterOne, 2));
        }

    }
}



