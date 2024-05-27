using System;
using System.Collections.Generic;

public class Guest
{
    public int Age { get; set; }
    public decimal Price { get; set; }

    public Guest(int age)
    {
        Age = age;
        Price = CalculatePrice(age);
    }

    private decimal CalculatePrice(int age)
    {
        if (age <= 2)
        {
            return 0;
        }
        else if (age > 2 && age < 18)
        {
            return 100;
        }
        else if (age >= 18 && age < 60)
        {
            return 500;
        }
        else
        {
            return 300;
        }
    }
}

public class Ticket
{
    public string TicketID { get; set; }
    public List<Guest> Guests { get; set; }
    public decimal TotalPrice { get; set; }

    public Ticket(string ticketID)
    {
        TicketID = ticketID;
        Guests = new List<Guest>();
        TotalPrice = 0;
    }

    public void AddGuest(Guest guest)
    {
        Guests.Add(guest);
        TotalPrice += guest.Price;
    }

    public void DisplayTicketDetails()
    {
        Console.WriteLine($"Ticket ID: {TicketID}");
        for (int i = 0; i < Guests.Count; i++)
        {
            Console.WriteLine($"Guest {i + 1} (age: {Guests[i].Age}, price: INR {Guests[i].Price})");
        }
        Console.WriteLine($"Total Price: INR {TotalPrice}");
    }
}

public class ZooTicketingSystem
{
    private Dictionary<string, Ticket> tickets;

    public ZooTicketingSystem()
    {
        tickets = new Dictionary<string, Ticket>();
    }

    public void IssueTicket()
    {
        string ticketID = Guid.NewGuid().ToString();
        Ticket ticket = new Ticket(ticketID);

        Console.WriteLine("Enter the number of guests:");
        int numberOfGuests = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfGuests; i++)
        {
            Console.WriteLine($"Enter age of guest {i + 1}:");
            int age = int.Parse(Console.ReadLine());
            Guest guest = new Guest(age);
            ticket.AddGuest(guest);
        }

        tickets[ticketID] = ticket;

        Console.WriteLine("Ticket issued successfully!");
        ticket.DisplayTicketDetails();
    }

    public void ValidateTicket()
    {
        Console.WriteLine("Enter the Ticket ID to validate:");
        string ticketID = Console.ReadLine();

        if (tickets.ContainsKey(ticketID))
        {
            Ticket ticket = tickets[ticketID];
            Console.WriteLine("Validating ticket...");
            ticket.DisplayTicketDetails();
        }
        else
        {
            Console.WriteLine("Invalid Ticket ID.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ZooTicketingSystem ticketingSystem = new ZooTicketingSystem();
        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("Choose an option: 1. Issue Ticket 2. Validate Ticket 3. Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ticketingSystem.IssueTicket();
                    break;
                case 2:
                    ticketingSystem.ValidateTicket();
                    break;
                case 3:
                    continueRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
