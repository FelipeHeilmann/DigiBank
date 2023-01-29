using System;
using System.Collections.Generic;
using System.Text;
using DigiBank.Contracts;

namespace DigiBank.Classes{
    public abstract class Account : Bank, IAccount{

        public Account(){
            this.agencyNumber = "0001";
            Account.accountNumberSequential++;
            this.transitions = new List<Statement>();
        }

        public double Balance {get; protected set;}
        public string agencyNumber {get; private set;}
        public string accountNumber {get; protected set;}
        public static int accountNumberSequential {get; private set;}
        private List<Statement> transitions;
         public void deposit(double amount){
            DateTime actualDate = DateTime.Now;
            this.Balance+=amount;
            this.transitions.Add(new Statement(actualDate,"Depósito" ,amount));
         }
        public bool withdraw(double amount){
            if(amount > this.checkBalance()){
                return false;
            }  
            else{
                DateTime actualDate = DateTime.Now;
                this.transitions.Add(new Statement(actualDate,"Saque" ,amount));
                this.Balance-=amount;
                return true;
            }
        }
        public double checkBalance(){
            return this.Balance;
        } 
        public string getBankCode(){
            return this.bankCode;
        }
        public string getBankAgency(){
            return this.agencyNumber;
        }
        public string getAccountNumber(){
            return this.accountNumber;
        }

        public List<Statement> Statement(){
            return this.transitions;
        }    
    }
}