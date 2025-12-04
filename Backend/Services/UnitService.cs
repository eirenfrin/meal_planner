
using System.Data;
using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class UnitService(IUnitRepository unitRepository) : IUnitService
{
    private readonly IUnitRepository _unitRepository = unitRepository;

    public async Task<IEnumerable<GetUnitDto>> GetAllUnits(Guid userId)
    {
        var units = await _unitRepository.GetAllUnits(userId);

        var unitDtos = units.Select(u => new GetUnitDto
        {
            Id = u.Id,
            Title = u.Title,
            CreatorId = u.CreatorId
        });

        return unitDtos;
    }

    public async Task EditUnit(Guid unitId, NewEditUnitDto unitEdited)
    {
        var unit = await _unitRepository.GetSingleUnit(unitId);

        if (unit == null)
        {
            throw new KeyNotFoundException($"Unit with id {unitId} does not exist.");
        }

        if (unit.CreatorId == null)
        {
            throw new ConstraintException($"Cannot modify pre-defined units.");
        }

        var nameAlreadyTaken = await _unitRepository.CheckUnitExistsByName(unit.CreatorId, unitEdited.Title, unitId);

        if (nameAlreadyTaken)
        {
            throw new InvalidOperationException($"Unit {unitEdited.Title} already exists.");
        }

        await _unitRepository.EditUnit(unit, unitEdited);

    }

    public async Task<GetUnitDto> AddNewUnit(Guid creatorId, NewEditUnitDto unitNew)
    {
        var alreadyExists = await _unitRepository.CheckUnitExistsByName(creatorId, unitNew.Title);

        if (alreadyExists)
        {
            throw new InvalidOperationException($"Unit {unitNew.Title} already exists.");
        }

        var unit = new Unit
        {
            Id = Guid.NewGuid(),
            Title = unitNew.Title,
            CreatorId = creatorId
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
            throw new ConstraintException("Cannot delete pre-defined units.");
        }

        await _unitRepository.DeleteUnit(unit);
    }

    public async Task BatchDeleteUnits(BatchDeleteDto idsToDelete)
    {
        var unitsToDelete = await _unitRepository.GetMultipleUnits(idsToDelete.Ids);

        var missingIds = idsToDelete.Ids.Except(unitsToDelete.Select(unit => unit.Id));

        if (missingIds.Any())
        {
            throw new KeyNotFoundException($"Units with ids {missingIds} do not exist.");
        }

        if (unitsToDelete.Any(unit => unit.CreatorId == null))
        {
            throw new ConstraintException("Cannot delete pre-defined units.");
        }

        await _unitRepository.DeleteBatchUnits(unitsToDelete);
    }
}