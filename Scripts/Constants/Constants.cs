﻿public static class ConstantsGameSettings
{
    public static float CELL_SIZE = 1.0f;
}

public static class ConstantsResourcesPath
{
    //Path
    public const string RESOURCES = "Assets/Resources/";
    public const string CONFIGS = "Configs/";
    public const string PREFABS = "Prefabs/";
    public const string SPLASHSCREEN = "Prefabs/UI/SplashScreens/";
    public const string SPACEOBJECTS = "Prefabs/Models/Objects/";
    public const string SCREENS = "Prefabs/UI/Screens/";
    public const string DIALOGS = "Prefabs/UI/Dialogs/";
    public const string ELEMENTS_UI = "Prefabs/UI/Elements/";

    //File name
    public const string FILE_CONFIG = "ConfigNST";
    public const string FILE_SETTINGS = "SettingsNST";
    public const string FILE_PROFILE = "ProfileNST";
}

public static class ConstantsScene
{
    public const string MAIN_SCENE = "Main";
    public const string MAIN_MENU = "MainMenu";
    public const string CAREER = "Career";
    public const string GAME_MODE_00 = "GameMode00";
}

public static class ConstantsScreen
{
    public const string MAIN_MENU = "MainMenuScreen";
    public const string CAREER = "CareerScreen";
    public const string GAME_MODE_00 = "GameMode00Screen";
}

public static class ConstantsDialog
{
    public const string SETTINGS = "SettingsDialog";
}

public static class ConstantsColor
{
    public const string DARK_AMBER = "dark_amber";
    public const string TIZIANO = "tiziano";
    public const string DEAD_INDIGO = "dead_indigo";
    public const string AZURE_GRAY = "azure_gray";
    public const string AZURE_KRAOLA = "azure_kraola";
    public const string LIGHT_KRAOLA = "light_kraola";
}

public static class ConstantsLanguage
{
    public const string RUSSIAN = "rus";
    public const string ENGLISH = "eng";
}

#region ENUM
//Тип объекта
public enum EnumSpaceObject
{
    Void = 0,
    Box = 1,
}
#endregion



