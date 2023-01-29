using System;
using System.Collections.Generic;
using System.Text;

namespace DigiBank.Classes{
    public class Layout{
        private static List<Pearson> people = new List<Pearson>();
        private static int option =0 ;
        
        public static void MainScreen(){
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("                                              ");
            Console.WriteLine("          Digite a opção desejada             ");
            Console.WriteLine("          ===========================         ");
            Console.WriteLine("          1 - Criar Conta                     ");
            Console.WriteLine("          ===========================         ");
            Console.WriteLine("          2 - Entrar com CPF e Senha          ");
            Console.WriteLine("          ===========================         ");
            option = int.Parse(Console.ReadLine());
            
            switch(option){
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    LoginScreen();
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;    
            }
        }

        public static void CreateAccount(){
            Console.Clear();
            Console.WriteLine("                                               ");
            Console.WriteLine("          Digite o Nome:                       ");
            string name = Console.ReadLine();
            Console.WriteLine("          ===========================          ");
            Console.WriteLine("          Digite o CPF:                        ");
            string cpf = Console.ReadLine(); 
            Console.WriteLine("          ===========================          ");
            Console.WriteLine("          Digite a Senha:                      ");
            string password = Console.ReadLine();
            Console.WriteLine("          ===========================          ");

            CurrentAccount currentAccount = new CurrentAccount();
            Pearson pearson = new Pearson();
            pearson.setName(name);
            pearson.setCPF(cpf);
            pearson.setPassword(password);
            pearson.Account = currentAccount;
            



            people.Add(pearson);
            Console.Clear();
            Console.WriteLine("          Conta cadastrada com sucesso:        ");
            Console.WriteLine("          ===========================          ");
            Thread.Sleep(1000);
            LoggedScreen(pearson);
        }

