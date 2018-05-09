using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    #region Variables
    public int healthCurrent;
    public int healthMax = 5;

    public EnumSpaceObject typeObject;

    private GameMode00SceneController gameModeController;
    private Rigidbody rg;
    private bool isEndAnimation = true;
    #endregion

    #region Unity methods
    private void Start()
    {
        Initialize();
    }
    #endregion

    #region Public methods
    virtual public void Initialize()
    {
        gameModeController = GameMode00SceneController.Instance;

        rg = GetComponent<Rigidbody>();

        if (rg == null)
            rg = gameObject.AddComponent<Rigidbody>();

        healthCurrent = healthMax;
    }

    public bool ToForward()
    {
        if (!isEndAnimation)
            return false;

        if (CheckToHitToOneVoxel(transform.TransformDirection(Vector3.forward)))
            return false;

        var newPosition = transform.position + transform.forward * ConstantsGameSettings.CELL_SIZE;

        if (CheckToEndBoard(newPosition))
            return false;

        newPosition = new Vector3(  Mathf.RoundToInt(newPosition.x),
                                    Mathf.RoundToInt(newPosition.y),
                                    Mathf.RoundToInt(newPosition.z) );
        //rg.MovePosition(newPosition);
        StartCoroutine(MoveAnimation(transform.position, newPosition));
        return true;
    }

    /*public void ToLeft()
    {
        if (!isEndAnimation)
            return;

        if (CheckToHitToOneVoxel(transform.TransformDirection(Vector3.left)))
            return;

        var newPosition = transform.position - transform.right * ConstantsGameSettings.CELL_SIZE;

        if (CheckToEndBoard(newPosition))
            return;

        newPosition = new Vector3(  Mathf.RoundToInt(newPosition.x),
                                    Mathf.RoundToInt(newPosition.y),
                                    Mathf.RoundToInt(newPosition.z) );
        rg.MovePosition(newPosition);
    }

    public void ToRight()
    {
        if (!isEndAnimation)
            return;

        if (CheckToHitToOneVoxel(transform.TransformDirection(Vector3.right)))
            return;

        var newPosition = transform.position + transform.right * ConstantsGameSettings.CELL_SIZE;

        if (CheckToEndBoard(newPosition))
            return;

        newPosition = new Vector3(  Mathf.RoundToInt(newPosition.x),
                                    Mathf.RoundToInt(newPosition.y),
                                    Mathf.RoundToInt(newPosition.z) );
        rg.MovePosition(newPosition);
    }

    public void ToTop()
    {
        if (!isEndAnimation)
            return;

        if (CheckToHitToOneVoxel(transform.TransformDirection(Vector3.up)))
            return;

        var newPosition = transform.position + transform.up * ConstantsGameSettings.CELL_SIZE;

        if (CheckToEndBoard(newPosition))
            return;

        newPosition = new Vector3(  Mathf.RoundToInt(newPosition.x),
                                    Mathf.RoundToInt(newPosition.y),
                                    Mathf.RoundToInt(newPosition.z) );
        rg.MovePosition(newPosition);
    }

    public void ToBottom()
    {
        if (!isEndAnimation)
            return;

        if (CheckToHitToOneVoxel(transform.TransformDirection(Vector3.down)))
            return;

        var newPosition = transform.position - transform.up * ConstantsGameSettings.CELL_SIZE;

        if (CheckToEndBoard(newPosition))
            return;

        newPosition = new Vector3(  Mathf.RoundToInt(newPosition.x),
                                    Mathf.RoundToInt(newPosition.y),
                                    Mathf.RoundToInt(newPosition.z) );
        rg.MovePosition(newPosition);
    }

    public void ToPitchUp()
    {
        if (!isEndAnimation)
            return;

        var deltaRotation = Quaternion.AngleAxis(-90, Vector3.right);
        rg.rotation *= deltaRotation;
    }

    public void ToPitchDown()
    {
        if (!isEndAnimation)
            return;

        var deltaRotation = Quaternion.AngleAxis(90, Vector3.right);
        rg.rotation *= deltaRotation;
    }

    public void ToYawLeft()
    {
        if (!isEndAnimation)
            return;

        var deltaRotation = Quaternion.AngleAxis(-90, Vector3.up);
        rg.rotation *= deltaRotation;
    }

    public void ToYawRight()
    {
        if (!isEndAnimation)
            return;

        var deltaRotation = Quaternion.AngleAxis(90, Vector3.up);
        rg.rotation *= deltaRotation;
    }

    public void ToRollLeft()
    {
        if (!isEndAnimation)
            return;

        var deltaRotation = Quaternion.AngleAxis(90, Vector3.forward);
        rg.rotation *= deltaRotation;
    }

    public void ToRollRight()
    {
        if (!isEndAnimation)
            return;

        var deltaRotation = Quaternion.AngleAxis(-90, Vector3.forward);
        rg.rotation *= deltaRotation;
    }*/ 
    #endregion

    #region Protected methods
    protected bool CheckToHitToOneVoxel(Vector3 _direction)
    {
        //TODO:

        bool result = false;

        RaycastHit[] hits = Physics.RaycastAll(transform.position, _direction, ConstantsGameSettings.RAY_COEF * ConstantsGameSettings.CELL_SIZE);

        foreach (var hit in hits)
        {
            if (hit.rigidbody != rg)
            {
                if (hit.rigidbody.tag != "AmmoArmy" && hit.rigidbody.tag != "AmmoRocket")
                {
                    result = true;
                    break;
                }
            }
        }

        return result;
    }

    protected bool CheckToEndBoard(Vector3 _newPosition)
    {
        if (Mathf.RoundToInt(_newPosition.x) < 0 || Mathf.RoundToInt(_newPosition.x) > ConstantsGameSettings.CELL_SIZE * gameModeController.lengthX)
            return true;
        if (Mathf.RoundToInt(_newPosition.y) < 0 || Mathf.RoundToInt(_newPosition.y) > ConstantsGameSettings.CELL_SIZE * gameModeController.lengthY)
            return true;
        if (Mathf.RoundToInt(_newPosition.z) < 0 || Mathf.RoundToInt(_newPosition.z) > ConstantsGameSettings.CELL_SIZE * gameModeController.lengthZ)
            return true;

        return false;
    }
    #endregion

    #region Private methods
    #endregion

    #region Coroutines
    protected IEnumerator MoveAnimation(Vector3 _oldPosition, Vector3 _newPosition )
    {
        var T = ConstantsGameSettings.TIME_ANIMATION;
        var t = 0.0f;

        //rg.MovePosition(_newPosition);
        while (transform.position != _newPosition)
        {         
            var newPos = Vector3.Lerp( _oldPosition, _newPosition, Mathf.Clamp01(t/T) );
            rg.MovePosition(newPos);

            t += Time.deltaTime;

            yield return null;
        }
    }
    #endregion

    #region Menu
    [ContextMenu("To Forward")]
    protected void ContextMenuToForward()
    {
        ToForward();
    }
    #endregion
}
