using ProfitDistribution.Domain.Employees;

namespace ProfitDistribution.Domain.Profits.WeightsParticipation
{
    public class WeightAdmissionDate : WeightParticipation
    {
        private const byte OneYear = 1;
        private const byte ThreeYear = 3;
        private const byte EightYear = 8;

        public static WeightAdmissionDate New(Employee employee)
        {
            var weight = new WeightAdmissionDate(employee);

            weight.DefineWeight();

            return weight;
        }

        protected override byte DefineWeight()
        {
            var admissionTimeInYears = Employee.AdmissionTimeInYears();

            if (admissionTimeInYears <= OneYear)
                return WeightOne;
            if (admissionTimeInYears > OneYear && admissionTimeInYears <= ThreeYear)
                return WeightTwo;
            if (admissionTimeInYears > ThreeYear && admissionTimeInYears <= EightYear)
                return WeightThree;

            return WeightFive;
        }

        private WeightAdmissionDate(Employee employee) : base(employee)
        {
        }
    }
}