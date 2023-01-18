using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;
public sealed class MenuItem : Entity<MenuItemId>
{

    public string Name { get; }
    public string Description { get; }

    private MenuItem(MenuItemId Id, string name, string description): base(Id)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }
}