using System;
using ATMApp.Services; // Access BankingServices class

namespace ATMApp.View
{
    public static class BankingView
    {
        public static void Run()
        {
            double balance = 1000.00;  // Initialize balance
            bool continueRunning = true;

            Console.WriteLine("=== Simple ATM System ===");
            Console.WriteLine($"Initial Balance: ₱{balance:F2}");

            // Start the main loop for the ATM
            while (continueRunning)
            {
                // Display menu options to the user
                DisplayMenu();

                // Get user input
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                // Perform the action based on user input
                switch (option)
                {
                    case "1": // Check Balance
                        CheckBalance(balance);
                        break;

                    case "2": // Deposit Money
                        DepositMoney(ref balance);
                        break;

                    case "3": // Withdraw Money
                        WithdrawMoney(ref balance);
                        break;

                    case "4": // Print Mini Statement
                        PrintMiniStatement(balance);
                        break;

                    case "5": // Exit
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        continueRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option selected. Please try again.");
                        break;
                }
            }
        }

        // Display the ATM menu
        private static void DisplayMenu()
        {
            Console.WriteLine("\n--- ATM Menu ---");
            Console.WriteLine("1: Check Balance");
            Console.WriteLine("2: Deposit Money");
            Console.WriteLine("3: Withdraw Money");
            Console.WriteLine("4: Print Mini Statement");
            Console.WriteLine("5: Exit");
        }

        // Display current balance (Option 1: Check Balance)
        private static void CheckBalance(double balance)
        {
            Console.WriteLine($"Current Balance: ₱{balance:F2}");
        }

        // Deposit money into the account (Option 2: Deposit Money)
        private static void DepositMoney(ref double balance)
        {
            Console.Write("Enter amount to deposit: ");
            if (double.TryParse(Console.ReadLine(), out double depositAmount) && depositAmount > 0)
            {
                bool depositSuccess = BankingServices.Deposit(ref balance, depositAmount);
                if (depositSuccess)
                {
                    Console.WriteLine("Deposit successful.");
                    Console.WriteLine($"Updated Balance: ₱{balance:F2}");
                }
                else
                {
                    Console.WriteLine("Deposit failed. Invalid amount.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
            }
        }

        // Withdraw money from the account (Option 3: Withdraw Money)
        private static void WithdrawMoney(ref double balance)
        {
            Console.Write("Enter amount to withdraw: ");
            if (double.TryParse(Console.ReadLine(), out double withdrawAmount) && withdrawAmount > 0)
            {
                bool withdrawalSuccess;
                BankingServices.Withdraw(ref balance, withdrawAmount, out withdrawalSuccess);

                if (withdrawalSuccess)
                {
                    Console.WriteLine("Withdrawal successful.");
                    Console.WriteLine($"Updated Balance: ₱{balance:F2}");
                }
                else
                {
                    Console.WriteLine("Withdrawal failed. Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
            }
        }

        // Print mini statement (Option 4: Mini Statement)
        private static void PrintMiniStatement(double balance)
        {
            Console.WriteLine("--- Mini Statement ---");
            Console.WriteLine($"Current Balance: ₱{balance:F2}");
            // For simplicity, we'll assume the last transaction was a deposit of 1000
            // This can be replaced with a variable tracking the last transaction in a real scenario
            Console.WriteLine("Last Transaction Amount: ₱1000.00");
        }
    }
}
