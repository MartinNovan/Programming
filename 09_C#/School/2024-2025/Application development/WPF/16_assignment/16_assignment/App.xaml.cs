﻿namespace _16_assignment;

public partial class App
{
    public App()
    {
        InitializeComponent();
        _ = FileHelpers.CreateAppFileIfNotExist();
        FileHelpers.LoadAllProfiles();
        FileHelpers.GetDefaultProfile();
        _ = FileHelpers.LoadProfile();
    }
}