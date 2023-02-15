using System;
using System.Collections.Generic;
using System.Text;

namespace DigiBank.Classes {
    public class Statement{
        public Statement(DateTime date, string description, double amount){
            this.Date = date;
            this.Description = description;
            this.amount = amount;
        }

        public DateTime Date {get; private set;}
        public string Description {get; private set;}
        public double amount {get; private set;}
    }
}
 