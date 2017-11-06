# Band Tracker


## Description

_A simple website to track bands and the venues where they've played concerts._

## Specs

* _Creating a Homepage named BandTracker where a user can add a Venue, view all Venues and all the bands for each venue and vice versa._
* _Allow the user to add a Venue using a form and once added, redirect him to the home page that displays the list of Venues and there bands and vice versa._
* _View all Venues , View all Bands has the list of Venues and Bands respectively, that can be updated and deleted._

## Built With

* _Atom_
* _Terminal_


## Technologies Used

* _HTML_
* _CSS_
* _C#_
* _.Net Framework_
* _MVC_
* _Php_
* _SQL_

* CREATE DATABASE band_tracker;
* USE band_tracker;
* CREATE TABLE bands (id serial PRIMARY KEY, band_name   VARCHAR(255));
* CREATE TABLE venues (id serial PRIMARY KEY, venue_name VARCHAR(255));
* CREATE TABLE bands_venues (id serial PRIMARY KEY, band_id INT, venue_id INT)

### License

Copyright (c) 2017 Saneyee Sarkar
