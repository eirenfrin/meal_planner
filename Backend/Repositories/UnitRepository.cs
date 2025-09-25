
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

    public async Task<Unit> AddNewUnit(Unit newUnit)
    {
        _context.Units.Add(newUnit);
        await _context.SaveChangesAsync();

        return newUnit;
    }

    public async Task EditUnit(Unit unitExisting, NewUnitDto unitEdited)
    {
        _context.Entry(unitExisting).CurrentValues.SetValues(unitEdited);
        await _context.SaveChangesAsync();
    }

    public async Task<Unit?> GetSingleUnit(Guid unitId)
    {
        var unit = await _context.Units.FindAsync(unitId);

        return unit;
    }

    public async Task<bool> CheckUnitExistsByName(string unitTitle)
    {
        var exists = await _context.Units
        .AnyAsync(u => u.Title == unitTitle);

        return exists;
    }
}