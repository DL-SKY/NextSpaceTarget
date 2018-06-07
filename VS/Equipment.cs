public class Equipment
{
    #region Variables
    public string id;
    public string type;
    public string subtype;

    private EquipmentData data;
    #endregion

    #region Constructors
    public Equipment(string _id)
    {
        id = _id;
        data = new EquipmentData(id);

        var res = Global.Instance.CONFIGS.resources.Find(x => x.id == id);
        if (res != null)
        {
            type = res.type;
            subtype = res.subtype;
        }
        else
        {
            type = subtype = null;
        }
    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    #endregion
}