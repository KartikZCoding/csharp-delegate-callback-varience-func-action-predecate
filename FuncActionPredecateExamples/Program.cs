namespace FuncActionPredecateExamples
{
    public class Program
    {
        delegate TResult Func2<out TResult>();
        delegate TResult Func2<in T1, out TResult>(T1 arg1);
        delegate TResult Func2<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        delegate TResult Func2<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);

        static void Main(string[] args)
        {
            //************** Func Example **************//

            //MathClass math = new MathClass();
            //Func<int, int, int> calc = math.Sum;

            //Func<int, int, int> calc = delegate (int a, int b) { return a + b; };
            //Func<int, int, int> calc = (a, b) => a + b;
            //Func2<int, int, int> calc = (a, b) => a + b;
            //Console.WriteLine($"Sum: {calc(1, 2)}");

            //float d= 2.25f, e = 4.46f;
            //int c = 5;
            //Func<float, float, int, float> calc2 = (arg1, arg2, arg3) => (arg1 + arg2) * arg3;
            //Console.WriteLine($"Answer: {calc2(d,e,c)}");

            //Func<decimal, decimal, decimal> calculateTotalAnnualSalary = (monthlySalary, bonus) => monthlySalary + (monthlySalary * (bonus / 100));
            //Console.WriteLine($"Total: {calculateTotalAnnualSalary(60000, 2)}");


            //************** Action Example **************//

            Action<int, string, string, decimal, char,bool> employeeDetails = (arg1, arg2, arg3, arg4,arg5,arg6) => Console.WriteLine($"Id: {arg1}\nFirst name: {arg2}\nLast name: {arg3}\nSalary: {arg4}\nGender: {arg5}\nIsManager: {arg6}");
            //employeeDetails(1, "John", "Doe");


            //************** Predicate Example **************//

            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Salary = 500,
                Gender = 'M',
                IsManager = false
            });
            employees.Add(new Employee()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Salary = 600,
                Gender = 'F',
                IsManager = true
            });
            employees.Add(new Employee()
            {
                Id = 3,
                FirstName = "Sam",
                LastName = "Smith",
                Salary = 550,
                Gender = 'M',
                IsManager = false
            });
            employees.Add(new Employee()
            {
                Id = 4,
                FirstName = "Sara",
                LastName = "Smith",
                Salary = 700,
                Gender = 'F',
                IsManager = true
            });

            //List<Employee> maleEmployees = FilterEmployee(employees,e => e.Gender == 'F');

            List<Employee> maleEmployees = employees.FilterEmployee(e => e.Gender == 'M');
            foreach (Employee item in maleEmployees)
            {
                employeeDetails(item.Id, item.FirstName, item.LastName, item.Salary, item.Gender, item.IsManager);
                Console.WriteLine();
            }


        }

        static List<Employee> FilterEmployee(List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> filteredEmployees = new List<Employee>();

            foreach (Employee emp in employees)
            {
                if (predicate(emp))
                {
                    filteredEmployees.Add(emp);
                }
            }
            return filteredEmployees;  
        }
    }

    public static class Extention
    {
       public static List<Employee> FilterEmployee(this List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> filteredEmployees = new List<Employee>();

            foreach (Employee emp in employees)
            {
                if (predicate(emp))
                {
                    filteredEmployees.Add(emp);
                }
            }
            return filteredEmployees;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Salary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }
    }

    public class MathClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

}
