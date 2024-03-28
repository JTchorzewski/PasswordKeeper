string choose;
bool IsParsable;
int option;
int optionPhone;
int optionDevice;
int optionComputer;
int optionOthers;

do
{
    Console.WriteLine("***********************************************************");
    Console.WriteLine("              Welcome in your password keeper              ");
    Console.WriteLine("                Choose what you want to do:                ");
    Console.WriteLine("                    1. Choose device                       ");
    Console.WriteLine("              2. Change you secure password                ");
    Console.WriteLine("                    3. Exit program                        ");
    Console.WriteLine("***********************************************************");    
    
    choose = Console.ReadLine();
    Console.WriteLine();
    IsParsable = int.TryParse(choose, out option);

    if(option == 1)
    {
        do
        {
            Console.WriteLine("You have two connected devices:");
            Console.WriteLine("1. Phone");
            Console.WriteLine("2. Computer");
            Console.WriteLine("3. Others");
            Console.WriteLine("4. Exit to previous page");
            Console.WriteLine("Which one you want to use?: ");
           
            var chooseDevice = Console.ReadLine();
            var isParsableDevice = int.TryParse(chooseDevice, out optionDevice);
            Console.WriteLine();

            if (optionDevice == 1)
            {
                var fileOperator = new StringsTextualRepository();
                var phonePasswords = fileOperator.Read("phone.txt");
                do
                {
                    Console.WriteLine("What do you want to do with your passwords: ");
                    Console.WriteLine("1. Show all passwords");
                    Console.WriteLine("2. Add new password");
                    Console.WriteLine("3. Remove password");
                    Console.WriteLine("4. Exit to previous page");
                    
                    var choosePhone = Console.ReadLine();
                    string securePassword;
                    var correctSecurePassword = fileOperator.Read("securePassword.txt");
                    var IsParsablePhone = int.TryParse(choosePhone, out optionPhone);
                    Console.WriteLine();
                    if (optionPhone == 1)
                    {
                        do
                        {
                            Console.WriteLine("To see passwords, at first you have to put your secure password:");
                            securePassword = Console.ReadLine();


                            if (securePassword == correctSecurePassword[0])
                            {
                                int passwordId = 1;
                                foreach (var phonePassword in phonePasswords)
                                {
                                    Console.WriteLine($"{passwordId}. {phonePassword}");
                                    passwordId++;
                                }
                                break;
                            }
                            else if(securePassword != correctSecurePassword[0] && securePassword != "e" && securePassword != "E")
                            {
                                Console.WriteLine("Password was incorrect. Try again or type E to exit to previous menu.");
                            }
                        } while (securePassword != "e" && securePassword != "E");
                    }
                    else if (optionPhone == 2)
                    {
                        Console.WriteLine("Write a Password you want to add:");
                        var newPassword = Console.ReadLine();
                        Console.WriteLine("Write a category, website, app for what this password is");
                        var newPasswordCategory = Console.ReadLine();
                        newPassword = $"{newPassword} ({newPasswordCategory})";
                        phonePasswords.Add(newPassword);
                        fileOperator.Write("phone.txt", phonePasswords);
                    }
                    else if (optionPhone == 3)
                    {
                        Console.WriteLine("Your passwords list:");
                        int passwordId = 1;
                        foreach (var phonePassword in phonePasswords)
                        {
                            Console.WriteLine($"{passwordId}. {phonePassword}");
                            passwordId++;
                        }
                        Console.WriteLine("Type a id of password you want to delete:");
                        var passwordToDelete = Console.ReadLine();
                        var passwordToDeleteId = int.Parse(passwordToDelete);
                        phonePasswords.RemoveAt(passwordToDeleteId - 1);
                        fileOperator.Write("phone.txt", phonePasswords);
                    }
                    Console.WriteLine();
                } while (optionPhone != 4);
            }
            else if (optionDevice == 2)
            {
                var fileOperator = new StringsTextualRepository();
                var computerPasswords = fileOperator.Read("computer.txt");
                do
                {
                    Console.WriteLine("What do you want to do with your passwords: ");
                    Console.WriteLine("1. Show all passwords");
                    Console.WriteLine("2. Add new password");
                    Console.WriteLine("3. Remove password");
                    Console.WriteLine("4. Exit to previous page");

                    var chooseComputer = Console.ReadLine();
                    var IsParsableComputer = int.TryParse(chooseComputer, out optionComputer);
                    Console.WriteLine();
                    if (optionComputer == 1)
                    {
                        int passwordId = 1;
                        foreach (var computerPassword in computerPasswords)
                        {
                            Console.WriteLine($"{passwordId}. {computerPassword}");
                            passwordId++;
                        }
                    }
                    else if (optionComputer == 2)
                    {
                        Console.WriteLine("Write a Password you want to add:");
                        var newPassword = Console.ReadLine();
                        Console.WriteLine("Write a category, website, app for what this password is");
                        var newPasswordCategory = Console.ReadLine();
                        newPassword = $"{newPassword} ({newPasswordCategory})";
                        computerPasswords.Add(newPassword);
                        fileOperator.Write("computer.txt", computerPasswords);
                    }
                    else if (optionComputer == 3)
                    {
                        Console.WriteLine("Your passwords list:");
                        int passwordId = 1;
                        foreach (var computerPassword in computerPasswords)
                        {
                            Console.WriteLine($"{passwordId}. {computerPassword}");
                            passwordId++;
                        }
                        Console.WriteLine("Type a id of password you want to delete:");
                        var passwordToDelete = Console.ReadLine();
                        var passwordToDeleteId = int.Parse(passwordToDelete);
                        computerPasswords.RemoveAt(passwordToDeleteId - 1);
                        fileOperator.Write("computer.txt", computerPasswords);
                    }
                    Console.WriteLine();
                } while (optionComputer != 4);
            }
            else if (optionDevice == 3)
            {
                var fileOperator = new StringsTextualRepository();
                var othersPasswords = fileOperator.Read("others.txt");
                do
                {
                    Console.WriteLine("What do you want to do with your passwords: ");
                    Console.WriteLine("1. Show all passwords");
                    Console.WriteLine("2. Add new password");
                    Console.WriteLine("3. Remove password");
                    Console.WriteLine("4. Exit to previous page");

                    var chooseOthers = Console.ReadLine();
                    var IsParsableOthers = int.TryParse(chooseOthers, out optionOthers);
                    Console.WriteLine();
                    if (optionOthers == 1)
                    {
                        int passwordId = 1;
                        foreach (var othersPassword in othersPasswords)
                        {
                            Console.WriteLine($"{passwordId}. {othersPassword}");
                            passwordId++;
                        }
                    }
                    else if (optionOthers == 2)
                    {
                        Console.WriteLine("Write a Password you want to add:");
                        var newPassword = Console.ReadLine();
                        Console.WriteLine("Write a category, website, app for what this password is");
                        var newPasswordCategory = Console.ReadLine();
                        newPassword = $"{newPassword} ({newPasswordCategory})";
                        othersPasswords.Add(newPassword);
                        fileOperator.Write("others.txt", othersPasswords);
                    }
                    else if (optionOthers == 3)
                    {
                        Console.WriteLine("Your passwords list:");
                        int passwordId = 1;
                        foreach (var othersPassword in othersPasswords)
                        {
                            Console.WriteLine($"{passwordId}. {othersPassword}");
                            passwordId++;
                        }
                        Console.WriteLine("Type a id of password you want to delete:");
                        var passwordToDelete = Console.ReadLine();
                        var passwordToDeleteId = int.Parse(passwordToDelete);
                        othersPasswords.RemoveAt(passwordToDeleteId - 1);
                        fileOperator.Write("others.txt", othersPasswords);
                    }
                    Console.WriteLine();
                } while (optionOthers != 4);
            }
            Console.WriteLine();
        } while(optionDevice != 4);
    }

    else if (option == 2)
    {
        var fileOperator = new StringsTextualRepository();
        var securePassword = fileOperator.Read("securePassword.txt");

        Console.WriteLine(@"To change your secure password, first you have to
type present secure password:");
        string securePasswordByUser;
        do
        {
            securePasswordByUser = Console.ReadLine();
            if (securePasswordByUser == securePassword[0])
            {
                Console.WriteLine("Password is correct!");
                Console.WriteLine("Type your new secure password:");
                var newSecurePassword = Console.ReadLine();
                securePassword[0] = newSecurePassword;
                fileOperator.Write("securePassword.txt", securePassword);
                break;
            }
            else if(securePasswordByUser != securePassword[0] && securePasswordByUser != "E" && securePasswordByUser != "e")
            {
                Console.WriteLine("You put wrong password");
                Console.WriteLine($"Try again or press E to back to previous menu");
            }
        } while (securePasswordByUser != "E" && securePasswordByUser != "e");
    }

    else if(option != 1 && option != 2 && option != 3)
    {
        Console.WriteLine("You have choose a wrong option. Try to put one from above.");
    }
    Console.WriteLine();
} while (option != 3);

public class StringsTextualRepository
{
    private static readonly string Separator = Environment.NewLine;

    public List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return fileContents.Split(Separator).ToList();
    }

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, string.Join(Separator, strings));
    }
}