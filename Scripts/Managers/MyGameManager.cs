using DllSky.Managers;
using DllSky.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : Singleton<MyGameManager>
{
    #region Variables
    #endregion

    #region Unity methods
    private void Start()
    {
        StartCoroutine(StartGame());
    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    private void ApplySettings()
    {
        Debug.Log("Application.targetFrameRate: " + Application.targetFrameRate);
    }
    #endregion

    #region Coroutine
    private IEnumerator StartGame()
    {
        //Стартовый прелоадер
        yield return SplashScreenManager.Instance.ShowStartingGame();
        //Инициализация конфига
        Global.Instance.Initialize();

        ApplySettings();

        //TEST 1: Загрузка тестовой сцены
        yield return new WaitForSeconds(5.0f);

        yield return SceneManager.LoadSceneAsync(ConstantsScene.MAIN_MENU, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(ConstantsScene.MAIN_MENU));
        while (!MainMenuSceneController.Instance.isInit)
        yield return null;
        yield return SplashScreenManager.Instance.HideSplashScreenImmediately();
        //-------------------

        //yield return SplashScreenManager.Instance.ShowBlack();


        //TEST 2:
        ScreenManager.Instance.ShowScreen(ConstantsScreen.MAIN_MENU);
        //-------------------

        //Test3:
        //int amount = 50000;
        //Debug.Log(DllSky.Utility.UtilityBase.GetStringFormatAmount3(amount));
        //Debug.Log(DllSky.Utility.UtilityBase.GetStringFormatAmount5(amount));
        //Debug.Log(DllSky.Utility.UtilityBase.GetStringFormatAmount6(amount));
        //-------------------



    }
    #endregion
}
