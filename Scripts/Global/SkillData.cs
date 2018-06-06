

public class SkillData : SkillsConfig
{
    #region Variables

    private SkillsConfig config;
    #endregion

    #region Constructors
    /*public SkillData(SkillsConfig _currentData)
    {
        this.Copy(_currentData);
        SetConfig();
    }*/

    public SkillData(string _id)
    {
        SetConfig(_id);
        this.Copy(config);        
    }
    #endregion

    #region Public methods
    public SkillsConfig GetConfig()
    {
        return config;
    }    
    #endregion

    #region Private methods
    private void SetConfig()
    {
        config = Global.Instance.CONFIGS.skills.GetConfig(id);
    }

    private void SetConfig(string _id)
    {
        config = Global.Instance.CONFIGS.skills.GetConfig(_id);
    }
    #endregion
}