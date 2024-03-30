public class DeviceTemplate
{

    public void UseOfDevice(string filePath, int optionDevice, string securePassword, List<string> correctSecurePassword, List<string> devicePasswords, ITextualRepository fileOperator)
    {
        do
        {
            Console.WriteLine("What do you want to do with your passwords: ");
            Console.WriteLine("1. Show all passwords");
            Console.WriteLine("2. Add new password");
            Console.WriteLine("3. Remove password");
            Console.WriteLine("4. Exit to previous page");

            var chooseDevice = Console.ReadLine();
            var IsParsableDevice = int.TryParse(chooseDevice, out optionDevice);
            Console.WriteLine();
            if(IsParsableDevice)
            {
                if (optionDevice == 1)
                {
                    do
                    {
                        Console.WriteLine("To see passwords, at first you have to put your secure password:");
                        securePassword = Console.ReadLine();
                        Console.WriteLine();

                        if (securePassword == correctSecurePassword[0])
                        {
                            int passwordId = 1;
                            foreach (var devicePassword in devicePasswords)
                            {
                                Console.WriteLine($"{passwordId}. {devicePassword}");
                                passwordId++;
                            }
                            Console.WriteLine();
                            break;
                        }
                        else if (securePassword != correctSecurePassword[0] && securePassword != "e" && securePassword != "E")
                        {
                            Console.WriteLine("Password was incorrect. Try again or type E to exit to previous menu.");
                        }
                    } while (securePassword != "e" && securePassword != "E");
                }
                else if (optionDevice == 2)
                {
                    Console.WriteLine("Write a Password you want to add:");
                    var newPassword = Console.ReadLine();
                    Console.WriteLine("Write a category, website, app for what this password is");
                    var newPasswordCategory = Console.ReadLine();
                    newPassword = $"{newPassword} ({newPasswordCategory})";
                    devicePasswords.Add(newPassword);
                    fileOperator.Write(filePath, devicePasswords);
                }
                else if (optionDevice == 3)
                {

                    do
                    {
                        Console.WriteLine("To see passwords, at first you have to put your secure password:");
                        securePassword = Console.ReadLine();

                        if (securePassword == correctSecurePassword[0])
                        {
                            Console.WriteLine("Your passwords list:");
                            int passwordId = 1;
                            foreach (var devicePassword in devicePasswords)
                            {
                                Console.WriteLine($"{passwordId}. {devicePassword}");
                                passwordId++;
                            }
                            Console.WriteLine("Type a id of password you want to delete:");
                            var passwordToDelete = Console.ReadLine();
                            var passwordToDeleteId = int.Parse(passwordToDelete);
                            devicePasswords.RemoveAt(passwordToDeleteId - 1);
                            fileOperator.Write(filePath, devicePasswords);
                            break;
                        }
                        else if (securePassword != correctSecurePassword[0] && securePassword != "e" && securePassword != "E")
                        {
                            Console.WriteLine("Password was incorrect. Try again or type E to exit to previous menu.");
                        }
                    } while (securePassword != "e" && securePassword != "E");
                }
                else
                {
                    Console.WriteLine("You have put wrong option. Try again.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("You have put wrong option. Try again.");
                Console.WriteLine();
            }
            
        } while (optionDevice != 4);
        
    }
}