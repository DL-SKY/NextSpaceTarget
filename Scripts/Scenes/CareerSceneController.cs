using DllSky.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareerSceneController : Singleton<CareerSceneController>
{
    #region Variables
    [Header("Settings")]
    public bool isInit = false;
    #endregion

    #region Unity methods
    private void Start()
    {
        StartCoroutine(Initialize());
    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    #endregion

    #region Coroutines
    private IEnumerator Initialize()
    {
        yield return null;
        //-------------------------------
        //TODO: testing
        //------------------------------
        isInit = true;
    }
    #endregion
}
