using System;

class CardHolder {
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance) {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getCardNum() {
        return cardNum;
    }
    public int getPin() {
        return pin;
    }
    public double getBalance() {
        return balance;
    }
    public string getFirstName() {
        return firstName;
    }
    public string getLastName() {
        return lastName;
    }

    public void setCardNum(string newCardNum) {
        cardNum = newCardNum;
    }
    public void setPin(int newPin) {
        pin = newPin;
    }
    public void setBalance(double newBalance) {
        balance = newBalance;
    }
    public void setFirstName(string newFirstName) {
        firstName = newFirstName;
    }
    public void setLastName( string newLastName) {
        lastName = newLastName;
    }

    public static void Main(String[] args){
        void printOptions(){
            Console.WriteLine("Please choose from one of the following options ...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser){
            Console.WriteLine("How much $$ would you lie to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance( currentUser.getBalance() + deposit);
            Console.WriteLine($"Thank you for trusting Webstam with your money. Current balance is: {currentUser.getBalance()}");
        }
        void withdraw(CardHolder currentUser){
            Console.WriteLine("How much do you want to withdraw from your account?");
            double withdraw = Double.Parse(Console.ReadLine());
            if(currentUser.getBalance() < withdraw){
                Console.WriteLine("Insufficient Balance");
            }else{
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("You're good to go! Thank you :");
            }
        }

        void balance(CardHolder currentUser){
            Console.WriteLine($"Your balance is {currentUser.getBalance()}");
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("125465879832",1234, "Sam", "John", 150.31));
        cardHolders.Add(new CardHolder("568715879832",4231, "Kim", "Ones", 300.31));
        cardHolders.Add(new CardHolder("125465805832",4321, "Brain", "Steen", 800.31));
        cardHolders.Add(new CardHolder("125465879832",2341, "paul", "kasee", 100.31));

        //promptt user 
        Console.WriteLine("Welcome to Simple  ATM");
        Console.WriteLine("Please insert your debt card: ");
        String debitCardNum ="";
        CardHolder currentUser;
        while(true){
            try{
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a=> a.cardNum == debitCardNum); 
                if(currentUser != null){
                    break;
                }else{
                    Console.WriteLine("Card not recognized. Please try again");
                    
                }
            }catch{
                Console.WriteLine("Card not recognized. please try again");
            }
        }

        Console.WriteLine("Please Enter your pin: ");
        int userPin =0;
        while(true){
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if(currentUser.getPin() == userPin){ break;
                }else{
                     Console.WriteLine("Incorrect Pin. Please try again");
                }
            }
            catch (System.Exception)
            {
                // throw;
                Console.WriteLine("Incorrect Pin. Please try again");
            }
        }

        Console.WriteLine($"Welcome {currentUser.firstName} :");
        int option =0;
        do{
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
                throw;
            }
            if(option == 1){ deposit(currentUser);}
            else if(option == 2){ withdraw(currentUser);}
            else if(option == 3){balance(currentUser);}
            else if(option == 4){break;}
            else{
                option = 0;
            }
        }while(option !=4);
        Console.WriteLine("Thank you! Have  a nice day :");



    }

}