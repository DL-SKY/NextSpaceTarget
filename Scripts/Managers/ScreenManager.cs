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
    }
    #endregion

    #region Private methods
    #endregion

    #region Coroutines
    /*public IEnumerator ShowScreen(string _name)
    {
    
    }*/
    #endregion
}
