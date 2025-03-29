using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;


namespace ConsoleApp3
{
    enum ImportanceRate
    {
        Important,
        MildlyImportant,
        NotImportant
    }
    
    class Task
    {

        
        public ImportanceRate Importance {get; set;}
        private DateTime dateTime;
        public string Name{get;set;}

        public Task(string name, ImportanceRate Importance, int hours, int minutes, int month, int day, int year)
        {
            Name = name;
            this.Importance = Importance;
            setTime(hours, minutes, day, year,month);

        }

        public void setTime(int hours, int minutes, int day, int year, int month)
        {
            dateTime = dateTime.AddHours(hours);
            dateTime = dateTime.AddMinutes(minutes);
            dateTime = dateTime.AddDays(day);
            dateTime = dateTime.AddMonths(month);
            dateTime = dateTime.AddYears(year);

        }
        public void ShowTime()
        {
            Console.WriteLine("    "+dateTime);
        }

        
    }
    class Category
    {
        public Category(string CategoryName)
        {
            this.CategoryName = CategoryName;
        }
        public List<Task> tasks = new List<Task> {};
        public string CategoryName{get;set;}


        public void DeleteTask(int index)
        {  
            tasks.RemoveAt(index);
        }
        public void AddTask(string name, ImportanceRate Importance, int hours, int minutes, int month, int day, int year)
        {
            Task task1 = new Task(name, Importance, hours, minutes, month, day, year);
            tasks.Add(task1);
        } 
        public void ShowInfo()
        {
            int i = 0;
            foreach(var item in tasks)
            {
               Console.WriteLine("  "+item.Name + " - " + i);
               Console.WriteLine("    "+item.Importance);
               item.ShowTime();
               i++;
            }
        }

        

        

    }

    class Menu
    {
        public List<Category> categories = new List<Category> {};

        public void DeleteCategory(int index)
        {  
            categories.RemoveAt(index);
        }
        public void AddCategory(string Name)
        {
            Category category = new Category(Name);
            categories.Add(category);
        } 

        public void ShowInfo()
        {
            int i = 0;
            foreach(var item in categories)
            {
               Console.WriteLine(" " + item.CategoryName.ToUpper() + " - " + i);
               
               i++;
            }
        }
    }

    class Programm
    {
        static void Main( )
        {
            Menu menu = new Menu();
            
            string CatName = " ";
            while(true)
            {
                Console.WriteLine("Your Categories:");
                menu.ShowInfo();
                
                Console.WriteLine("_________________________________________________________");

                Console.WriteLine("To Create Category type 1");
                Console.WriteLine("To Delete Category type 2");
                Console.WriteLine("To Choose a Category type 3");
                Console.WriteLine("To Exit type 4");
                Console.WriteLine();
                

                int numberToSelect = -1;

                while(numberToSelect !=  1 && numberToSelect !=  2 && numberToSelect != 3 && numberToSelect != 4)
                {
                    int.TryParse(Console.ReadLine(), out numberToSelect);
                }
                if(numberToSelect == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the Name:");
                    
                    CatName = Console.ReadLine() ?? "Default Category";
                    Console.WriteLine();
                    

                    menu.AddCategory(CatName);
                
                    
                }
                else if(menu.categories.Count != 0 && numberToSelect == 2)
                {
                    int index = -1;
                    while(index < 0 || index > (menu.categories.Count -1))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter Number of Category");
                        index = int.Parse(Console.ReadLine() ?? "0");
                    }

                    if(menu.categories.Any())
                    {
                        menu.DeleteCategory(index);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("You have no categories");
                        Console.WriteLine();
                    }
                    
                }
                else if(numberToSelect == 3)
                {
                    if(menu.categories.Any())
                    {

                    
                        Console.WriteLine();
                        int index = -1;
                        while(index < 0 || index > (menu.categories.Count - 1))
                        {
                            Console.WriteLine("Select index of a category:");
                            index = int.Parse(Console.ReadLine() ?? "0");
                        }
                        
                        while(true)
                        {
                            Console.WriteLine("Your Tasks:");
                            menu.categories[index].ShowInfo();
                            int numberToSelectTask = -1;
                            Console.WriteLine("_________________________________________________________________________________________");
                            Console.WriteLine("Type 1 to Add Task, 2 to Delete Task, 3 to return to categories");

                            while(numberToSelectTask !=  1 && numberToSelectTask !=  2 && numberToSelectTask != 3 )
                            {
                                int.TryParse(Console.ReadLine(), out numberToSelectTask);
                            }
                            if(numberToSelectTask == 1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter the Name:");
                                string Name = Console.ReadLine() ?? "Default";
                                Console.WriteLine();
                                Console.WriteLine("Enter the Importance Rate:");
                                Console.WriteLine("  0 - Important");
                                Console.WriteLine("  1 - Mildly Important");
                                Console.WriteLine("  2 - Not Important");
                                if (Enum.TryParse(Console.ReadLine(), true, out ImportanceRate importance))
                                {
                                    
                                }
                                else
                                {
                                    importance = 0;
                                }
                                Console.WriteLine();
                                

                                bool isTrue = false;
                                int hour = 0;
                                do
                                {
                                    Console.WriteLine("Enter hours:");
                                    isTrue = int.TryParse(Console.ReadLine(), out hour);
                                    
                                }while(isTrue == false || hour < 0 || hour > 23);
                                Console.WriteLine();
                                
                                
                                isTrue = false;
                                int minute = 0;
                                do
                                {
                                    Console.WriteLine("Enter Minutes:");
                                    isTrue = int.TryParse(Console.ReadLine(), out minute);
                                    
                                }while(isTrue == false || minute > 59 || minute < 1);
                                Console.WriteLine();
                                

                                isTrue = false;
                                int day = 0;
                                do
                                {
                                    Console.WriteLine("Enter the day");
                                    isTrue = int.TryParse(Console.ReadLine(), out day);
                                    
                                }while(isTrue == false || day < 1 || day > 31);
                                Console.WriteLine();
                                

                                isTrue = false;
                                int month = 0;
                                do
                                {
                                    Console.WriteLine("Enter the month");
                                    isTrue = int.TryParse(Console.ReadLine(), out month);
                                    
                                }while(isTrue == false || month < 1 || month > 12);
                                Console.WriteLine();
                                

                                isTrue = false;
                                int year = 0;
                                do
                                {
                                    Console.WriteLine("Enter the year");
                                    isTrue = int.TryParse(Console.ReadLine(), out  year);
                                    
                                }while(isTrue == false || year < DateTime.Now.Year || year > 9999 );
                                Console.WriteLine();
                                
                                menu.categories[index].AddTask(Name, importance, hour, minute, day, month, year );

                            }
                            if(menu.categories[index].tasks.Count != 0 && numberToSelectTask == 2)
                            {
                                int index1 = -1;
                                while(index1 < 0 || index1 > (menu.categories[index].tasks.Count - 1))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Select number of Task:");
                                
                                    index1 =int.Parse( Console.ReadLine() ?? "0");
                                }

                                if(menu.categories[index].tasks.Any())
                                {
                                        
                                        
                                    menu.categories[index].DeleteTask(index1);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    index1 =int.Parse( Console.ReadLine() ?? "0");
                                    menu.categories[index].DeleteTask(index1);
                                    Console.WriteLine();
                                }
                                
                                
                            }
                            if(numberToSelectTask == 3)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have no categories");
                        Console.WriteLine();
                    }
                }
                else if(numberToSelect == 4)
                {
                    break;
                }

                

            }
                        
        }
    }
}