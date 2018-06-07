using DllSky.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipObject : SpaceObject
{
    #region Variables


    private SpaceshipData data;
    [SerializeField]
    private List<Skill> skills = new List<Skill>();
    [SerializeField]
    private List<Equipment> equipments = new List<Equipment>();
    #endregion

    #region Unity methods
    private void Start()
    {
        //TODO:
        base.Initialize();
        //Initialize();
    }
    #endregion

    #region Public methods
    public override void Initialize(object _data)
    {
        base.Initialize();

        if (_data != null)
            data = _data as SpaceshipData;
        else
            data = new SpaceshipData(Global.Instance.CONFIGS.spaceships[0].id, 1, null);        

        //Skills
        skills.Clear();
        for (int i = 0; i < data.skills.Length; i++)
        {
            var newSkill = new Skill(data.skills[i]);
            skills.Add(newSkill);
        }
        ApplySkills();

        //Equipments
        equipments.Clear();
        if (data.equipments != null)
            for (int i = 0; i < data.equipments.Count; i++)
            {
                var newEquipment = new Equipment(data.equipments[i]);
                equipments.Add(newEquipment);
            }

        //Spaceship
        ApplyLevel();
    }

    public SpaceshipData GetData()
    {
        return data;
    }

    public int GetLevel()
    {
        return data.level;
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

    private void ApplyLevel()
    {
        hitPointsMax = data.hitPoints.ToInt();
        shieldPointsMax = data.shieldPoints.ToInt();
    }
    #endregion

    #region Coroutines
    #endregion
}
