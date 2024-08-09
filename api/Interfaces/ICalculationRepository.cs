using api.Models;

namespace api.Interfaces;

public interface ICalculationRepository
{
    Task<List<Calculator>> GetAllAsync();
}