        private static void LoginScreen(){
            Console.Clear();
             Console.WriteLine("          Digite o CPF:                        ");
            string cpf = Console.ReadLine(); 
            Console.WriteLine("          ===========================          ");
            Console.WriteLine("          Digite a Senha:                      ");
            string password = Console.ReadLine();
            Console.WriteLine("          ===========================          ");

            Pearson pearson = people.FirstOrDefault( x => x.CPF == cpf && x.Password == password);
            if(pearson != null){
                 WelcomeScreen(pearson);
                 LoggedScreen(pearson);
            } 
            else{
                Console.Clear();
                Console.WriteLine("          Pessoa não cadastrada:               ");
                Console.WriteLine("          ===========================          ");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void WelcomeScreen(Pearson pearson){
            string message = 
            $"{pearson.Name} | Banco: {pearson.Account.getBankCode()} | Agência: {pearson.Account.getBankAgency()}" +
            $" Conta: {pearson.Account.getAccountNumber()}" ;
            Console.WriteLine();
            Console.WriteLine($"      Seja bem vindo, {message}              ");
            Console.WriteLine();
        }

        private static void LoggedScreen(Pearson pearson){
            Console.Clear();
            WelcomeScreen(pearson);
            Console.WriteLine("             Digite a opção desejada               ");
            Console.WriteLine("             =========================             "); 
            Console.WriteLine("             1 - Realizar um depósito              ");
            Console.WriteLine("             =========================             "); 
            Console.WriteLine("             2 - Realizar um saque                 ");
            Console.WriteLine("             =========================             "); 
            Console.WriteLine("             3 - Consultar saldo                   ");
            Console.WriteLine("             =========================             "); 
            Console.WriteLine("             4 - Extrato                           ");
            Console.WriteLine("             =========================             "); 
            Console.WriteLine("             5 - Sair                              ");

            option = int.Parse(Console.ReadLine());
            switch(option){
                case 1:
                    depositScreen(pearson);
                    break;

                case 2:
                    withdrawScreen(pearson);
                    break;

                case 3: 
                    balanceScreen(pearson);
                    break;

                case 4:
                    statementScreen(pearson);
                    break;

                case 5:
                MainScreen();
                    break; 
                default:
                    Console.Clear();
                    Console.WriteLine("             Opção Inválida                        ");
                    Console.WriteLine("             =========================             "); 
                    break;              
            }
               
        }

        public static void depositScreen(Pearson pearson){
            Console.Clear();
            WelcomeScreen(pearson);
            Console.WriteLine("          Digite o valor do depósito:                 ");
            double amount = double.Parse(Console.ReadLine());
            Console.WriteLine("          ==========================                  ");
            pearson.Account.deposit(amount);
            Console.Clear();
            WelcomeScreen(pearson);
            Console.WriteLine("                                                      ");
            Console.WriteLine("                                                      ");
            Console.WriteLine("             Deposito realizado com sucesso           ");
            Console.WriteLine("             ==============================           ");
            Console.WriteLine("                                                      ");
            LoggedBack(pearson);

        }

        private static void LoggedBack(Pearson pearson){
            Console.WriteLine("             Entre com uma opção abaixo               ");
            Console.WriteLine("             =============================            ");
            Console.WriteLine("             1 - Voltar para minha conta              ");
            Console.WriteLine("             =============================            ");
            Console.WriteLine("             2 - Sair                                 ");
            Console.WriteLine("             =============================            ");
            option = int.Parse(Console.ReadLine());

            if(option == 1){
                LoggedScreen(pearson);
            }
            else{
                MainScreen();
            }
        }

        private static void UnloggedBack(){
            Console.WriteLine("             Entre com uma opção abaixo                   ");
            Console.WriteLine("             ================================             ");
            Console.WriteLine("             1 - Voltar para o menu principal             ");
            Console.WriteLine("             =================================            ");
            Console.WriteLine("             2 - Sair                                     ");
            Console.WriteLine("             =================================            ");
            option = int.Parse(Console.ReadLine());

            if(option == 1){
                MainScreen();
            }
            else{
                Console.WriteLine("             Opção Inválida                               ");
                Console.WriteLine("             =================================            ");
            }   
        }

        public static void withdrawScreen(Pearson pearson){
            Console.Clear();
            WelcomeScreen(pearson);
            Console.WriteLine("          Digite o valor do Saque:                    ");
            double amount = double.Parse(Console.ReadLine());
            Console.WriteLine("          ==========================                  ");
            bool withdraw = pearson.Account.withdraw(amount);
            Console.Clear();
            WelcomeScreen(pearson);
            Console.WriteLine("                                                      ");
            Console.WriteLine("                                                      ");
            if(withdraw){
                Console.WriteLine("             Saque realizado com sucesso              ");
                Console.WriteLine("             ==============================           ");
            }
            else{
                Console.WriteLine("             Saldo insufuciente!                      ");
                Console.WriteLine("             ==============================           ");
            }
            Console.WriteLine("                                                      ");
            LoggedBack(pearson);

        }

        private static void balanceScreen(Pearson pearson){
            Console.Clear();
            WelcomeScreen(pearson);
            Console.WriteLine($"             Seu saldo é: {pearson.Account.checkBalance()}              ");
            Console.WriteLine("             =================================                          ");
            Console.WriteLine("                                                                         ");
            LoggedBack(pearson); 
        }

        private static void statementScreen(Pearson pearson){
            Console.Clear();
            WelcomeScreen(pearson);
            if(pearson.Account.Statement().Any()){
                double total = pearson.Account.Statement().Sum(x => x.amount);
                foreach(Statement statement in pearson.Account.Statement()){
                    Console.WriteLine($"             Data: {statement.Date.ToString("dd/MM/yyyy HH:mm:ss")}                               ");
                    Console.WriteLine($"             Tipo de movimentação: {statement.Description}        ");
                    Console.WriteLine($"             Valor: R${statement.amount}                          ");
                    Console.WriteLine("             ================================                     ");
                    Console.WriteLine("                                                                  ");
                }
                Console.WriteLine("                                                          ");
                Console.WriteLine($"             Subtotal: {total}                           ");
                Console.WriteLine("             ================================             ");
                Console.WriteLine("                                                          ");
            }
            else{
                Console.WriteLine("             Não há extrato para ser exibido              ");
                Console.WriteLine("             ================================             ");
            }
            LoggedBack(pearson); 
        }
    }
}