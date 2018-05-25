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
        EventManager.eventOnClickEsc += OnClickEsc;
        EventManager.eventOnChangeHitPoints += UpdateAllMarkers;

        if (IsInit)
            StartCoroutine(Show());
    }

    private void OnDisable()
    {
        EventManager.eventOnClickEsc -= OnClickEsc;
        EventManager.eventOnChangeHitPoints -= UpdateAllMarkers;
    }
    #endregion

    #region Public methods
    public override void Initialize(object _data)
    {
        base.Initialize(_data);        

        StartCoroutine(Show());
    }

    public void OnClickEsc()
    {
        StartCoroutine(CloseCoroutine());
    }

    public void OnClickToForward()
    {
        player.ToForward();
    }

    public void OnClickToLeft()
    {
        player.ToLeft();
    }

    public void OnClickToRight()
    {
        player.ToRight();
    }

    public void OnClickToTop()
    {
        player.ToTop();
    }

    public void OnClickToBottom()
    {
        player.ToBottom();
    }

    public void OnClickToPitchUp()
    {

    }

    public void OnClickToPitchDown()
    {

    }

    public void OnClickToYawLeft()
    {

    }
    public void OnClickToYawRight()
    {

    }

    public void OnClickToRollLeft()
    {
        player.ToRollLeft();
    }

    public void OnClickToRollRight()
    {
        player.ToRollRight();
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
        yield return MyGameManager.Instance.LoadSceneCoroutine(ConstantsScene.GAME_MODE_00);
        while (!GameMode00SceneController.Instance.isInit)
        {
            yield return null;
        }
        sceneController = GameMode00SceneController.Instance;
        player = sceneController.GetPlayer();

        CreateUIMarkers();
        yield return SplashScreenManager.Instance.HideSplashScreen();
    }

    private IEnumerator CloseCoroutine()
    {
        yield return SplashScreenManager.Instance.ShowBlack();

        Close();
    }
    #endregion
}
