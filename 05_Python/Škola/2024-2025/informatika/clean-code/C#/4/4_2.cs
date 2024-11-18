Dictionary<string, int> settings = new Dictionary<string, int>
{
    { "volume", 70 },
    { "brightness", 50 }
};

Dictionary<string, int> AdjustBrightness(Dictionary<string, int> currentSettings, int level)
{
    var newSettings = new Dictionary<string, int>(currentSettings);
    newSettings["brightness"] = level;
    Console.WriteLine("Brightness set to: " + newSettings["brightness"]);
    return newSettings;
}

settings = AdjustBrightness(settings, 80); 