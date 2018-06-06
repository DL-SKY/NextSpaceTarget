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
        data = new SkillData(id);

        type = (EnumSkillType)Enum.Parse(typeof(EnumSkillType), data.type);
    }
    #endregion

    #region Public methods
    //Возвращает величину воздействия скилла в числовом эквиваленте
    public float GetBonus(float _arg, int _lvl)
    {
        int deltaLevel = _lvl - data.minLevel;
        float percent = data.bonus * (deltaLevel * data.coefLvlBonus);
        float result = _arg * percent;

        return result;
    }
    #endregion

    #region Private methods

    #endregion
}