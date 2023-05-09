﻿using Models;

namespace SuperSaiyanProjekt.Services
{
    public interface ITimeReport : IRepository<TimeReport>
    {
        Task<TimeReport> GetHoursInWeek(int employeeid, int week);
    }
}