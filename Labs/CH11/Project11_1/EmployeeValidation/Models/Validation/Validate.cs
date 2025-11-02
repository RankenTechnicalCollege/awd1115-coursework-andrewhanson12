namespace EmployeeValidation.Models.Validation
{
    public static class Validate
    {
        public static string CheckEmployee(SalesContext context, Employee employee)
        {
            var dbEmp = context.Employees.FirstOrDefault(e =>
            e.FirstName == employee.FirstName && e.LastName == employee.LastName && e.DOB == employee.DOB);

            if (dbEmp == null)
            {
                return "";
            }
            else
            {
                return $"Employee {employee.FullName} with date of birth {employee.DOB:d} already exists.";
            }
        }
        public static string CheckManagerEmployeeMatch (SalesContext context, Employee emp)
        {
            var manager = context.Employees.Find(emp.ManagerId);
            if (manager != null && manager.FirstName == emp.FirstName && manager.LastName == emp.LastName && manager.DOB == emp.DOB)
            {
                return "An employee cannot be their own manager.";
            }
            else
            {
                return "";
            }
        }
        public static string CheckSales(SalesContext context, Sales s1)
        {
            Sales? dbSale = context.Sales.FirstOrDefault(s =>
                s.Quarter == s1.Quarter && s.Year == s1.Year && s.EmployeeId == s1.EmployeeId);

            if (dbSale == null)
            {
                return "";
            }
            else
            {
                var emp = context.Employees.Find(s1.EmployeeId)!;
                return $"Sales record for quarter {s1.Quarter}, year {s1.Year} for {emp.FullName} already exists.";
            }
        }
    }
}
