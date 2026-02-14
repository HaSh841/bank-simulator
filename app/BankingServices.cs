namespace ATMApp.Services
{
    public static class BankingServices
    {
        public static double GetBalance(double balance)
        {
            return balance;
        }

        public static bool Deposit(ref double balance, double amount)
        {
            // Validate deposit amount
            if (amount > 0)
            {
                balance += amount;  // Modify balance with the deposit
                return true;         // Return true for successful deposit
            }
            else
            {
                return false;        // Return false if the deposit amount is invalid
            }
        }

        public static void Withdraw(ref double balance, double amount, out bool isSuccessful)
        {
            isSuccessful = false;

            if (amount <= 0)
            {
                return; // Invalid withdrawal amount, return early
            }

            if (amount <= balance)
            {
                balance -= amount;    // Deduct the amount from balance
                isSuccessful = true;  // Set success flag to true
            }
            else
            {
                isSuccessful = false; // Insufficient balance, set to false
            }
        }
    }
}
