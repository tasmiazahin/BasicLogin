namespace LogIn;
class Program
{
    static void Main(string[] args)
    {
        User[] arrUsers = new User[] {
            new User("Tasmia","1234"),
            new User("Alex", "abcd")
        };

        
        newlogin:
            bool successful = false;
            Console.WriteLine("Welcome to your account, Please login");
            Console.WriteLine("Enter your username");
            string username=  Console.ReadLine();

            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            foreach (var item in arrUsers)
            {
                if (item.UserName ==username && item.Password == password)
                {
                    Console.WriteLine("You have logged in successfully!");
                    successful = true;
                    bool repeat = true;
                    bool isTerminated = false;

                    while (repeat)
                    {

                        Console.WriteLine("Select your option");
                        Console.WriteLine("[1] Change Password");
                        Console.WriteLine("[2] Logout");
                        Console.WriteLine("[3] Terminate  the program");
                        Int32.TryParse(Console.ReadLine(), out int input);
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Enter your new password");
                                string newPassword = Console.ReadLine();

                                var index = Array.FindIndex(arrUsers, a => a.UserName == username);
                                arrUsers[index].Password = newPassword;
                                break;

                            case 2:
                                Console.WriteLine("You have logged out");
                                repeat = false;
                                break;

                            case 3:
                                Console.WriteLine("Program terminated");
                                repeat = false;
                                isTerminated = true;
                                break;

                            default:
                                break;
                        }
                        if (!repeat && !isTerminated)
                        {
                            goto newlogin;
                        }
                    }
                }  
            }

            if (successful==false)
            {
                Console.WriteLine("Log in unsuccessful and try again");
                goto newlogin;
            }
        
        Console.ReadLine();
    }
}

public class User
{
    public string UserName;
    public string Password;

    public User(string username, string password)
    {
        UserName = username;
        Password = password;
    }
}

