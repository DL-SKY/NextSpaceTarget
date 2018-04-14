using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    #region Variables
    private bool isInit = false;
    private bool isOpened = true;
    #endregion

    #region Properties
    public bool IsInit
    {
        get { return isInit; }
        set { isInit = value; }
    }
    #endregion

    #region Unity methods
    #endregion

    #region Public methods
    public virtual void Initialize(object _data)
    {
        isInit = true;
    }

    public virtual void Close()
    {
        isOpened = false;

    }
    #endregion

    #region Protected methods
    #endregion

    #region Coroutine
    public IEnumerator Wait()
    {
        while (isOpened)
            yield return null;
    }
    #endregion
}
