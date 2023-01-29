using System;
using System.Collections.Generic;
using System.Text;

namespace DigiBank.Classes{
    public class CurrentAccount : Account{
        public CurrentAccount(){
            this.accountNumber = "00" + Account.accountNumberSequential;
        }
    }
}