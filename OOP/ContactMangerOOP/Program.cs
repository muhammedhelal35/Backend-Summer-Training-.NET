namespace ContactMangerOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "contacts.csv";
            ContactManger contactManager = new ContactManger(filePath);

            while (true)
            {
                ContactUI.ShowMenu();
                string userChoice = ContactUI.GetUserChoice();
                switch (userChoice)
                {
                    case "1":
                        contactManager.AddNewContact();
                        break;
                    case "2":
                        contactManager.EditContact();
                        break;
                    case "3":
                        contactManager.DeleteContact();
                        break;
                    case "4":
                        contactManager.ViewContacts();
                        break;
                    case "5":
                        Console.Write("Enter Contact Name: ");
                        string name = Console.ReadLine();
                        contactManager.SearchContact(name);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid Choice! Try Again.");
                        break;
                }
            }
        }
    }
}
