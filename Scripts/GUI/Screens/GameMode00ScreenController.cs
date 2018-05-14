using DllSky.Extensions;
using DllSky.Managers;
using DllSky.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode00ScreenController : ScreenController
{
    #region Variables
    [Header("Markers")]
    public Transform markersPlace;
    private List<UIMarker> markers = new List<UIMarker>();

    
    private GameMode00SceneController sceneController;
    private SpaceObject player;
    #endregion

    #region Unity methods
    private void OnEnable()
    {
        EventManager.eventOnChangeHitPoints += UpdateAllMarkers;
    }

    private void OnDisable()
    {
        EventManager.eventOnChangeHitPoints -= UpdateAllMarkers;
    }
    #endregion

    #region Public methods
    public override void Initialize(object _data)
    {
        base.Initialize(_data);
        sceneController = GameMode00SceneController.Instance;
        player = sceneController.GetPlayer();

        StartCoroutine(Show());
    }
    #endregion

    #region Private methods
    private void CreateUIMarkers()
    {
        ClearAllMarkers();

        //Игрок
        var markerPlayerObj = Instantiate(ResourcesManager.LoadPrefab(ConstantsResourcesPath.ELEMENTS_UI, "MarkerObject"), markersPlace);
        var markerPlayerScr = markerPlayerObj.GetComponent<UIMarker>();
        markers.Add(markerPlayerScr);
        markerPlayerScr.Initialize(sceneController.GetPlayer(), player.transform, EnumUIMarkerType.Player);

        //Объекты
        var objects = sceneController.GetObjects();
        foreach (var obj in objects)
        {
            var markerObj = Instantiate(ResourcesManager.LoadPrefab(ConstantsResourcesPath.ELEMENTS_UI, "MarkerObject"), markersPlace);
            var markerScr = markerObj.GetComponent<UIMarker>();
            markers.Add(markerScr);
            markerScr.Initialize(obj, player.transform);
        }
    }

    private void ClearAllMarkers()
    {
        markers.Clear();

        /*for (int i = markersPlace.childCount-1; i >= 0; i--)
            Destroy(markersPlace.GetChild(i).gameObject);*/
        markersPlace.DestroyChildren();
    }

    private void UpdateAllMarkers()
    {
        foreach (var marker in markers)
            marker.UpdateHitPoints();
    }
    #endregion

    #region Coroutines
    private IEnumerator Show()
    {
        CreateUIMarkers();
        yield return SplashScreenManager.Instance.HideSplashScreen();
    }
    #endregion
}
