using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using BandTracker.Models;

namespace BandTracker.Tests
{
  [TestClass]
  public class BandTests : IDisposable
  {
        public BandTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=band_tracker_test;";
        }

       [TestMethod]
       public void GetAll_BandsEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Band.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

      [TestMethod]
      public void Equals_ReturnsTrueForSameName_Band()
      {
        //Arrange, Act
        Band firstBand = new Band("Pink Floyd");
        Band secondBand = new Band("Pink Floyd");

        //Assert
        Assert.AreEqual(firstBand, secondBand);
      }

      [TestMethod]
      public void Save_SavesBandToDatabase_BandList()
      {
        //Arrange
        Band testBand = new Band("Pink Floyd");
        testBand.Save();

        //Act
        List<Band> result = Band.GetAll();
        List<Band> testList = new List<Band>{testBand};

        //Assert
        CollectionAssert.AreEqual(testList, result);
      }


     [TestMethod]
     public void Save_DatabaseAssignsIdToBand_Id()
     {
       //Arrange
       Band testBand = new Band("Pink Floyd");
       testBand.Save();

       //Act
       Band savedBand = Band.GetAll()[0];

       int result = savedBand.GetId();
       int testId = testBand.GetId();

       //Assert
       Assert.AreEqual(testId, result);
    }


    [TestMethod]
    public void Find_FindsBandInDatabase_Band()
    {
      //Arrange
      Band testBand = new Band("Pink Floyd");
      testBand.Save();

      //Act
      Band foundBand = Band.Find(testBand.GetId());

      //Assert
      Assert.AreEqual(testBand, foundBand);
    }

    // [TestMethod]
    // public void Delete_DeletesBandAssociationsFromDatabase_BandList()
    // {
    //   //Arrange
    //   Venue testVenue = new Venue("Bangalore");
    //   testVenue.Save();
    //
    //   Band testBand = new Band("Pink Floyd");
    //   testBand.Save();
    //
    //   //Act
    //   testBand.AddVenue(testVenue);
    //   testBand.DeleteBand();
    //
    //   List<Band> resultVenueBands = testVenue.GetBands();
    //   List<Band> testVenueBands = new List<Band> {};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testVenueBands, resultVenueBands);
    // }

    [TestMethod]
    public void Test_AddVenue_AddsVenueToBand()
    {
      //Arrange
      Band testBand = new Band("Pink Floyd");
      testBand.Save();

      Venue testVenue = new Venue("Bangalore");
      testVenue.Save();

      Venue testVenue2 = new Venue("Hyderabad");
      testVenue2.Save();

      //Act
      testBand.AddVenue(testVenue);
      testBand.AddVenue(testVenue2);

      List<Venue> result = testBand.GetVenues();
      List<Venue> testList = new List<Venue>{testVenue, testVenue2};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetVenues_ReturnsAllBandVenues_VenueList()
    {
      //Arrange
      Band testBand = new Band("Pink Floyd");
      testBand.Save();

      Venue testVenue1 = new Venue("Bangalore");
      testVenue1.Save();

      Venue testVenue2 = new Venue("Hyderabad");
      testVenue2.Save();

      //Act
      testBand.AddVenue(testVenue1);
      List<Venue> savedVenues = testBand.GetVenues();
      List<Venue> testList = new List<Venue> {testVenue1};

      //Assert
      CollectionAssert.AreEqual(testList, savedVenues);
    }


  //   [TestMethod]
  //   public void Update_UpdatesBandInDatabase_String()
  //   {
  //     //Arrange
  //
  //     Band testBand = new Band("Pink Floyd", "Fiction");
  //     testBand.Save();
  //
  //     //Act
  //     testBand.UpdateBand("History", "Comedy");
  //     Band result = Band.Find(testBand.GetId());
  //
  //     //Assert
  //     Assert.AreEqual(testBand, result);
  //   }
  //
  //   [TestMethod]
  //   public void DeleteBand_DeleteBandInDatabase_Null()
  //   {
  //     //Arrange
  //     string title = "Pink Floyd";
  //     Band testBand = new Band(title, "Fiction");
  //     testBand.Save();
  //     // string deletedBand = "";
  //
  //     //Act
  //     testBand.DeleteBand();
  //     int result = Band.GetAll().Count;
  //
  //     //Assert
  //     Assert.AreEqual(0, result);
  // }


    public void Dispose()
    {
      Venue.DeleteAll();
      Band.DeleteAll();
    }
  }
}
