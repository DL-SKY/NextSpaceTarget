using DllSky.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipObject : SpaceObject
{
    #region Variables

    private SpaceshipData data;
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
            data = new SpaceshipData(Global.Instance.CONFIGS.spaceships[0]);
        }

        base.Initialize();
    }

    public SpaceshipData GetData()
    {
        return data;
    }
    #endregion

    #region Private methods
    #endregion

    #region Coroutines
    #endregion
}
