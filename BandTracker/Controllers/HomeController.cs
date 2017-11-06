using Microsoft.AspNetCore.Mvc;
using BandTracker.Models;
using System.Collections.Generic;
using System;

namespace BandTracker.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/viewcategories")]
        public ActionResult ViewCategories()
        {
            return View();
        }

        [HttpGet("/bands")]
        public ActionResult Bands()
        {
            List<Band> allBands = Band.GetAll();
            return View(allBands);
        }

        [HttpGet("/bands/new")]
        public ActionResult BandForm()
        {
            return View();
        }

        [HttpPost("/bands/new")]
        public ActionResult BandCreate()
        {
            Band newBand = new Band(Request.Form["band-name"]);
            newBand.Save();
            return View("Success");
        }

        //ONE Band
        [HttpGet("/bands/{id}")]
        public ActionResult BandDetail(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Band SelectedBand = Band.Find(id);
            List<Venue> BandVenues = SelectedBand.GetVenues();
            List<Venue> AllVenues = Venue.GetAll();
            model.Add("band", SelectedBand);
            model.Add("bandVenues", BandVenues);
            model.Add("allVenues", AllVenues);
            return View(model);
        }

        //ADD Venue TO Band
        [HttpPost("bands/{bandId}/venues/new")]
        public ActionResult BandAddVenue(int bandId)
        {
            Band band = Band.Find(bandId);
            Venue venue = Venue.Find(Int32.Parse(Request.Form["venue-id"]));

            band.AddVenue(venue);
            return View("Success");
        }

        [HttpGet("/bands/{id}/edit")]
        public ActionResult EditBand(int id)
        {
            Band thisBand = Band.Find(id);
            return View(thisBand);
        }

        [HttpPost("/bands/{id}/edit")]
        public ActionResult EditedBand(int id)
        {
            Band thisBand = Band.Find(id);
            thisBand.UpdateBand(Request.Form["new-bandname"]);
            return RedirectToAction("Index");
        }

        [HttpGet("/bands/{id}/delete")]
        public ActionResult DeleteBand(int id)
        {
            Band thisBand = Band.Find(id);
            thisBand.DeleteBand();
            return RedirectToAction("Index");
        }




        [HttpGet("/venues")]
        public ActionResult Venues()
        {
            List<Venue> allVenues = Venue.GetAll();
            return View(allVenues);
        }

        [HttpGet("/venues/new")]
        public ActionResult VenueForm()
        {
            return View();
        }

        [HttpPost("/venues/new")]
        public ActionResult VenueCreate()
        {
            Venue newVenue = new Venue(Request.Form["venue-name"]);
            newVenue.Save();
            return View("Success");
        }

        //ONE Venue
        [HttpGet("/venues/{id}")]
        public ActionResult VenueDetail(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Venue selectedVenue = Venue.Find(id);
            List<Band> VenueBands = selectedVenue.GetBands();
            List<Band> AllBands = Band.GetAll();
            model.Add("venue", selectedVenue);
            model.Add("venueBands", VenueBands);
            model.Add("allBands", AllBands);
            return View(model);
        }

        //ADD Band TO Venue
        [HttpPost("venues/{venueId}/bands/new")]
        public ActionResult VenueAddBand(int venueId)
        {
            Venue venue = Venue.Find(venueId);
            Band band = Band.Find(Int32.Parse(Request.Form["band-id"]));
            venue.AddBand(band);
            return View("Success");
        }

        [HttpGet("/venues/{id}/edit")]
        public ActionResult EditVenue(int id)
        {
            Venue thisVenue = Venue.Find(id);
            return View(thisVenue);
        }

        [HttpPost("/venues/{id}/edit")]
        public ActionResult EditedVenue(int id)
        {
            Venue thisVenue = Venue.Find(id);
            thisVenue.UpdateVenueName(Request.Form["new-venuename"]);
            return RedirectToAction("Index");
        }

        [HttpGet("/venues/{id}/delete")]
        public ActionResult DeleteVenue(int id)
        {
            Venue thisVenue = Venue.Find(id);
            thisVenue.DeleteVenue();
            return RedirectToAction("Index");
        }
    }
}
