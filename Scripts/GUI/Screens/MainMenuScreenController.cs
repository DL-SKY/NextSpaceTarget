using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreenController : ScreenController
{
    #region Variables
    #endregion

    #region Unity methods
    #endregion

    #region Buttons method
    public void OnClickSettings()
    {
        //ScreenManager.Instance.ShowDialog(ConstantsDialog.SETTINGS);
        StartCoroutine(Dialog());
    }
    #endregion

    #region Public methods
    public override void Initialize(object _data)
    {
        base.Initialize(_data);

        StartCoroutine(Show());
    }
    #endregion

    #region Private methods
    #endregion

    #region Coroutines
    private IEnumerator Show()
    {
        yield return SplashScreenManager.Instance.HideSplashScreen();
        yield return null;
    }

    private IEnumerator Dialog()
    {
        var dialog = ScreenManager.Instance.ShowDialog(ConstantsDialog.SETTINGS);
        yield return dialog.Wait();
    }
    #endregion
}
