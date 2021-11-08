using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes { get; set; }
        public List<PassengerPlane> PassengersPlanes => Planes.OfType<PassengerPlane>().ToList();
        public List<MilitaryPlane> MilitaryPlanes => Planes.OfType<MilitaryPlane>().ToList();
        public List<MilitaryPlane> TransportMilitaryPlanes => Planes.OfType<MilitaryPlane>().Where(p => p.Type == MilitaryType.TRANSPORT).ToList();
        public PassengerPlane PassengerPlaneWithMaxPassengersCapacity => PassengersPlanes.First(p => p.PassengersCapacity == PassengersPlanes.Max(p => p.PassengersCapacity));

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(w => w.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.MaxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.MaxLoadCapacity));
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(x => x.Model)) +
                    '}';
        }
    }
}
