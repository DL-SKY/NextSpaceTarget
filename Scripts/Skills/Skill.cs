public class Skill
{
    #region Variables
    public string id;

    private SkillData data;
    #endregion

    #region Constructor
    public Skill(string _skillID)
    {
        id = _skillID;
        data = new SkillData( Global.Instance.CONFIGS.skills.GetConfig(id) );
    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    #endregion
}