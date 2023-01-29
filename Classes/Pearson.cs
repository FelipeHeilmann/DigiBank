using System;
using System.Collections.Generic;
using System.Text;
using DigiBank.Contracts;

namespace DigiBank.Classes{
    public class Pearson{
        public string Name {get; private set;}
        public string CPF {get; private set;}
        public string Password {get; private set;}
        public IAccount Account {get; set;}

        public void setName(string name){
            this.Name = name;
        }

        public void setCPF(string cpf){
            this.CPF = cpf;
        }

        public void setPassword(string password){
            this.Password = password;
        }
    }
}
