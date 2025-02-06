using System;
using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public class AdminUserHistoryService : IAdminUserHistoryService
    {
        private readonly ApplicationDbContext _context;

        public AdminUserHistoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddRecord(AdminChangesInUserTableHistory record)
        {
            _context.AdminChangesInUserTableHistory.Add(record);
            _context.SaveChangesAsync();
        }
    }
}
