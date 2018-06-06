using DllSky.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipObject : SpaceObject
{
    #region Variables

    private SpaceshipData data;
    private List<Skill> skills = new List<Skill>();
    #endregion

    #region Unity methods
    private void Start()
    {
        //TODO:
        base.Initialize();
    }
    #endregion

    #region Public methods
    public override void Initialize(object _data)
    {
        if (_data != null)
        {
            data = _data as SpaceshipData;

            hitPointsMax = data.hitPoints.ToInt();
            shieldPointsMax = data.shieldPoints.ToInt();
        }
        else
        {
            data = new SpaceshipData(Global.Instance.CONFIGS.spaceships[0].id);
        }

        base.Initialize();

        //Skills
        skills.Clear();
        for (int i = 0; i < data.skills.Length; i++)
        {
            var newSkill = new Skill(data.skills[i]);
            skills.Add(newSkill);
        }
        ApplySkills();
    }

    public SpaceshipData GetData()
    {
        return data;
    }
    #endregion

    #region Private methods
    private void ApplySkills()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            switch (skills[i].id)
            {
                case ConstantsSkill.NA:
                    break;
                case ConstantsSkill.SPECIAL_MANEUVER:
                    data.maneuver += skills[i].GetBonus(data.maneuver, data.level);
                    break;
            }
        }
    }
    #endregion

    #region Coroutines
    #endregion
}
