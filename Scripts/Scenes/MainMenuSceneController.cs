﻿using DllSky.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//test git

public class MainMenuSceneController : Singleton<MainMenuSceneController>
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
        while (!Global.Instance.isComplete)
            yield return null;

        //-------------------------------
        //TODO: testing
        //------------------------------
        isInit = true;
    }
    #endregion
}
