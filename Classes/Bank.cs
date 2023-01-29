using System;
using System.Collections.Generic;
using System.Text;

namespace DigiBank.Classes{
    public abstract class Bank{
        public Bank(){
            this.bankName = "DigiBank";
            this.bankCode = "27";
        }

        public string bankName {get; private set;}
        public string bankCode {get; private set;}

    }
}