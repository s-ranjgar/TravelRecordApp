﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TravelRecordApp.Model
{
    public class Post
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string VenueName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string LocationAddress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }



        [MaxLength(250)]
        public string Experience { get; set; }
    }
}
