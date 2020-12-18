using System;
using Newtonsoft.Json;
using ProfitDistribution.Domain.Employees;

namespace ProfitDistribution.Infrastructure.Repository.Repositories.Contracts
{
    public class EmployeeContract : IContract<Employee>
    {
        [JsonProperty(PropertyName = "matricula")] public string Registration { get; set; }
        [JsonProperty(PropertyName = "nome")] public string Name { get; set; }
        [JsonProperty(PropertyName = "area")] public string Area { get; set; }
        [JsonProperty(PropertyName = "cargo")] public string Position { get; set; }
        [JsonProperty(PropertyName = "salario_bruto")] public string GrossSalary { get; set; }
        [JsonProperty(PropertyName = "data_de_admissao")] public DateTime AdmissionDate { get; set; }

        public Employee Parse()
        {
            return Employee.New(Registration, Name, Area, Position, GrossSalary, AdmissionDate);
        }
    }
}