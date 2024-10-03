using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactMangerOOP
{
    internal class FileManger
    {
        public static List<Contact> LoadContacts(string filePath)
        {
            List<Contact> contacts = new List<Contact>();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    contacts.Add(new Contact { Name = data[0], PhoneNumber = data[1] });
                }
            }
            return contacts;
        }

        public static void SaveContacts(List<Contact> contacts, string filePath)
        {
            List<string> lines = new List<string>();
            foreach (var contact in contacts)
            {
                lines.Add($"{contact.Name},{contact.PhoneNumber}");
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
