using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStarSystem : LeanCameraZoom
{
    #region Variables
    [Space(10.0f)]
    public bool useAxisX = true;
    public float AxisX;
    public float AxisXSensitivity = 0.25f;
    public bool AxisXClamp = false;
    public float AxisXMin = -45.0f;
    public float AxisXMax = 45.0f;

    [Space(10.0f)]
    public bool useAxisY = false;
    public float AxisY;
    public float AxisYSensitivity = 0.25f;
    public bool AxisYClamp = true;
    public float AxisYMin = -90.0f;
    public float AxisYMax = 90.0f;    
    #endregion

    #region Properties
    #endregion

    #region Unity Methods
    private void Start()
    {
        if (Camera == null)
            Camera = GetComponentInChildren<Camera>();
    }

    protected override void LateUpdate()
    {
        // Make sure the camera exists
        if (LeanTouch.GetCamera(Camera, gameObject) == true)
        {
            // Get the fingers we want to use
            var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);
            // Get the pinch ratio of these fingers
            var pinchRatio = LeanGesture.GetPinchRatio(fingers, WheelSensitivity);
            // Modify the zoom value
            Zoom *= pinchRatio;
            if (ZoomClamp == true)
            {
                Zoom = Mathf.Clamp(Zoom, ZoomMin, ZoomMax);
            }

            //Масштаб
            SetZoom();

            // Get the scaled average movement vector of these fingers
            var drag = LeanGesture.GetScaledDelta(fingers);
            // Get base sensitivity
            var sensitivity = GetSensitivity();

            //Ось AxisX
            if (useAxisX)
            {
                AxisX -= drag.x * (AxisXSensitivity / sensitivity);
                if (AxisXClamp == true)
                {
                    AxisX = Mathf.Clamp(AxisX, AxisXMin, AxisXMax);
                }
            }
            else
                AxisX = 0.0f;

            //Ось AxisY
            if (useAxisY)
            {
                AxisY += drag.y * (AxisYSensitivity / sensitivity);
                if (AxisYClamp == true)
                {
                    AxisY = Mathf.Clamp(AxisY, AxisYMin, AxisYMax);
                }
            }
            else
                AxisY = 0.0f;            

            //Смещение
            SetPosition();
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Metods
    protected void SetZoom()
    {
        Camera.transform.localPosition = new Vector3(Camera.transform.localPosition.x, Camera.transform.localPosition.y, Zoom);
    }

    protected void SetPosition()
    {
        transform.position = new Vector3(AxisX, -AxisY, transform.position.z);
    }

    private float GetSensitivity()
    {
        // Has a camera been set?
        if (Camera != null)
        {
            // Adjust sensitivity by FOV?
            if (Camera.orthographic == false)
            {
                return (120 - Camera.fieldOfView) / Mathf.Abs(Camera.transform.position.z);
            }
        }

        return 1.0f;
    }
    #endregion

    #region Coroutines
    #endregion
}