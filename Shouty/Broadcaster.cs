using System;
using System.Collections.Generic;

namespace Shouty
{
    public class Broadcaster
    {
        private readonly List<Person> _subscribers = new List<Person>();

        public void Broadcast(string message, double[] shouterGeoLocation)
        {
            // Loop over all subscribers
            foreach (var subscriber in _subscribers)
            {
                //   Deliver message if subscriber is in range
                if (IsInRange(subscriber.GeoLocation, shouterGeoLocation))
                {
                    subscriber.Hear(message);
                }
            }
        }

        private bool IsInRange(double[] loc1, double[] loc2)
        {
            var d = distance(loc1[0], loc1[1], loc2[0], loc2[1]) <= 1000;
            Console.WriteLine("Distance: %d", d);
            return d;
        }

        // Taken from geodatasource.com
        private double distance(double lat1, double lon1, double lat2, double lon2) {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;
            return (dist);
        }

        private double deg2rad(double deg) {
            return (deg * Math.PI / 180.0);
        }

        private double rad2deg(double rad) {
            return (rad / Math.PI * 180.0);
        }

        public void Subscribe(Person person)
        {
            _subscribers.Add(person);
        }
    }
}