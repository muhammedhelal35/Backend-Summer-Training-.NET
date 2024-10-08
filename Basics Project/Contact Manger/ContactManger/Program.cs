﻿using System.Data;
namespace ContactManger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FilePath = "contacts.csv";
            List<Contact> contacts = LoadContacts(FilePath);
            start:
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Welcome");
            Console.WriteLine("--- Contact Manger ---");
            Console.WriteLine("1 - If You Want To Add New Contact. ");
            Console.WriteLine("2 - If You Want To Edit Contact. ");
            Console.WriteLine("3 - If You Want To Remove Contact. ");
            Console.WriteLine("4 - If You Want To View Contacts. ");
            Console.WriteLine("5 - If You Want To Search.");
            Console.WriteLine("6 - If You Want To Exit. ");
            string UserChoise = Console.ReadLine();
            switch (UserChoise)
            {
                case "1":
                    AddNewContact(contacts);
                    SaveContacts(contacts, FilePath);
                    break;
                case "2":
                    EditContact(contacts);
                    SaveContacts(contacts, FilePath);
                    break;
                case "3":
                    DeleteContact(contacts);
                    SaveContacts(contacts, FilePath);
                    break;
                case "4":
                    ViewContacts(contacts);
                    break;
                case "5":
                    Console.Write("Enter Content Name :");
                    string name = Console.ReadLine();
                    SearchContact(contacts,name);
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("invalid Choice! Try Agin");
                    goto start;
            }
        }

        static List<Contact> LoadContacts(string FilePath)
        {
            List<Contact> contacts = new List<Contact>();
            if(File.Exists(FilePath)) 
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach(string line in lines)
                {
                    string[] Data = line.Split(',');
                    contacts.Add(new Contact { Name = Data[0], PhoneNumber = Data[1] });
                }
            }
            return contacts;
        }
        static void AddNewContact(List<Contact> contacts)
        {
            Console.Clear();
            Console.Write("Please Enter Contact Name   : ");
            string ContactName = Console.ReadLine();
            Console.Write("Please Enter Contact Number :");
            string Phonenumber = Console.ReadLine();

            contacts.Add(new Contact { Name = ContactName, PhoneNumber = Phonenumber });
            Console.WriteLine("Contact Add Successfully!");
        }
        static void SaveContacts(List<Contact> contacts,string FilePath)
        {
            List<string> lines = new List<string>();
            foreach (var contact in contacts)
            {
                lines.Add($"{contact.Name},{contact.PhoneNumber}");
            }
            File.WriteAllLines(FilePath, lines);
        }
        static void ViewContacts(List<Contact> contacts)
        {
            Console.Clear();
            Console.WriteLine("=== Contact List ===");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}");
            }
           
        }
        static void EditContact(List<Contact> contacts)
        {
            Console.Clear();
            Console.Write("Enter the name of the contact to edit: ");
            string name = Console.ReadLine();
            Contact contact = contacts.Find(c => c.Name == name);

            if (contact != null)
            {
                Console.Write("Enter new phone number: ");
                contact.PhoneNumber = Console.ReadLine();
                Console.WriteLine("Contact updated successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
        static void DeleteContact(List<Contact> contacts)
        {
            Console.Clear();
            Console.Write("Enter the name of the contact to delete: ");
            string name = Console.ReadLine();
            Contact contact = contacts.Find(c => c.Name == name);

            if (contact != null)
            {
                contacts.Remove(contact);
                Console.WriteLine("Contact deleted successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
        static void SearchContact(List<Contact> contacts,string name)
        {
            Console.Clear();
            foreach (var contact in contacts)
            {
                if (contact.Name == name)
                {
                    Console.WriteLine($"Name : {contact.Name},Phone Number : {contact.PhoneNumber}");
                }
            }
        }

    }
}
