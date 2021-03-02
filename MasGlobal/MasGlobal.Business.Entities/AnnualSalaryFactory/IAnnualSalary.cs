﻿using System.Threading.Tasks;

namespace MasGlobal.Business.Entities.AnnualSalaryFactory
{
    public interface IAnnualSalary
    {
        Task<decimal> CalculateAnnualSalaryAsync();
    }
}
