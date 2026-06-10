using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualPet.Models;

namespace VirtualPetTests
{
    [TestClass]
    public class PetTests
    {
        [TestMethod]
        public void Feed_Reduces_Hunger()
        {
            Pet pet = new Pet("Test");

            pet.Hunger = 50;

            pet.Feed();

            Assert.AreEqual(30, pet.Hunger);
        }

        [TestMethod]
        public void Feed_Does_Not_Go_Below_Zero()
        {
            Pet pet = new Pet("Test");

            pet.Hunger = 10;

            pet.Feed();

            Assert.AreEqual(0, pet.Hunger);
        }

        [TestMethod]
        public void Play_Increases_Happiness()
        {
            Pet pet = new Pet("Test");

            pet.Happiness = 50;

            pet.Play();

            Assert.AreEqual(65, pet.Happiness);
        }

        [TestMethod]
        public void Play_Decreases_Energy()
        {
            Pet pet = new Pet("Test");

            pet.Energy = 50;

            pet.Play();

            Assert.AreEqual(40, pet.Energy);
        }

        [TestMethod]
        public void Sleep_Increases_Energy()
        {
            Pet pet = new Pet("Test");

            pet.Energy = 50;

            pet.Sleep();

            Assert.AreEqual(75, pet.Energy);
        }

        [TestMethod]
        public void Sleep_Does_Not_Exceed_100()
        {
            Pet pet = new Pet("Test");

            pet.Energy = 90;

            pet.Sleep();

            Assert.AreEqual(100, pet.Energy);
        }

        [TestMethod]
        public void Mood_Is_Happy()
        {
            Pet pet = new Pet("Test");

            pet.Hunger = 20;
            pet.Energy = 80;
            pet.Happiness = 80;

            Assert.AreEqual("happy", pet.GetMood());
        }

        [TestMethod]
        public void Mood_Is_Hungry()
        {
            Pet pet = new Pet("Test");

            pet.Hunger = 70;

            Assert.AreEqual("hungry", pet.GetMood());
        }

        [TestMethod]
        public void Mood_Is_Tired()
        {
            Pet pet = new Pet("Test");

            pet.Energy = 30;

            Assert.AreEqual("tired", pet.GetMood());
        }

        [TestMethod]
        public void Mood_Is_Sad()
        {
            Pet pet = new Pet("Test");

            pet.Happiness = 30;

            Assert.AreEqual("sad", pet.GetMood());
        }

        [TestMethod]
        public void Stage_Is_Baby()
        {
            Pet pet = new Pet("Test");

            pet.Age = 5;

            Assert.AreEqual("baby", pet.GetStage());
        }

        [TestMethod]
        public void Stage_Is_Adult()
        {
            Pet pet = new Pet("Test");

            pet.Age = 15;

            Assert.AreEqual("adult", pet.GetStage());
        }

        [TestMethod]
        public void Stage_Is_Cthulhu()
        {
            Pet pet = new Pet("Test");

            pet.Age = 25;

            Assert.AreEqual("cthulhu", pet.GetStage());
        }
    }
}