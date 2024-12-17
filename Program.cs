using System.Globalization;
using Course.Entities;
namespace Course
{
    public class Program
    {
        public static void Main(string[]args)
        {
            var list = new List<Employee>();
            Console.WriteLine("Enter the full file path");
            string filePath = Console.ReadLine();
            Console.WriteLine("enter the salary: ");
            double salary = double.Parse(Console.ReadLine());
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string [] line = sr.ReadLine().Split(',');
                    string name = line[0];
                    string email = line[1];
                    double employeeSalary = double.Parse(line[2]);
                    list.Add(new Employee(name, email, employeeSalary));
                }
            }

            var moreSalary = list.Where(p => p.Salary > salary).Select(p => p.Email);
            Console.WriteLine($"email of people whose salary is more than {salary}");
            foreach (var emailsInList in list)
            {
                Console.WriteLine(emailsInList);
            }

            var inicialName = list.Where(p => p.Name.StartsWith("M")).Sum(p => p.Salary);

            Console.WriteLine($"sum of salary of people whose name start with 'M' {inicialName.ToString("F2", CultureInfo.InvariantCulture)}");

        }
    }
}