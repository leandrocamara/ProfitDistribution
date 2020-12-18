using System;
using ProfitDistribution.Domain.ValueObjects;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Shared;

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
            if (string.IsNullOrEmpty(Name))
                throw new InvalidFieldException(Messages.Format(Messages.RequiredProperty, nameof(Name)));

            if (string.IsNullOrEmpty(Registration))
                throw new InvalidFieldException(Messages.Format(Messages.RequiredProperty, nameof(Registration)));

            if (string.IsNullOrEmpty(Area.ToString()))
                throw new InvalidFieldException(Messages.Format(Messages.RequiredProperty, nameof(Area)));

            if (string.IsNullOrEmpty(Position.ToString()))
                throw new InvalidFieldException(Messages.Format(Messages.RequiredProperty, nameof(Position)));

            if (GrossMoney.IsNegative())
                throw new InvalidFieldException(Messages.Format(Messages.InvalidValue, nameof(GrossMoney)));

            if (AdmissionDate.Equals(DateTime.MinValue))
                throw new InvalidFieldException(Messages.Format(Messages.InvalidValue, nameof(AdmissionDate)));
        }

        private Employee()
        {
        }
    }
}