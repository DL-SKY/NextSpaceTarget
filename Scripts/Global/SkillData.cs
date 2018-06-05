

public class SkillData : SkillsConfig
{
    #region Variables

    private SkillsConfig config;
    #endregion

    #region Constructors
    public SkillData(SkillsConfig _currentData)
    {
        this.Copy(_currentData);
        SetConfig();
    }
    #endregion

    #region Public methods
    public SkillsConfig GetConfig()
    {
        return config;
    }

    public void SetConfig(string _id)
    {
        config = Global.Instance.CONFIGS.skills.GetConfig(_id);
    }
    #endregion

    #region Private methods
    private void SetConfig()
    {
        config = Global.Instance.CONFIGS.skills.GetConfig(id);
    }    
    #endregion
}