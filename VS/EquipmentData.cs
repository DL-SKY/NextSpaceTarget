public class EquipmentData : EquipmentsConfig
{
    #region Variables

    private EquipmentsConfig config;
    #endregion

    #region Constructors
    public EquipmentData(string _id)
    {
        SetConfig(_id);
        this.Copy(config);
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
    #endregion
}