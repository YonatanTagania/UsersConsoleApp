using System;

namespace UsersApp
{
    class Program
    {


        static void Main(string[] args)
        {

            List<User> users = new List<User>();
            User userOne = new User("yoni", "tagania", 1995, "yoni@csharp.com");
            User userTwo = new User("dani", "shovevani", 1999, "dani@csharp.com");
            User userThree = new User("makita", "sayian", 2005, "makita@csharp.com");
            User userFour = new User("moti", "taka", 1976, "moti@csharp.com");
            users.Add(userOne);
            users.Add(userTwo);
            users.Add(userThree);
            users.Add(userFour);
            CreateMenu(users);
            //PrintUsersList(users);
            //WriteListInfo(users);
            //PringListInfo(users);
            //PrintEachUser(users);
            //PrintSingleUser();

        }
        static void PrintUsersList(List<User> usersList)
        {
            usersList.Sort();
            for (int i = 0; i < usersList.Count; i++) {
                Console.WriteLine(usersList[i].UserInfo());
            }
        }
        static void WriteListInfo(List<User> usersList)
        {

            FileStream fs = new FileStream(@$"C:\Test\UsersListInfo.txt", FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fs)) {
                for (int i = 0; i < usersList.Count; i++) {
                    sw.WriteLine($"{i}-:{usersList[i].UserInfo()}");

                }
            }

        }

        static void PringListInfo(List<User> usersList)
        {
            FileStream fs = new FileStream($@"C:\Test\UsersListInfo.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fs)) {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        static void PrintEachUser(List<User> usersList)
        {
            for (int i = 0; i < usersList.Count; i++) {
                FileStream fs = new FileStream($@"C:\Test\{usersList[i].GetFirstName()}.txt", FileMode.Append);
                using (StreamWriter sw = new StreamWriter(fs)) {
                    sw.WriteLine(usersList[i].UserInfo());
                }
            }
        }
        static void PrintSingleUser()
        {
            FileStream fs = new FileStream($@"C:\Test\yoni.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fs)) {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        static void AddUser(List<User> usersList)
        {
            Console.WriteLine("add first name");
            string fName = Console.ReadLine();
            Console.WriteLine("add last name");
            string lName = Console.ReadLine();
            Console.WriteLine("add year of birth");
            int bYear = int.Parse(Console.ReadLine());
            Console.WriteLine("add your email");
            string email = Console.ReadLine();
            User newUser = new User(fName, lName, bYear, email);
            usersList.Add(newUser);
        }
        static void RemoveUser(List<User> usersList, string usrName)
        {
            for (int i = 0; i < usersList.Count; i++) {
                if (usrName == usersList[i].GetFirstName()) {
                    usersList.RemoveAt(i);
                }
            }
        }
        static void DisplayByName(List<User> usersList, string usrName)
        {
            for (int i = 0; i < usersList.Count; i++) {
                if (usrName == usersList[i].GetFirstName()) {
                    Console.WriteLine(usersList[i].UserInfo());
                }
            }
        }
        static void EditUserByName(List<User> userList,string usrName)
        {
            for(int i = 0;i < userList.Count;i++) {
                if(usrName == userList[i].GetFirstName()) {
                    userList[i] ={ }
                }
            }
        }

        static void CreateMenu(List<User> usersList)
        {
            Console.WriteLine("1.show all users\n2.add a user\n3.remove a user\n4.display user by name\n5.save all users in a file\n0.end program");
            int userChoice = int.Parse(Console.ReadLine());
            switch (userChoice) {
                case 1:
                    PrintUsersList(usersList);
                    CreateMenu(usersList);
                    break;
                case 2:
                    AddUser(usersList);
                    CreateMenu(usersList);
                    break;
                case 3:
                    Console.Write("enter the name of the student you want to remove\n");
                    string userName = Console.ReadLine();
                    RemoveUser(usersList, userName);
                    CreateMenu(usersList);
                    break;
                case 4:
                    Console.Write("enter the name of the student you want to display\n");
                    string nameToDisplay = Console.ReadLine();
                    DisplayByName(usersList, nameToDisplay);
                    CreateMenu(usersList);
                    break;
                case 5:
                    WriteListInfo(usersList);
                    CreateMenu(usersList);
                    break;
                case 0:
                    Console.Write("good bye!");
                    break;
                default:
                    Console.Write("wrong input!\n");
                    CreateMenu(usersList);
                    break;
            }
        }
    }
}

