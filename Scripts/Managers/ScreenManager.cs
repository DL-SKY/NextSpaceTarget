using DllSky.Patterns;
using DllSky.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : Singleton<ScreenManager>
{
    #region Variables
    public Transform parent;

    private List<ScreenController> screens = new List<ScreenController>();
    #endregion

    #region Unity methods
    private void Awake()
    {
        if (!parent)
            parent = transform;
    }

    private void Update()
    {
        //Кнопка "Назад"
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log(KeyCode.Escape);
        }
    }
    #endregion

    #region Public methods
    public void ShowScreen(string _name, object _data = null)
    {
        var screen = Instantiate(ResourcesManager.LoadPrefab(ConstantsResourcesPath.SCREENS, _name), parent);
        screen.transform.SetAsLastSibling();
        screen.GetComponent<ScreenController>().Initialize(_data);

        /*
        var screen = ResourcesManager.Instance.InstantiatePrefab<ScreenController>(transform, ResourcesManagerPaths.UI_SCREENS, _type.ToString());
        screens.Add(screen);
        screen.Type = _type;
        screen.Initialize(_data);

        LocalizationManager.ClearCache();

        return screen;
        */
    }

    public DialogController ShowDialog(string _name)
    {
        return ShowDialog<DialogController>(_name);
    }

    public DialogController ShowErrorDialog(string _text, string _techInfo = null)
    {
        if (screens.Count > 0)
            _text += "\n" + LocalizationManager.Get(LocalizationKeys.ERROR_INFO_SCREEN, screens[screens.Count - 1].Type.ToString());

        if (_techInfo == null)
            _techInfo = Environment.StackTrace;

        var dialog = ShowDialog<ErrorDialogController>(DialogNameConstants.ERROR, AlwaysOverlayCanvas);
        dialog.Initialize(_text, _techInfo);
        return dialog;
    }
    /*
    /// <summary>
    /// Creates dialog either in current screen or in plain canvas if no current screen.
    /// </summary>
    public T ShowDialog<T>(string _name) where T : DialogController
    {
        if (screens.Count > 0)
            return ShowDialog<T>(_name, screens[screens.Count - 1]);
        else
            return ShowDialog<T>(_name, this);
    }

    public T ShowDialog<T>(string _name, MonoBehaviour _parent) where T : DialogController
    {
        return ResourcesManager.Instance.InstantiatePrefab<T>(_parent.transform, ResourcesManagerPaths.UI_DIALOGS, _name);
    }

    public T ShowDialog<T>(string _name, Transform _transform) where T : DialogController
    {
        return ResourcesManager.Instance.InstantiatePrefab<T>(_transform, ResourcesManagerPaths.UI_DIALOGS, _name);
    }
    */
    #endregion

    #region Private methods
    #endregion

    #region Coroutines
    /*public IEnumerator ShowScreen(string _name)
    {
    
    }*/
    #endregion
}
