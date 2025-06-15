using SSHOUSING.Domain.Entities;

public interface IBilling
{
    List<Billing> GetAllBilling();
    Billing GetBillingById(int id);
    bool AddBilling(Billing billing);
    bool UpdateBilling(Billing billing);
    bool DeleteBilling(int id);
    List<(string Month, decimal TotalRevenue)> GetMonthlyRevenueStats(); // if needed
}
