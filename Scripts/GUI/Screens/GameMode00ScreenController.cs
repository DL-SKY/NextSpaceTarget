using DllSky.Managers;
using DllSky.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode00ScreenController : ScreenController
{
    #region Variables
    public Transform markersPlace;

    private GameMode00SceneController sceneController;
    #endregion

    #region Unity methods
    #endregion

    #region Public methods
    public override void Initialize(object _data)
    {
        base.Initialize(_data);
        sceneController = GameMode00SceneController.Instance;

        StartCoroutine(Show());
    }
    #endregion

    #region Private methods
    private void CreateUIMarkers()
    {       
        //Игрок
        var markerPlayer = Instantiate(ResourcesManager.LoadPrefab(ConstantsResourcesPath.ELEMENTS_UI, "MarkerObject"), markersPlace);
        markerPlayer.GetComponent<UIMarker>().Initialize(sceneController.GetPlayer());

        //Объекты
        var objects = sceneController.GetObjects();
        foreach (var obj in objects)
        {
            var marker = Instantiate(ResourcesManager.LoadPrefab(ConstantsResourcesPath.ELEMENTS_UI, "MarkerObject"), markersPlace);
            marker.GetComponent<UIMarker>().Initialize(obj);
        }
    }
    #endregion

    #region Coroutines
    private IEnumerator Show()
    {
        CreateUIMarkers();
        yield return null;
        EventManager.CallOnChangeHitPoints();

        yield return SplashScreenManager.Instance.HideSplashScreen();
    }
    #endregion
}
