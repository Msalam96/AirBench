﻿namespace AirBench.FormModels
{
    public class CreateBench
    {
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Seats { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}