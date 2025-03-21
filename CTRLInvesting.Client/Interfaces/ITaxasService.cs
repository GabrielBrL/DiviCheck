namespace CTRLInvesting.Client.Interfaces;

public interface ITaxasService
{
    double GetSelic();
    double GetCdi();
    Task<double> GetSelicAsync();
    Task<double> GetCdiAsync();
}
