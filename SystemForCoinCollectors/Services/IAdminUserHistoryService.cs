using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public interface IAdminUserHistoryService
    {
        public void AddRecord(AdminChangesInUserTableHistory record);
    }
}
