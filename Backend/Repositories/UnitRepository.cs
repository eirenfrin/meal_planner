
using System.Runtime.CompilerServices;
using Backend;
using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UnitRepository(AppDbContext context) : IUnitRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Unit>> GetAllUnits(Guid userId)
    {
        var allUnits = await _context.Units
        .Where(u => u.CreatorId == userId || u.CreatorId == null).ToListAsync();

        return allUnits;
    }

    public async Task DeleteUnit(Unit unit)
    {
        _context.Units.Remove(unit);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBatchUnits(IEnumerable<Unit> unitsToDelete)
    {
        _context.Units.RemoveRange(unitsToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task AddNewUnit(Unit newUnit)
    {
        _context.Units.Add(newUnit);
        await _context.SaveChangesAsync();
    }

    public async Task EditUnit(Unit unitExisting, NewEditUnitDto unitEdited)
    {
        _context.Entry(unitExisting).CurrentValues.SetValues(unitEdited);
        await _context.SaveChangesAsync();
    }

    public async Task<Unit?> GetSingleUnit(Guid unitId)
    {
        var unit = await _context.Units.FindAsync(unitId);

        return unit;
    }

    public async Task<IEnumerable<Unit>> GetMultipleUnits(IEnumerable<Guid> ids)
    {
        var allUnitsByIds = await _context.Units
        .Where(unit => ids.Contains(unit.Id)).ToListAsync();

        return allUnitsByIds;
    }

    public async Task<bool> CheckUnitExistsByName(Guid? creatorId, string unitTitle, Guid? unitId = null)
    {
        // var exists = await _context.Units
        // .AnyAsync(u => u.Title == unitTitle && (u.CreatorId == creatorId || u.CreatorId == null) && u.Id != unitId);

        var query = _context.Units.AsQueryable();

        query = query.Where(u => u.Title == unitTitle && (u.CreatorId == creatorId || u.CreatorId == null));

        if (unitId != null)
        {
            query = query.Where(u => u.Id != unitId);
        }

        var exists = await query.AnyAsync();

        return exists;
    }
}