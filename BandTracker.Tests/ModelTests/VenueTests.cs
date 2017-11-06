using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using BandTracker.Models;

namespace BandTracker.Tests
{
    [TestClass]
    public class VenueTests : IDisposable
    {
        public VenueTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=band_tracker_test;";
        }

        public void Dispose()
        {
            Venue.DeleteAll();
            Band.DeleteAll();
        }

        [TestMethod]
        public void GetAll_VenuesEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = Venue.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_OverrideTrueIfNamesAreTheSame_Venue()
        {
            // Arrange, Act
            Venue firstVenue = new Venue("Bangalore");
            Venue secondVenue = new Venue("Bangalore");

            // Assert
            Assert.AreEqual(firstVenue, secondVenue);
        }

        [TestMethod]
        public void Save_SavesVenuesToDatabase_VenueList()
        {
            //Arrange
            Venue testVenue = new Venue("Bangalore");

            //Act
            testVenue.Save();
            List<Venue> result = Venue.GetAll();
            List<Venue> testList = new List<Venue>{testVenue};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            //Arrange
            Venue testVenue = new Venue("Bangalore");

            //Act
            testVenue.Save();
            Venue savedVenue = Venue.GetAll()[0];

            int result = savedVenue.GetId();
            int testId = testVenue.GetId();

            //Assert
            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FindsVenueInDatabase_Venue()
        {
            //Arrange
            Venue testVenue = new Venue("Bangalore");
            testVenue.Save();

            //Act
            Venue foundVenue = Venue.Find(testVenue.GetId());

            //Assert
            Assert.AreEqual(testVenue, foundVenue);
        }

        [TestMethod]
        public void Update_UpdatesVenueInDatabase_String()
        {
            //Arrange
            Venue testVenue = new Venue("Bangalore");
            testVenue.Save();
            string newName = "Hyderabad";

            //Act
            testVenue.UpdateVenueName(newName);

            string result = Venue.Find(testVenue.GetId()).GetVenueName();

            //Assert
            Assert.AreEqual(newName, result);
        }

        [TestMethod]
        public void Delete_DeletesVenueAssociationsFromDatabase_VenueList()
        {
            //Arrange
            Band testBand = new Band("Pink Floyd");
            testBand.Save();

            string testName = "Hyderabad";
            Venue testVenue = new Venue(testName);
            testVenue.Save();

            //Act
            testVenue.AddBand(testBand);
            testVenue.DeleteVenue();

            List<Venue> resultBandVenues = testBand.GetVenues();
            List<Venue> testBandVenues = new List<Venue> {};

            //Assert
            CollectionAssert.AreEqual(testBandVenues, resultBandVenues);
        }

        [TestMethod]
        public void AddBand_AddsBandToVenue_BandList()
        {
            //Arrange
            Venue testVenue = new Venue("Bangalore");
            testVenue.Save();

            Band testBand = new Band("Pink Floyd");
            testBand.Save();

            //Act
            testVenue.AddBand(testBand);

            List<Band> result = testVenue.GetBands();
            List<Band> testList = new List<Band>{testBand};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void GetBands_ReturnsAllVenueBands_BandList()
        {
            //Arrange
            Venue testVenue = new Venue("Bangalore");
            testVenue.Save();

            Band testBand1 = new Band("Pink Floyd");
            testBand1.Save();

            Band testBand2 = new Band("Enigma");
            testBand2.Save();

            //Act
            testVenue.AddBand(testBand1);
            List<Band> result = testVenue.GetBands();
            List<Band> testList = new List<Band> {testBand1};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }
    }
}
