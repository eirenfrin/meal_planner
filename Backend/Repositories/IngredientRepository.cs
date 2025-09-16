
using Backend;
using Backend.Repositories.Interfaces;

public class IngredientRepository(AppDbContext context) : IIngredientRepository
{
    private readonly AppDbContext _context = context;
}