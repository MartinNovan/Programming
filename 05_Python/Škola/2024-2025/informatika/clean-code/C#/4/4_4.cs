Dictionary<string, int> inventory = new Dictionary<string, int>
{
    { "Widget", 10 }
};

Dictionary<string, int> UpdateInventory(Dictionary<string, int> currentInventory, string product, int quantity)
{
    var newInventory = new Dictionary<string, int>(currentInventory);
    if (newInventory.ContainsKey(product))
    {
        newInventory[product] -= quantity;
        Console.WriteLine(quantity + " units of " + product + " sold.");
    }
    return newInventory;
}

inventory = UpdateInventory(inventory, "Widget", 5);
