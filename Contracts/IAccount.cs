using System;
using System.Collections.Generic;
using System.Text;
using DigiBank.Classes;

namespace DigiBank.Contracts{
    public interface IAccount{
        void deposit(double amount);
        bool withdraw(double amount);
        double checkBalance(); 
        string getBankCode();
        string getBankAgency();
        string getAccountNumber();
        List<Statement>Statement();
    }
}
