using System.Collections.Generic;

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

            double totalAmount = 0;
            var frequentRenterPoints = 0;
            var rentals = _rentals;
            var result = "Rental Record for " + Name + "\n";
            
            var nextElement = 0;
            while (nextElement < rentals.Count ) 
            {
                double thisAmount = 0;
                var each = rentals[nextElement];
//determine amounts for each line
                switch (each.Movie.PriceCode) {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        break;
                }
// add frequent renter points
                frequentRenterPoints ++;
// add bonus for a two day new release rental
                if ((each.Movie.PriceCode == Movie.NEW_RELEASE)
                    &&
                    each.DaysRented > 1) frequentRenterPoints ++;
//show figures for this rental
                result += "\t" + each.Movie.Title + "\t" +
                          thisAmount + "\n";
                totalAmount += thisAmount;

                nextElement += 1;
            }

//add footer lines
            result += "Amount owed is " + totalAmount +  "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}
