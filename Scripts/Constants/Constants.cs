public static class Constants
{

}

public static class ConstantsResourcesPath
{
    //Path
    public const string RESOURCES = "Assets/Resources/";
    public const string CONFIGS = "Configs/";
    public const string PREFABS = "Prefabs/";
    public const string SPLASHSCREEN = "Prefabs/UI/SplashScreens/";
    public const string SPACEOBJECTS = "Prefabs/SpaceObjects/";
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
}

public static class ConstantsScreen
{
    public const string MAIN_MENU = "MainMenuScreen";
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
public enum EnumObjectType
{
	NA = 0,
    Star,
    Planet,

	Spaceship,
}

//Типоразмер
public enum EnumSizeType
{
    NA = 0,
	XXS,
	XS,
	S,
	M,
	L,
	XL,
	XXL,
}

//Типы кораблей
public enum EnumShipType
{

}
#endregion



