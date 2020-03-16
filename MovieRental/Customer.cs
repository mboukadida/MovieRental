using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{
    public class Customer
    {
        public string Name { get; }
        public IReadOnlyList<Rental> Rentals => _rentals.AsReadOnly();
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental arg)
            => _rentals.Add(arg);

        public string Statement() {
            var rentals = _rentals;
            var result = "Rental Record for " + Name + "\n";
            
            var nextElement = 0;
            while (nextElement < rentals.Count ) 
            {
                var each = rentals[nextElement];
                each.GetFrequentRenterPoints();

//show figures for this rental
                result += "\t" + each.Movie.Title + "\t" + each.GetCharge() + "\n";
                nextElement += 1;
            }

//add footer lines
            result += "Amount owed is " + GetTotalCharge() +  "\n";
            result += "You earned " + GetTotalFrequentRenterPoints() + " frequent renter points";
            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            return Rentals.Sum(rental => rental.GetFrequentRenterPoints());
        }

        private double GetTotalCharge()
        {
            return Rentals.Sum(rental => rental.GetCharge());
        }
    }
}
