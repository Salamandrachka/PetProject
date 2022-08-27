using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp2
{

    class Booking
    {
        public Flight flight;
        public string name;

        public Booking(Flight flight, string name)
        {
            this.flight = flight;
            this.name = name;
        }

        public override string ToString()
        {
            return $"{name} - {flight}";
        }
    }
    class Flight
    {
        public string departure;
        public string destination;
        public string date;

        public Flight(string departure, string destination, string date)
        {
            this.departure = departure;
            this.destination = destination;
            this.date = date;
        }

        public override string ToString()
        {
            return $"{departure} - {destination} | {date}";
        }
    }

    class Program
    {
        static void PrtMenu()
        {
            Console.WriteLine("\nAirsales system");
            Console.WriteLine("1. Online flight table");
            Console.WriteLine("2. View flight");
            Console.WriteLine("3. Book flight");
            Console.WriteLine("4. View bookings");
            Console.WriteLine("0. Exit");
        }

        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
                {new Flight("Warsaw", "Toronto", "23-07-2022 11:30"), new Flight("Berlin", "Paris", "24-07-2022 11:30"), new Flight("Warsaw", "Ibiza", "24-07-2022 11:30")};

            List<Booking> bookings = new List<Booking>();

            while (true)
            {
                PrtMenu();

                Console.Write("\nEnter number: ");
                Int32 number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        Console.WriteLine("Flights:");
                        flights.ForEach(f => { Console.WriteLine(f.ToString()); });
                        break;
                    case 2:
                        {
                            Console.Write("\nEnter destination: ");
                            string destination = Console.ReadLine();
                            if (destination == null) break;
                            flights.Where(f => f.destination.ToLower().Equals(destination.ToLower()))
                                .ToList()
                                .ForEach(f =>
                                {
                                    Console.WriteLine(f);
                                });
                            break;
                        }
                    case 3:
                        {
                            Console.Write("\nEnter destination: ");
                            string destination = Console.ReadLine();
                            if (destination == null) break;
                            List<Flight> list = flights.Where(f => f.destination.ToLower().Equals(destination.ToLower()))
                                .ToList();

                            for (var i = 0; i < list.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {list[i]}");
                            }

                            Console.Write("\nEnter flight number: ");
                            Int32 flightNumber = Convert.ToInt32(Console.ReadLine());

                            Console.Write("\nEnter your name: ");
                            string name = Console.ReadLine();

                            Booking booking = new Booking(list[flightNumber - 1], name);
                            bookings.Add(booking);

                            Console.WriteLine("\nSuccessful. Your booking: ");
                            Console.WriteLine(booking);

                            break;
                        }
                    case 4:
                        {
                            Console.Write("\nEnter your name: ");
                            string name = Console.ReadLine();

                            bookings.Where(b => b.name.ToLower().Equals(name.ToLower()))
                                .ToList()
                                .ForEach(b =>
                                {
                                    Console.WriteLine(b);
                                });

                            break;
                        }
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Try again.");
                        break;
                }
            }
        }
    }
}