using DllSky.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode00SceneController : Singleton<GameMode00SceneController>
{
    #region Variables
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
        ScreenManager.Instance.ShowScreen(ConstantsScreen.GAME_MODE_00);
    }
    #endregion
}
