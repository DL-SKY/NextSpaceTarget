using DllSky.Components;
using DllSky.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMarker : MonoBehaviour
{
    #region Variables
    public Transform target;
    public ProgressBar progressBar;
    public bool isInit = false;

    private RectTransform selfTransform;
    private SpaceObject targetScript;    
    new private Camera camera;
    #endregion

    #region Unity methods
    private void Awake()
    {
        selfTransform = GetComponent<RectTransform>();
        camera = Camera.main;
    }

    private void LateUpdate()
    {
        if (!isInit)
        {
            return;
        }
        if (!target || !targetScript)
        {
            DeleteMarker();
            return;
        }

        selfTransform.position = camera.WorldToScreenPoint(target.position);

        transform.localScale = (targetScript.inCamera == true && targetScript.IsVisible) ? Vector3.one : Vector3.zero;
    }
    #endregion

    #region Public methods
    public void Initialize(SpaceObject _target)
    {
        targetScript = _target;
        target = targetScript.transform;

        isInit = true;

        UpdateMarker();
    }

    public void UpdateMarker()
    {
        float fillAmount;
        fillAmount = Mathf.Clamp01((float)targetScript.hitPointsCurrent/(float)targetScript.hitPointsMax);
        progressBar.FillAmount = fillAmount;
    }
    #endregion

    #region Private methods
    private void DeleteMarker()
    {
        Destroy(gameObject);
    }
    #endregion

    #region Coroutines
    #endregion
}

/*
public class Target : MonoBehaviour
{
    #region Variables
    [Header("Settings")]
    public int tapCount;
    public float targetingTime;
    public float tapResetTime;
    public float optimalDistance;
    public GameObject prefTapCounter;

    [Header("Main")]
    public int indexTracked = -1;
    public bool isTracked;
    public bool isStartTargeting;
    public int tapCountCurrent;

    [Header("Testing")]
    public float distance;

    [Header("Links")]
    public Transform targetObject;
    public SpaceObject targetSpaceObject;
    public GameObject trackedTargetUI;
    public GameObject tracked;
    public GameObject notracked;
    public Image imgCircle;
    public Text textTimer;
    public Transform tapCounter;
    public Text numberText;
    public Text distanceText;

    private CanvasGroup alpha;
    private Screen01 screen;
    #endregion

    #region Properties
    #endregion

    #region Unity Metods
    private void Start()
    {
        isTracked = false;
        isStartTargeting = false;
        imgCircle.fillAmount = 0.0f;
        textTimer.text = "";
        alpha = GetComponent<CanvasGroup>();        

        tapCountCurrent = 0;

        ClearTapCounters();
        CreateTapCounters();
        StartCoroutine(Timer());

        UpdateTrackedStatus();
    }

    private void Update()
    {
        UpdatePosition();
        UpdateGUI();
    }
    #endregion

    #region Public Metods
    public void Initialize(GameObject _object)
    {
        screen = FindObjectOfType<Screen01>();

        transform.SetParent(screen.targeting);

        targetObject = _object.transform;
    }

    public void OnClickTarget()
    {
        if (isStartTargeting || alpha.alpha < 0.01f)
            return;

        //Увеличиваем счетчик кликов по маркеру
        tapCountCurrent++;
        StopAllCoroutines();
        StartCoroutine(Timer());

        if (tapCountCurrent >= tapCount)
        {
            StartCoroutine(StartTargeting());
            isStartTargeting = true;
        }
    }

    public void UpdateTrackedStatus()
    {
        tracked.SetActive(isTracked);
        notracked.SetActive(!isTracked);

        if (!isTracked)
        {
            imgCircle.fillAmount = 0.0f;
            textTimer.text = "";
        }
    }

    public void UpdatePosition()
    {
        if (targetObject == null)
            return;
        else
        {
            //проверяем на SpaceObject
            if (!targetSpaceObject)
                targetSpaceObject = targetObject.gameObject.GetComponentInChildren<SpaceObject>();
        }

        //Позиция
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(targetObject.position);
        //Дистанция
        distance = Vector3.Distance(Player2.Instance.transform.position, targetObject.position);
        //Альфа
        if (distance > optimalDistance)
            alpha.alpha = 1 - (distance - optimalDistance) / (optimalDistance * 0.6f);
        else
            alpha.alpha = 1;

        //Если цель далеко - теряем наведение/сопровождение цели
        if (alpha.alpha < 0.01f)
        {
            isTracked = false;
            isStartTargeting = false;
            UpdateTrackedStatus();

            DeleteTrackedTarget();
        }

        //Если цель за пределами видимости камеры
        if (targetSpaceObject)
        {
            transform.localScale = targetSpaceObject.visible == true ? Vector3.one : Vector3.zero;
        }
    }

    public void UpdateGUI()
    {
        if (isTracked)
            numberText.text = (indexTracked + 1).ToString();

        distanceText.text = distance.ToString();
    }
    #endregion

    #region Private Metods
    private void UpdateTapCounters()
    {
        if (tapCount - tapCountCurrent == tapCounter.childCount)
            return;

        if (tapCount - tapCountCurrent < tapCounter.childCount && tapCounter.childCount > 0)
            Destroy(tapCounter.GetChild(0).gameObject);
        else
            Instantiate(prefTapCounter, tapCounter);
    }

    private void ClearTapCounters()
    {
        for (int i = 0; i < tapCounter.childCount; i++)
            Destroy(tapCounter.GetChild(0).gameObject);
    }

    private void CreateTapCounters()
    {
        for (int i = 0; i < tapCount - tapCountCurrent; i++)
            Instantiate(prefTapCounter, tapCounter);
    }

    private void CreateTrackedTarget()
    {
        trackedTargetUI = Instantiate(screen.trackedTargetPrefap, screen.trackedTargets);
        trackedTargetUI.GetComponent<TrackedTarget>().Initialize(this);
    }

    private void DeleteTrackedTarget()
    {
        Destroy(trackedTargetUI);
    }
    #endregion

    #region Coroutines
    private IEnumerator StartTargeting()
    {
        UpdateTrackedStatus();
         
        imgCircle.fillAmount = 0.0f;
        float fTimer = targetingTime;

        while (imgCircle.fillAmount < 1.0f)
        {
            yield return null;
            imgCircle.fillAmount += 1/targetingTime * Time.deltaTime;
            fTimer -= Time.deltaTime;
            textTimer.text = string.Format("{0:F1}", fTimer);
        }

        yield return null;

        isTracked = true;
        isStartTargeting = false;

        //Создаем объект отображения захваченной цели
        CreateTrackedTarget();

        UpdateTrackedStatus();
    }

    private IEnumerator Timer()
    {
        while (!isStartTargeting)
        {
            UpdateTapCounters();

            yield return new WaitForSeconds(tapResetTime);

            tapCountCurrent--;
            if (tapCountCurrent < 0)
                tapCountCurrent = 0;

            //UpdateTapCounters();
        }
    }
    #endregion
}
 */
