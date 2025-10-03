
using System.Threading.RateLimiting;
using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class ShoppingListRepository(AppDbContext context) : IShoppingListRepository
{
    private readonly AppDbContext _context = context;

    public async Task<ShoppingList?> GetShoppingListWithAllInfo(Guid listId)
    {
        var shoppingList = await _context.ShoppingLists
        .Include(sl => sl.ShoppingListIngredients)
            .ThenInclude(sli => sli.Unit)
        .FirstOrDefaultAsync(sl => sl.Id == listId);

        return shoppingList;
    }

    public async Task<IEnumerable<ShoppingList>> GetAllShoppingLists(Guid userId)
    {
        var shoppingLists = await _context.ShoppingLists
        .Where(sl => sl.CreatorId == userId).ToListAsync();

        return shoppingLists;
    }

    public async Task AddNewShoppingList(ShoppingList newShoppingList)
    {
        _context.ShoppingLists.Add(newShoppingList);
        await _context.SaveChangesAsync();
    }

    public async Task<ShoppingList> EditShoppingList(ShoppingList shoppingListUpdated)
    {
        var shoppingListExisting = await GetSingleShoppingList(shoppingListUpdated.Id);
        _context.Entry(shoppingListExisting).CurrentValues.SetValues(shoppingListUpdated);
        await _context.SaveChangesAsync();

        return shoppingListExisting;
    }

    public async Task<ShoppingList?> GetSingleShoppingList(Guid shoppingListId)
    {
        var shoppingList = await _context.ShoppingLists.FindAsync(shoppingListId);

        return shoppingList;
    }

    public async Task<bool> CheckShoppingListAlreadyExistsByTitle(string title)
    {
        var exists = await _context.ShoppingLists.AnyAsync(sl => sl.Title == title);

        return exists;
    }

    public async Task DeleteShoppingList(ShoppingList shoppingList)
    {
        _context.ShoppingLists.Remove(shoppingList);
        await _context.SaveChangesAsync();
    }

}