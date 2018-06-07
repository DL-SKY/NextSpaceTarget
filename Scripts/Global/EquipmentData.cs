public class EquipmentData : EquipmentsConfig
{
    #region Variables

    private EquipmentsConfig config;
    #endregion

    #region Constructors
    public EquipmentData(string _id, int _lvl)
    {
        SetConfig(_id);
        this.Copy(config);

        level = _lvl;

        ApplyLevel();
    }
    #endregion

    #region Public methods
    public EquipmentsConfig GetConfig()
    {
        return config;
    }
    #endregion

    #region Private methods
    private void SetConfig()
    {
        config = Global.Instance.CONFIGS.equipments.GetConfig(id);
    }

    private void SetConfig(string _id)
    {
        config = Global.Instance.CONFIGS.equipments.GetConfig(_id);
    }

    private void ApplyLevel()
    {
        if (level > 1)
        {
            damage = config.damage * ((level - 1) * config.coefLvlDamage);
            accuracy = config.accuracy * ((level - 1) * config.coefLvlAccuracy);
            criticalChance = config.criticalChance * ((level - 1) * config.coefLvlCritical);
        }
    }
    #endregion
}