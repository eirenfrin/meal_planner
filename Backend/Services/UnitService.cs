
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;
public class UnitService(IUnitRepository unitRepository) : IUnitService
{
    private readonly IUnitRepository _unitRepository = unitRepository;
}