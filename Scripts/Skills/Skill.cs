using System;

public class Skill
{
    #region Variables
    public string id;
    public EnumSkillType type;

    private SkillData data;
    #endregion

    #region Constructor
    public Skill(string _skillID)
    {
        id = _skillID;
        data = new SkillData( Global.Instance.CONFIGS.skills.GetConfig(id) );

        type = (EnumSkillType)Enum.Parse(typeof(EnumSkillType), data.type);
    }
    #endregion

    #region Public methods
    //Возвращает величину воздействия скилла в числовом эквиваленте
    public float Apply(float _arg)
    {
        float result = 0.0f;

        switch (id)
        {
            case ConstantsSkill.NA:
                result = 0.0f;
                break;
            case default:
                return 0.0f;
        }

        return result;
    }
    #endregion

    #region Private methods

    #endregion
}