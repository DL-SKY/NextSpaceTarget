using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererController : MonoBehaviour
{
    #region Variables
    public SpaceObject spaceObject;
    #endregion

    #region Unity methods
    private void OnBecameVisible()
    {
        spaceObject.inCamera = true;
    }

    private void OnBecameInvisible()
    {
        spaceObject.inCamera = false;
    }
    #endregion
}
