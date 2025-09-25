
using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class UnitService(IUnitRepository unitRepository) : IUnitService
{
    private readonly IUnitRepository _unitRepository = unitRepository;

    public async Task<IEnumerable<Unit>> GetAllUnits(Guid userId)
    {
        var units = await _unitRepository.GetAllUnits(userId);

        return units;
    }

    public async Task EditUnit(Guid unitId, NewUnitDto unitEdited)
    {
        var unit = await _unitRepository.GetSingleUnit(unitId);

        if (unit == null)
        {
            throw new KeyNotFoundException($"Unit with id {unitId} does not exist.");
        }

        if (unit.CreatorId == null)
        {
            throw new UnauthorizedAccessException($"Cannot modify pre-defined units.");
        }

        await _unitRepository.EditUnit(unit, unitEdited);

    }

    public async Task<GetUnitDto> AddNewUnit(NewUnitDto unitNew)
    {
        var alreadyExists = await _unitRepository.CheckUnitExistsByName(unitNew.Title);

        if (alreadyExists)
        {
            throw new InvalidOperationException($"Unit {unitNew.Title} already exists");
        }

        var unit = new Unit
        {
            Id = Guid.NewGuid(),
            Title = unitNew.Title,
            CreatorId = unitNew.CreatorId
        };

        await _unitRepository.AddNewUnit(unit);

        var unitDto = new GetUnitDto
        {
            Id = unit.Id,
            Title = unit.Title,
            CreatorId = unit.CreatorId
        };

        return unitDto;
    }

    public async Task DeleteUserDefinedUnit(Guid unitId)
    {
        var unit = await _unitRepository.GetSingleUnit(unitId);

        if (unit == null)
        {
            throw new KeyNotFoundException($"Unit with id {unitId} does not exist.");
        }

        if (unit.CreatorId == null)
        {
            throw new UnauthorizedAccessException($"Cannot delete pre-defined units.");
        }

        await _unitRepository.DeleteUnit(unit);
    }
}