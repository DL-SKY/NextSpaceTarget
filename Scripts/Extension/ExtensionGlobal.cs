using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class ExtensionGlobal
{
    #region GameSettings
    public static GameSettings LoadSettings()
    {
        var startTime = DateTime.UtcNow;
        string settingsPath = Path.Combine(Application.persistentDataPath, ConstantsResourcesPath.FILE_SETTINGS);
        Debug.Log("[GLOBAL.SETTINGS] Starting load settings: " + settingsPath);        

        if (File.Exists(settingsPath + ".json"))
        {
            string json = File.ReadAllText(settingsPath + ".json");

            Debug.Log("[GLOBAL.SETTINGS] Load settings complete");
            Debug.Log("[GLOBAL.SETTINGS] TOTAL TIME (ms): " + (DateTime.UtcNow - startTime).TotalMilliseconds);

            return JsonUtility.FromJson<GameSettings>(json);
        }
        else
        {
            GameSettings settings = new GameSettings();
            settings.ApplyDefaultSettings();

            Debug.Log("[GLOBAL.SETTINGS] File not found. Apply default settings");
            Debug.Log("[GLOBAL.SETTINGS] TOTAL TIME (ms): " + (DateTime.UtcNow - startTime).TotalMilliseconds);

            return settings;
        }
    }

    public static void SaveSettings(this GameSettings _gs)
    {
        var startTime = DateTime.UtcNow;
        string settingsPath = Path.Combine(Application.persistentDataPath, ConstantsResourcesPath.FILE_SETTINGS);
        Debug.Log("[GLOBAL.SETTINGS] Starting save settings: " + settingsPath);
        
        string json = JsonUtility.ToJson((GameSettings)_gs, true);

        if (!File.Exists(settingsPath + ".json"))
            File.Create(settingsPath + ".json").Dispose();

        File.WriteAllText(settingsPath + ".json", json);

        Debug.Log("[GLOBAL.SETTINGS] Save settings complete");
        Debug.Log("[GLOBAL.SETTINGS] TOTAL TIME (ms): " + (DateTime.UtcNow - startTime).TotalMilliseconds);
    }

    public static void ApplyDefaultSettings(this GameSettings _gs)
    {
        var settingsConfig = Global.Instance.CONFIGS.settings;

        _gs.version = settingsConfig.Find(x => x.id == "version").value;
        _gs.language = _gs.GetCurrentSystemLanguage();//settingsConfig.Find(x => x.id == "language").value;
        _gs.volumeSound = float.Parse(settingsConfig.Find(x => x.id == "volume_sound").value);
        _gs.volumeMusic = float.Parse(settingsConfig.Find(x => x.id == "volume_music").value);
        _gs.mute = bool.Parse(settingsConfig.Find(x => x.id == "mute").value);
        _gs.vibration = bool.Parse(settingsConfig.Find(x => x.id == "vibration").value);

        _gs.console = bool.Parse(settingsConfig.Find(x => x.id == "console").value);
        _gs.debug = bool.Parse(settingsConfig.Find(x => x.id == "debug").value);
    }

    public static string GetCurrentSystemLanguage(this GameSettings _gs)
    {
        var lang = Application.systemLanguage;
        string result = "";

        switch (lang)
        {
            case SystemLanguage.Russian:
                result = ConstantsLanguage.RUSSIAN;
                break;
            default:
                result = ConstantsLanguage.ENGLISH;
                break;
        }

        return result;
    }
    #endregion

    #region Profile
    public static Profile LoadProfile()
    {
        var startTime = DateTime.UtcNow;
        string profilePath = Path.Combine(Application.persistentDataPath, ConstantsResourcesPath.FILE_PROFILE);
        Debug.Log("[GLOBAL.PROFILE] Starting load profile: " + profilePath);        

        if (File.Exists(profilePath + ".json"))
        {
            string json = File.ReadAllText(profilePath + ".json");

            Debug.Log("[GLOBAL.PROFILE] Load profile complete");
            Debug.Log("[GLOBAL.PROFILE] TOTAL TIME (ms): " + (DateTime.UtcNow - startTime).TotalMilliseconds);

            return JsonUtility.FromJson<Profile>(json);
        }
        else
        {
            Profile profile = new Profile();
            //profile.ApplyDefaultSettings();

            Debug.Log("[GLOBAL.PROFILE] File not found. Apply default profile");
            Debug.Log("[GLOBAL.PROFILE] TOTAL TIME (ms): " + (DateTime.UtcNow - startTime).TotalMilliseconds);

            return profile;
        }
    }

    public static void SaveProfile(this Profile _pr)
    {
        var startTime = DateTime.UtcNow;
        string profilePath = Path.Combine(Application.persistentDataPath, ConstantsResourcesPath.FILE_PROFILE);
        Debug.Log("[GLOBAL.PROFILE] Starting save profile: " + profilePath);
        
        string json = JsonUtility.ToJson((Profile)_pr, true);

        if (!File.Exists(profilePath + ".json"))
            File.Create(profilePath + ".json").Dispose();

        File.WriteAllText(profilePath + ".json", json);

        Debug.Log("[GLOBAL.PROFILE] Save profile complete");
        Debug.Log("[GLOBAL.PROFILE] TOTAL TIME (ms): " + (DateTime.UtcNow - startTime).TotalMilliseconds);
    }

    public static int GetResource(this Profile _pr, string _id)
    {
        int result = 0;

        //todo:

        return result;
    }

    public static void AddResource(this Profile _pr, string _id, int _amount)
    {
        //todo:
    }
    #endregion

    #region Config
    public static void Sorting(this Configs _cg)
    {
        _cg.levelSpaceship = _cg.levelSpaceship.OrderBy(x => x.level).ToList();
        _cg.levelEquipment = _cg.levelEquipment.OrderBy(x => x.level).ToList();
    }
    #endregion

    #region SkillsConfig
    public static SkillsConfig GetConfig(this List<SkillsConfig> _confs, string _id)
    {
        return _confs.Find(x => x.id == _id);
    }

    public static void Copy(this SkillsConfig _cg1, SkillsConfig _cg2)
    {
        _cg1.id = _cg2.id;
        _cg1.name = _cg2.name;
        _cg1.description = _cg2.description;
        _cg1.minLevel = _cg2.minLevel;
        _cg1.type = _cg2.type;
    }

    public static void SkillsConfig(this SkillsConfig _cg1, SkillsConfig _cg2)
    {
        _cg1.Copy(_cg2);
    }
    #endregion

    #region SpaceshipsConfig
    public static SpaceshipsConfig GetConfig(this List<SpaceshipsConfig> _confs, string _id)
    {
        return _confs.Find(x => x.id == _id);
    }

    public static void Copy(this SpaceshipsConfig _cg1, SpaceshipsConfig _cg2)
    {
        _cg1.id = _cg2.id;
        _cg1.name = _cg2.name;
        _cg1.description = _cg2.description;
        _cg1.level = _cg2.level;
        _cg1.hitPoints = _cg2.hitPoints;
        _cg1.shieldPoints = _cg2.shieldPoints;
        _cg1.bonusWeapon = _cg2.bonusWeapon;
        _cg1.cooldown = _cg2.cooldown;
        _cg1.repairTime = _cg2.repairTime;
        _cg1.coefLvlHP = _cg2.coefLvlHP;
        _cg1.coefLvlBonus = _cg2.coefLvlBonus;
        _cg1.coefLvlTaran = _cg2.coefLvlTaran;
        _cg1.coefLvlCooldown = _cg2.coefLvlCooldown;
        _cg1.coefLvlRepair = _cg2.coefLvlRepair;
        _cg1.coefPriceLvl = _cg2.coefPriceLvl;
        _cg1.skills = _cg2.skills;
    }

    public static void SpaceshipsConfig(this SpaceshipsConfig _cg1, SpaceshipsConfig _cg2)
    {
        _cg1.Copy(_cg2);
    }
    #endregion
}
