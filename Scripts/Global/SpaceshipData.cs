

public class SpaceshipData : SpaceshipsConfig
{
    #region Variables
    public bool isPlayer;

    private SpaceshipsConfig config;
    #endregion

    #region Constructors
    public SpaceshipData(SpaceshipsConfig _currentData)
    {
        id = _currentData.id;
        name = _currentData.name;
        description = _currentData.description;
        level = _currentData.level;
        hitPoints = _currentData.hitPoints;
        shieldPoints = _currentData.shieldPoints;
        bonusWeapon = _currentData.bonusWeapon;
        cooldown = _currentData.cooldown;
        repairTime = _currentData.repairTime;
        coefLvlHP = _currentData.coefLvlHP;
        coefLvlBonus = _currentData.coefLvlBonus;
        coefLvlTaran = _currentData.coefLvlTaran;
        coefLvlCooldown = _currentData.coefLvlCooldown;
        coefLvlRepair = _currentData.coefLvlRepair;
        coefPriceLvl = _currentData.coefPriceLvl;
        skills = _currentData.skills;

        SetConfig();
}
    #endregion

    #region Public methods
    public SpaceshipsConfig GetConfig()
    {
        return config;
    }
    #endregion

    #region Private methods
    private void SetConfig()
    {
        config = Global.Instance.CONFIGS.spaceships.GetConfig(id);
    }
    #endregion
}