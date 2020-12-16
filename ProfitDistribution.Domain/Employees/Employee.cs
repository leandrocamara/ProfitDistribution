using System;
using ProfitDistribution.Domain.ValueObjects;

namespace ProfitDistribution.Domain.Employees
{
    public class Employee
    {
        public string Registration { get; protected set; }
        public string Name { get; protected set; }
        public OccupationArea Area { get; protected set; }
        public Position Position { get; protected set; }
        public Money GrossMoney { get; protected set; }
        public DateTime AdmissionDate { get; protected set; }

        public static Employee New(
            string registration,
            string name,
            string area,
            string position,
            string grossSalary,
            DateTime admissionDate)
        {
            var employee = new Employee
            {
                Name = name,
                Registration = registration,
                Area = new OccupationArea(area),
                Position = new Position(position),
                GrossMoney = new Money(grossSalary),
                AdmissionDate = admissionDate
            };

            employee.Validate();

            return employee;
        }

        public double AdmissionTimeInYears()
        {
            return DateTime.Now.Subtract(AdmissionDate).TotalDays / 365;
        }

        private void Validate()
        {
            // TODO
        }

        private Employee()
        {
        }
    }
}