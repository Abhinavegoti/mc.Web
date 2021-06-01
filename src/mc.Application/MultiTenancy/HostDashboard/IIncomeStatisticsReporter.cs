﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mc.MultiTenancy.HostDashboard.Dto;

namespace mc.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}