

using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingListController : ControllerBase
{
    private readonly ILogger<ShoppingListController> _logger;
    // private readonly IShoppingListService _service;


    // pages: browse all existing shopping lists (actions show contents of shopping list)


    public ShoppingListController(ILogger<ShoppingListController> logger/*, IShoppingListService service*/)
    {
        _logger = logger;
        //_service = service;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<ShoppingList> GetSingleShoppingList(Guid id)
    {
        // displays title, startdate, is defaul and all ingredients and their amount to buy (required by recipe, package size, or not specified)
        // fetches from shoppingList, shoppingListIngredient, ingredient, *unit
        return Ok();
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<ShoppingList>> GetAllShoppingLists()
    {
        // displays title, startdate, isDefault
        // fetches from shoppingList
        return Ok();
    }

    [HttpPost]
    public ActionResult<ShoppingList> CreateNewShoppingList() //takes dto
    {
        // modifies shoppingList, shoppingListIngredient
        return Ok();
    }

    [HttpPost("generated")]
    public ActionResult<ShoppingList> GenerateShoppingListFromPlannedRecipes() //takes dto
    {
        // fetches from userCookedRecipe, recipe, unitsRecipe, recipeIngredient, ingredient
        // modifies shoppingList, shoppingListIngredient
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult<ShoppingList> EditShoppingList(Guid id) //takes dto
    {
        // modifies shoppingList, shoppingListIngredient
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteSingleShoppingList(Guid id)
    {
        // modifies shoppingList, shoppingListIngredient
        return Ok();
    }

}