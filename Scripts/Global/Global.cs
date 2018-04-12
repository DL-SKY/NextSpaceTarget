using DllSky.Managers;
using DllSky.Patterns;
using DllSky.Utility;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Global : Singleton<Global>
{
    #region Variables
    public bool isComplete = false;
    public Configs CONFIGS;
    public GameSettings SETTINGS;
    #endregion

    #region Unity methods
    #endregion

    #region Public methods
    public void Initialize()
    {
        Debug.Log("Start GLOBAL initialize");
        InitConfigs();
        isComplete = true;
        Debug.Log("Complete GLOBAL initialize");
    }
    #endregion

    #region Private methods
    private void InitConfigs()
    {
        Debug.Log("Start load Config.json");
        string json = ResourcesManager.Load<TextAsset>(ConstantsResourcesPath.CONFIGS, "ConfigNST").text;
        CONFIGS = JsonUtility.FromJson<Configs>(json);

        Debug.Log("Start load Settings.json");
        //SETTINGS = json
        SETTINGS = new GameSettings();
        SETTINGS.language = ConstantsLanguage.RUSSIAN;

        Debug.Log("Calling the update event of the localization dictionary");
        EventManager.CallOnChangeLanguage();
    }
    #endregion

    #region Coroutines
    #endregion

    #region Context menu
    [ContextMenu("Show JSON (SpaceShipData)")]
    private void ShowJSONSpaceShipData()
    {
        /*if (CONFIGS.spaceshipsData.Count < 1)
        {
            Debug.Log("CONFIGS.spaceshipsData.Count < 1");
            return;
        }

        string _strJson;
        _strJson = JsonUtility.ToJson((SpaceShipData)CONFIGS.spaceshipsData[0], true);
        Debug.Log(_strJson);*/
    }
    #endregion
}

// ================= SETTINGS ================= \\
[System.Serializable]
public class GameSettings
{
    public string language = ConstantsLanguage.RUSSIAN;

    public void ApplyDefault()
    {

    }
}

// ================= CONFIGS ================= \\
// Сам класс конфига + ниже классы 
[System.Serializable]
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

    //Сортировка...
    //configuration.ClanMembers = configuration.ClanMembers.OrderBy(x => x.level).ToList();
}

[System.Serializable]
public class SettingsConfig
{
    public string id;
    public string value;
}

[System.Serializable]
public class LocalizationConfig
{
    public string id;
    public string rus;
    public string eng;
}

[System.Serializable]
public class ColorsConfig
{
    public string id;
    public string color;
}

[System.Serializable]
public class RarityConfig
{
    public string id;
    public string name;
    public string description;
    public string colorText;
    public string color1;
    public string color2;
}

[System.Serializable]
public class SkillsConfig
{
    public string id;
    public string name;
    public string description;
    public string type;
}

[System.Serializable]
public class LevelSpaceshipConfig
{
    public int level;
    public int experienceToNextLvl;
    public string priceToNextLvl;
}

[System.Serializable]
public class LevelEquipmentConfig
{
    public int level;
    public int cardsToNextLvl;
    public string priceToNextLvl;
}

[System.Serializable]
public class ResourcesConfig
{
    public string id;
    public string type;
    public string subtype;
    public string rarity;
    public float chance;
}

[System.Serializable]
public class SpaceshipsConfig
{
    public string id;
    public string name;
    public string description;
    public int level;
    public float hp;
    public float bonusWeapon;
    public float damageTaran;
    public float cooldown;
    public int repairTime;
    public float coefLvlHP;
    public float coefLvlBonus;
    public float coefLvlTaran;
    public float coefLvlCooldown;
    public float coefLvlRepair;
    public float coefPriceLvl;
    public string[] skills;
}

[System.Serializable]
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

[System.Serializable]
public class AmmoConfig
{
    public string id;
    public string name;
    public string description;
}

[System.Serializable]
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


