
using System;
namespace PhoneBookApp
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            // Initialize phonebook
            PhoneBook phonebook = new PhoneBook();

            // Print the initial phone book list
            Console.WriteLine("Phone book list:");
            phonebook.PrintList();

            // Print a sorted list by name
            Console.WriteLine("\nSorted List:");
            phonebook.SortByName();
            phonebook.PrintList();

            // Print a 2D array 
            Console.WriteLine("\nUsing a 2D array instead of two 1D arrays:");
            string[,] phonelist = phonebook.Create2DArrayWithRowNumbers();
            Display2DArray(phonelist);
        }

        // Method to display a 2D array
        static void Display2DArray(string[,] data)
        {
            // Get the number of rows in the data array
            int rows = data.GetLength(0);

            // Determine maximum lengths for formatting
            int maxRowNumberLength = (rows).ToString().Length;
            int maxNameLength = data.Cast<string>().Where((value, index) => index % 2 == 0).Max(value => value.Length);
            int maxPhoneLength = data.Cast<string>().Where((value, index) => index % 2 != 0).Max(value => value.Length);

            // Output the formatted data
            for (int i = 0; i < rows; i++)
            {
                string rowNumber = $"Row {i + 1}".PadRight(maxRowNumberLength + 7);
                string name = data[i, 0].PadRight(maxNameLength + 5);
                string phoneNumber = data[i, 1].PadRight(maxPhoneLength);
                Console.WriteLine($"{rowNumber} {name}{phoneNumber}");
            }
        }
    }

    // Class representing a PhoneBook
    class PhoneBook
    {
        // Array containing names
        private string[] names = { "Bob", "Alice", "Bim", "David", "Erik" };
        // Array containing corresponding phone numbers
        private string[] phones = { "123-456-7890", "234-567-8901", "345-678-9012", "456-789-0123", "074-156-9643" };

        // Method to print the list of names and phone numbers
        public void PrintList()
        {
            for (int i = 0; i < names.Length; i++)
            {
                string line = string.Format("{0,-15} {1,-15}", names[i], phones[i]);
                Console.WriteLine(line);
            }
        }

        // Method to sort the names and corresponding phone numbers by name
        public void SortByName()
        {
            for (int i = 0; i < names.Length - 1; i++)
            {
                for (int j = 0; j < names.Length - 1 - i; j++)
                {
                    if (string.Compare(names[j], names[j + 1]) > 0)
                    {
                        // Swap names
                        string tempName = names[j];
                        names[j] = names[j + 1];
                        names[j + 1] = tempName;

                        // Swap corresponding phone numbers
                        string tempPhone = phones[j];
                        phones[j] = phones[j + 1];
                        phones[j + 1] = tempPhone;
                    }
                }
            }
        }

        // Method to create a 2D array with names and corresponding phone numbers
        public string[,] Create2DArrayWithRowNumbers()
        {
            int rows = names.Length;
            int cols = 2; // Name and phone number

            string[,] data = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                data[i, 0] = names[i]; // Name
                data[i, 1] = phones[i]; // Phone number
            }

            return data;
        }
    }
}



