﻿public static class ConstantsGameSettings
{
    public static float CELL_SIZE = 1.0f;           //Сторона вокселя игрового пространства (одна игровая клетка)
    public static float BEYOND_BORDERS = 10.0f;     //Воксели за пределами Игрового поля, по которым можно перемещаться
    public static float RAY_COEF = 1.1f;            //Длина луча для проверки столкновения

    public static float TIME_ANIMATION = 1.0f;      //Скорость анимаций перемещения

    public static int BASE_EQUIPMENT_SLOTS = 3;     //Базовое кол-во слотов оснащения в корабле
}

public static class ConstantsTag
{
    public static string TAG_VOID = "Void";
    public static string TAG_PLAYER = "Player";
}

public static class ConstantsResourcesPath
{
    //Path
    public const string RESOURCES = "Assets/Resources/";
    public const string CONFIGS = "Configs/";
    public const string PREFABS = "Prefabs/";
    
    public const string SPACEOBJECTS = "Prefabs/Models/Objects/";
    public const string SPACESHIPS = "Prefabs/Models/SpaceShips/";

    public const string SPLASHSCREEN = "Prefabs/UI/SplashScreens/";
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

public static class ConstantsResourcesType
{
    public const string MONEY = "money";
    public const string SPACESHIP = "spaceship";
    public const string WEAPON = "weapon";
    public const string MODULE = "module";
    public const string AMMO = "ammo";
    public const string ENEMY = "enemy";
}

public static class ConstantsResourcesSubtype
{
    public const string COMMON = "common";
    public const string PREMIUM = "premium";
    public const string ENERGY = "energy";
}

public static class ConstantsSkill
{
    public const string NA = "NA";
    public const string SPECIAL_TARAN = "special_taran";
    public const string SPECIAL_MANEUVER = "special_maneuver";
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


    Player = 100,
}

//Типы скиллов
public enum EnumSkillType
{
    NA = 0,
    Active = 1,
    Passive = 2,
    Weapon = 3,
}

//Тип таргет-маркера на экране
public enum EnumUIMarkerType
{
    Default = 0,
    Player = 100,
}
#endregion



