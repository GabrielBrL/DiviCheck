namespace CTRLInvesting.Api.Interfaces;

public interface ITaxasAnuaisService
{
    Task<double> GetSelic();
    Task<double> GetCdi();
}
