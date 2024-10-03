using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactMangerOOP
{
    internal class ContactManger
    {
        private readonly string _filePath;
        private List<Contact> _contacts;

        public ContactManger(string filePath)
        {
            _filePath = filePath;
            _contacts = FileManger.LoadContacts(filePath);
        }

        public void AddNewContact()
        {
            Console.Clear();
            string contactName = PromptUser("Enter Contact Name: ");
            string phoneNumber = PromptUser("Enter Contact Number: ");
            _contacts.Add(new Contact { Name = contactName, PhoneNumber = phoneNumber });
            FileManger.SaveContacts(_contacts, _filePath);
            Console.WriteLine("Contact added successfully!");
        }

        public void EditContact()
        {
            Console.Clear();
            string name = PromptUser("Enter the name of the contact to edit: ");
            Contact contact = _contacts.Find(c => c.Name == name);
            if (contact != null)
            {
                contact.PhoneNumber = PromptUser("Enter new phone number: ");
                FileManger.SaveContacts(_contacts, _filePath);
                Console.WriteLine("Contact updated successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void DeleteContact()
        {
            Console.Clear();
            string name = PromptUser("Enter the name of the contact to delete: ");
            Contact contact = _contacts.Find(c => c.Name == name);
            if (contact != null)
            {
                _contacts.Remove(contact);
                FileManger.SaveContacts(_contacts, _filePath);
                Console.WriteLine("Contact deleted successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void ViewContacts()
        {
            Console.Clear();
            Console.WriteLine("=== Contact List ===");
            foreach (var contact in _contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}");
            }
        }

        public void SearchContact(string name)
        {
            Console.Clear();
            Contact contact = _contacts.Find(c => c.Name == name);
            if (contact != null)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        
        private string PromptUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
