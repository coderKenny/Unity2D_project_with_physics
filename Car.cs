using UnityEngine;
using System.Collections;
using System;


namespace KustomiEventit
{
    public class Car
    {
        // Declare a delegate
        public delegate void OwnerChangedEventHandler(string newOwner);

        // Declare the event
        public event OwnerChangedEventHandler OwnerChanged;

        private string make;
        private string model;
        private int year;
        private string owner;

        public string CarMake
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string CarModel
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int CarYear
        {
            get { return this.year; }
            set { this.year = value; }
        }



        public string CarOwner
        {
            get { return this.owner; }
            set
            {
                this.owner = value;
                if (this.OwnerChanged != null)
                    this.OwnerChanged(value);
            }
        }

        public Car()
        {
        }
    }
}