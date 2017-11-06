using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BandTracker.Models
{
    public class Venue
    {
        private int _id;
        private string _venueName;


        public Venue(string venueName, int id = 0)
        {
            _id = id;
            _venueName = venueName;
        }

        public override bool Equals(System.Object otherVenue)
        {
            if (!(otherVenue is Venue))
            {
                return false;
            }
            else
            {
                Venue newVenue = (Venue) otherVenue;
                return this.GetId().Equals(newVenue.GetId());
            }
        }

        public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
        }

        public string GetVenueName()
        {
            return _venueName;
        }

        public int GetId()
        {
            return _id;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO venues (venue_name) VALUES (@venueName);";

            MySqlParameter venueName = new MySqlParameter();
            venueName.ParameterName = "@venueName";
            venueName.Value = this._venueName;
            cmd.Parameters.Add(venueName);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Venue> GetAll()
        {
            List<Venue> allVenues = new List<Venue> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM venues;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int venueId = rdr.GetInt32(0);
                string venueName = rdr.GetString(1);
                Venue newVenue = new Venue(venueName, venueId);
                allVenues.Add(newVenue);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allVenues;
        }

        public static Venue Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM venues WHERE id = @thisId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@thisId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int venueId = 0;
            string venueName = "";

            while (rdr.Read())
            {
                venueId = rdr.GetInt32(0);
                venueName = rdr.GetString(1);
            }

            Venue newVenue= new Venue(venueName, venueId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newVenue;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM venues;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void UpdateVenueName(string newVenueName)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE venues SET venue_name = @newVenueName WHERE id = @searchId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = _id;
            cmd.Parameters.Add(searchId);

            MySqlParameter venueName = new MySqlParameter();
            venueName.ParameterName = "@newVenueName";
            venueName.Value = newVenueName;
            cmd.Parameters.Add(venueName);

            cmd.ExecuteNonQuery();
            _venueName = newVenueName;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void DeleteVenue()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM venues WHERE id = @VenueId; DELETE FROM bands_venues WHERE venue_id = @VenueId;";

            MySqlParameter venueIdParameter = new MySqlParameter();
            venueIdParameter.ParameterName = "@VenueId";
            venueIdParameter.Value = this.GetId();
            cmd.Parameters.Add(venueIdParameter);

            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void AddBand(Band newBand)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO bands_venues (band_id, venue_id) VALUES (@BandId, @VenueId);";

            MySqlParameter band_id = new MySqlParameter();
            band_id.ParameterName = "@BandId";
            band_id.Value = newBand.GetId();
            cmd.Parameters.Add(band_id);

            MySqlParameter venue_id = new MySqlParameter();
            venue_id.ParameterName = "@VenueId";
            venue_id.Value = _id;
            cmd.Parameters.Add(venue_id);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Band> GetBands()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT bands.* FROM venues
            JOIN bands_venues ON (venues.id = bands_venues.venue_id)
            JOIN bands ON (bands_venues.band_id = bands.id) WHERE venues.id = @VenueId;";

            MySqlParameter venueId = new MySqlParameter();
            venueId.ParameterName = "@VenueId";
            venueId.Value = _id;
            cmd.Parameters.Add(venueId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Band> bands = new List<Band>{};

            while(rdr.Read())
            {
                int bandId = rdr.GetInt32(0);
                string bandName = rdr.GetString(1);
                Band newBand = new Band(bandName, bandId);
                bands.Add(newBand);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return bands;
        }
    }
}
