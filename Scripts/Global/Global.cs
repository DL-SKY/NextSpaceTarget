using DllSky.Managers;
using DllSky.Patterns;
using DllSky.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Global : Singleton<Global>
{
    #region Variables
    public bool isComplete = false;
    public Configs CONFIGS;
    public GameSettings SETTINGS;
    public Profile PROFILE;
    #endregion

    #region Unity methods
    #endregion

    #region Public methods
    public void Initialize()
    {
        Debug.Log("[GLOBAL] Start GLOBAL initialize");
        InitConfigs();
        isComplete = true;
        Debug.Log("[GLOBAL] Complete GLOBAL initialize");
    }
    #endregion

    #region Private methods
    private void InitConfigs()
    {
        //Загрузка файла конфига
        var startTime = DateTime.UtcNow;        
        string json = ResourcesManager.Load<TextAsset>(ConstantsResourcesPath.CONFIGS, ConstantsResourcesPath.FILE_CONFIG).text;
        Debug.Log("[GLOBAL.CONFIG] Start load ConfigNST.json");
        CONFIGS = JsonUtility.FromJson<Configs>(json);
        CONFIGS.Sorting();
        Debug.Log("[GLOBAL.CONFIG] TOTAL TIME (ms): " + (DateTime.UtcNow - startTime).TotalMilliseconds);

        //Загрузка настроек
        //LOG - в методе
        SETTINGS = ExtensionGlobal.LoadSettings();

        //Вызов события смены языка локализации
        Debug.Log("[CONFIG] Calling the update event of the localization dictionary");
        EventManager.CallOnChangeLanguage();

        //Загрузка профиля Игрока
        //LOG - в методе
        PROFILE = ExtensionGlobal.LoadProfile();
    }
    #endregion

    #region Coroutines
    #endregion

    #region Context menu
    [ContextMenu("Check CONFIG")]
    private void CheckConfigNST()
    {
        var startTime = DateTime.UtcNow;        

        //Загрузка файла конфига
        Debug.Log("[CONFIG] Start load ConfigNST.json");
        string json = ResourcesManager.Load<TextAsset>(ConstantsResourcesPath.CONFIGS, ConstantsResourcesPath.FILE_CONFIG).text;
        Configs config = JsonUtility.FromJson<Configs>(json);
        config.Sorting();

        //Проверка "Localization"
        foreach (var item in config.localization)
        {
            if (string.IsNullOrEmpty(item.rus) || string.IsNullOrEmpty(item.eng))
                Debug.LogError("[CONFIG.Localization] Null or empty: " + item.id);
        }

        //Проверка "Resources"
        foreach (var item in config.resources)
        {
            object configObject = new object();
            switch (item.type)
            {
                case "spaceship":
                    configObject = config.spaceships.Find(x => x.id == item.id);
                    break;
                case "weapon":
                case "module":
                    configObject = config.equipments.Find(x => x.id == item.id);
                    break;
                case "ammo":
                    configObject = config.ammo.Find(x => x.id == item.id);
                    break;
                case "enemy":
                    configObject = config.enemies.Find(x => x.id == item.id);
                    break;
            }
            if (configObject == null)
                Debug.LogError("[CONFIG.Resources] Not found primary key: " + item.id);
        }

        //Проверка "Spaceships"
        foreach (var item in config.spaceships)
        {

        }

        //Проверка "Equipments"
        foreach (var item in config.equipments)
        {

        }

        //Проверка "Enemies"
        foreach (var item in config.enemies)
        {

        }

        Debug.Log("[CONFIG] Check complete");
        Debug.Log("[CONFIG] TOTAL TIME (ms): " + (DateTime.UtcNow - startTime).TotalMilliseconds);
    }

    [ContextMenu("Save SETTINGS")]
    private void SaveSettings()
    {
        SETTINGS.SaveSettings();
    }

    [ContextMenu("Save PROFILE")]
    private void SaveProfile()
    {
        PROFILE.SaveProfile();
    }
    #endregion
}

// ================= SETTINGS ================= \\
[Serializable]
public class GameSettings
{
    public string version;
    public string language;    
    public float volumeSound;
    public float volumeMusic;
    public bool mute;
    public bool vibration;

    public bool console;
    public bool debug;
}

// ================= PROFILE ================= \\
[Serializable]
public class Profile
{
    public Dictionary<string, int> Items;    
}

// ================= CONFIGS ================= \\
// Сам класс конфига + ниже классы 
[Serializable]
public class Configs
{
    //Таблицы из конфига (лучше сохранить последовательность)
    public List<SettingsConfig> settings = new List<SettingsConfig>();
    public List<LocalizationConfig> localization = new List<LocalizationConfig>();
    public List<ColorsConfig> colors = new List<ColorsConfig>();
    public List<RarityConfig> rarity = new List<RarityConfig>();
    public List<SkillsConfig> skills = new List<SkillsConfig>();
    public List<LevelSpaceshipConfig> levelSpaceship = new List<LevelSpaceshipConfig>();
    public List<LevelEquipmentConfig> levelEquipment = new List<LevelEquipmentConfig>();
    public List<ResourcesConfig> resources = new List<ResourcesConfig>();
    public List<SpaceshipsConfig> spaceships = new List<SpaceshipsConfig>();
    public List<EquipmentsConfig> equipments = new List<EquipmentsConfig>();
    public List<AmmoConfig> ammo = new List<AmmoConfig>();
    public List<EnemiesConfig> enemies = new List<EnemiesConfig>();    
}

[Serializable]
public class SettingsConfig
{
    public string id;
    public string value;
}

[Serializable]
public class LocalizationConfig
{
    public string id;
    public string rus;
    public string eng;
}

[Serializable]
public class ColorsConfig
{
    public string id;
    public string color;
}

[Serializable]
public class RarityConfig
{
    public string id;
    public string name;
    public string description;
    public string colorText;
    public string color1;
    public string color2;
}

[Serializable]
public class SkillsConfig
{
    public string id;
    public string name;
    public string description;
    public int minLevel;
    public string type;
    public float bonus;
    public float coefLvlBonus;
}

[Serializable]
public class LevelSpaceshipConfig
{
    public int level;
    public int experienceToNextLvl;
    public string priceToNextLvl;
}

[Serializable]
public class LevelEquipmentConfig
{
    public int level;
    public int cardsToNextLvl;
    public string priceToNextLvl;
}

[Serializable]
public class ResourcesConfig
{
    public string id;
    public string type;
    public string subtype;
    public string rarity;
    public float chance;
    public string image;
    public string background;
}

[Serializable]
public class SpaceshipsConfig
{
    public string id;
    public string name;
    public string description;
    public int level;
    public float hitPoints;
    public float shieldPoints;
    public float maneuver;
    public int repairTime;
    public float coefLvlHP;
    public float coefLvlManeuver;
    public float coefLvlRepair;
    public float coefPriceLvl;
    public string[] skills;
}

[Serializable]
public class EquipmentsConfig
{
    public string id;
    public string name;
    public string description;
    public int level;
    public string ammo;
    public float damage;
    public int targets;
    public int rounds;
    public int burst;
    public float accuracy;
    public float criticalChance;
    public float coefLvlDamage;
    public float coefLvlAccuracy;
    public float coefLvlCritical;
    public float coefPriceLvl;
    public string skill;
}

[Serializable]
public class AmmoConfig
{
    public string id;
    public string name;
    public string description;
}

[Serializable]
public class EnemiesConfig
{
    public string id;
    public string name;
    public string description;
    public int level;
    public float hp;
    public float damage;
    public float cooldown;
    public string skills;
}


