using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    #region Variables
    [Header("Type")]
    public EnumSpaceObject typeObject;

    [Header("Steps")]
    public int stepsCurrent;
    public int stepsMax = 1;

    [Header("Hit Points")]
    public bool isImmortal = false;
    public int hitPointsCurrent;
    public int hitPointsMax = 5;    

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

    #region Public methods: Initialization
    virtual public void Initialize()
    {
        gameModeController = GameMode00SceneController.Instance;

        rg = GetComponent<Rigidbody>();

        if (rg == null)
            rg = gameObject.AddComponent<Rigidbody>();

        hitPointsCurrent = hitPointsMax;
        stepsCurrent = stepsMax;
    }
    #endregion

    #region Public methods: Move and Rotation  
    //Движение вперед
    public bool ToForward()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;
        //Движение на клетку с объектом невозможно
        if (CheckToHitToOneVoxel(transform.TransformDirection(Vector3.forward)))
            return false;

        var newPosition = transform.position + transform.forward * ConstantsGameSettings.CELL_SIZE;
        //Дижение за пределы Игрового поля невозможно
        if (CheckToEndBoard(newPosition))
            return false;

        newPosition = new Vector3(  Mathf.RoundToInt(newPosition.x),
                                    Mathf.RoundToInt(newPosition.y),
                                    Mathf.RoundToInt(newPosition.z) );
        //Запускаем анимацию перемещения
        StartCoroutine(MoveAnimation(transform.position, newPosition));
        return true;
    }

    //Движение влево
    public bool ToLeft()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;
        //Движение на клетку с объектом невозможно
        if (CheckToHitToOneVoxel(transform.TransformDirection(Vector3.left)))
            return false;

        var newPosition = transform.position - transform.right * ConstantsGameSettings.CELL_SIZE;
        //Дижение за пределы Игрового поля невозможно
        if (CheckToEndBoard(newPosition))
            return false;

        newPosition = new Vector3(  Mathf.RoundToInt(newPosition.x),
                                    Mathf.RoundToInt(newPosition.y),
                                    Mathf.RoundToInt(newPosition.z) );
        //Запускаем анимацию перемещения
        StartCoroutine(MoveAnimation(transform.position, newPosition));
        return true;
    }

    //Движение вправо
    public bool ToRight()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;
        //Движение на клетку с объектом невозможно
        if (CheckToHitToOneVoxel(transform.TransformDirection(Vector3.right)))
            return false;

        var newPosition = transform.position + transform.right * ConstantsGameSettings.CELL_SIZE;
        //Дижение за пределы Игрового поля невозможно
        if (CheckToEndBoard(newPosition))
            return false;

        newPosition = new Vector3(  Mathf.RoundToInt(newPosition.x),
                                    Mathf.RoundToInt(newPosition.y),
                                    Mathf.RoundToInt(newPosition.z) );
        //Запускаем анимацию перемещения
        StartCoroutine(MoveAnimation(transform.position, newPosition));
        return true;
    }

    //Движение вверх
    public bool ToTop()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;
        //Движение на клетку с объектом невозможно
        if (CheckToHitToOneVoxel(transform.TransformDirection(Vector3.up)))
            return false;

        var newPosition = transform.position + transform.up * ConstantsGameSettings.CELL_SIZE;
        //Дижение за пределы Игрового поля невозможно
        if (CheckToEndBoard(newPosition))
            return false;

        newPosition = new Vector3(  Mathf.RoundToInt(newPosition.x),
                                    Mathf.RoundToInt(newPosition.y),
                                    Mathf.RoundToInt(newPosition.z) );
        //Запускаем анимацию перемещения
        StartCoroutine(MoveAnimation(transform.position, newPosition));
        return true;
    }

    //Движение вниз
    public bool ToBottom()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;
        //Движение на клетку с объектом невозможно
        if (CheckToHitToOneVoxel(transform.TransformDirection(Vector3.down)))
            return false;

        var newPosition = transform.position - transform.up * ConstantsGameSettings.CELL_SIZE;
        //Дижение за пределы Игрового поля невозможно
        if (CheckToEndBoard(newPosition))
            return false;

        newPosition = new Vector3(  Mathf.RoundToInt(newPosition.x),
                                    Mathf.RoundToInt(newPosition.y),
                                    Mathf.RoundToInt(newPosition.z) );
        //Запускаем анимацию перемещения
        StartCoroutine(MoveAnimation(transform.position, newPosition));
        return true;
    }

    //Тангаж вверх
    public bool ToPitchUp()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;

        var deltaRotation = transform.rotation * Quaternion.AngleAxis(-90, Vector3.right);
        //Запускаем анимацию вращения
        StartCoroutine(RotateAnimation(transform.rotation, deltaRotation));
        return true;
    }

    //Тангаж вниз
    public bool ToPitchDown()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;

        var deltaRotation = transform.rotation * Quaternion.AngleAxis(90, Vector3.right);
        //Запускаем анимацию вращения
        StartCoroutine(RotateAnimation(transform.rotation, deltaRotation));
        return true;
    }

    //Рыскание влево
    public bool ToYawLeft()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;

        var deltaRotation = transform.rotation * Quaternion.AngleAxis(-90, Vector3.up);
        //Запускаем анимацию вращения
        StartCoroutine(RotateAnimation(transform.rotation, deltaRotation));
        return true;
    }

    //Рыскание вправо
    public bool ToYawRight()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;

        var deltaRotation = transform.rotation * Quaternion.AngleAxis(90, Vector3.up);
        //Запускаем анимацию вращения
        StartCoroutine(RotateAnimation(transform.rotation, deltaRotation));
        return true;
    }

    //Крен влево
    public bool ToRollLeft()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;

        var deltaRotation = transform.rotation * Quaternion.AngleAxis(90, Vector3.forward);
        //Запускаем анимацию вращения
        StartCoroutine(RotateAnimation(transform.rotation, deltaRotation));
        return true;
    }

    //Крен вправо
    public bool ToRollRight()
    {
        //Если идет анимация
        if (!isEndAnimation)
            return false;

        var deltaRotation = transform.rotation * Quaternion.AngleAxis(-90, Vector3.forward);
        //Запускаем анимацию вращения
        StartCoroutine(RotateAnimation(transform.rotation, deltaRotation));
        return true;
    }
    #endregion

    #region Public methods: Other
    virtual public void SetDamage(int _damage)
    {
        //Неуязвимые объекты
        if (isImmortal)
            return;

        hitPointsCurrent -= _damage;

        if (hitPointsCurrent <= 0)
            ToDie();
    }
    #endregion

    #region Protected methods
    protected bool CheckToHitToOneVoxel(Vector3 _direction)
    {
        //TODO: определить, на какие из занятых клеток нельзя перемещаться

        bool result = false;

        RaycastHit[] hits = Physics.RaycastAll(transform.position, _direction, ConstantsGameSettings.RAY_COEF * ConstantsGameSettings.CELL_SIZE);

        foreach (var hit in hits)
        {
            if (hit.rigidbody != rg)
            {
                if (hit.rigidbody.tag != ConstantsTag.TAG_VOID && hit.rigidbody.tag != ConstantsTag.TAG_VOID)
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
        //Проверка выхода за пределы игрового поля + допустимая внешняя граница для перемещения
        if (Mathf.RoundToInt(_newPosition.x) < -ConstantsGameSettings.BEYOND_BORDERS 
            || Mathf.RoundToInt(_newPosition.x) > ConstantsGameSettings.CELL_SIZE * (gameModeController.lengthX + ConstantsGameSettings.BEYOND_BORDERS))
            return true;
        if (Mathf.RoundToInt(_newPosition.y) < -ConstantsGameSettings.BEYOND_BORDERS 
            || Mathf.RoundToInt(_newPosition.y) > ConstantsGameSettings.CELL_SIZE * (gameModeController.lengthY + ConstantsGameSettings.BEYOND_BORDERS))
            return true;
        if (Mathf.RoundToInt(_newPosition.z) < -ConstantsGameSettings.BEYOND_BORDERS 
            || Mathf.RoundToInt(_newPosition.z) > ConstantsGameSettings.CELL_SIZE * (gameModeController.lengthZ + ConstantsGameSettings.BEYOND_BORDERS))
            return true;

        return false;
    }

    virtual protected void ToDie()
    {
        //TODO: определить действия при уничтожении объекта

        /*if (tag == ConstantsTag.Rocket)
        {
            var boom = Instantiate(Resources.Load<GameObject>(ConstPrefabs.PARTICLES_ROCKET_BOOM), transform.position, Quaternion.identity, transform.parent);
            Destroy(boom, 5.0f);
        }

        if (tag != ConstantsTag.Player)
            Destroy(this.gameObject);*/
    }
    #endregion

    #region Coroutines
    //Ход ИИ
    public IEnumerator ToAITurn()
    {
        //TODO:

        while (stepsCurrent > 0)
        {
            //Ожидаем, пока не закончится анимация
            while (!isEndAnimation)
                yield return null;
            
            //...

            stepsCurrent--;
        }        
    }

    //Анимация перемещения
    protected IEnumerator MoveAnimation(Vector3 _oldPosition, Vector3 _newPosition )
    {
        isEndAnimation = false;

        var T = ConstantsGameSettings.TIME_ANIMATION;
        var t = 0.0f;

        while (transform.position != _newPosition)
        {         
            var newPos = Vector3.Lerp( _oldPosition, _newPosition, Mathf.Clamp01(t / T) );
            rg.MovePosition(newPos);

            t += Time.deltaTime;

            yield return null;
        }

        isEndAnimation = true;
    }

    //Анимация вращения
    protected IEnumerator RotateAnimation(Quaternion _oldRotation, Quaternion _newRotation)
    {
        isEndAnimation = false;

        var T = ConstantsGameSettings.TIME_ANIMATION;
        var t = 0.0f;

        while (transform.rotation != _newRotation)
        {
            var newRot = Quaternion.Lerp(_oldRotation, _newRotation, Mathf.Clamp01(t / T));
            rg.rotation = newRot;

            t += Time.deltaTime;

            yield return null;
        }

        isEndAnimation = true;
    }
    #endregion

    #region Menu
    [ContextMenu("To Forward")]
    protected void ContextMenuToForward()
    {
        ToForward();
    }

    [ContextMenu("To Left")]
    protected void ContextMenuToLeft()
    {
        ToLeft();
    }

    [ContextMenu("To Right")]
    protected void ContextMenuToRight()
    {
        ToRight();
    }

    [ContextMenu("To Pitch Up")]
    protected void ContextMenuToPitchUp()
    {
        ToPitchUp();
    }

    [ContextMenu("To Pitch Down")]
    protected void ContextMenuToPitchDown()
    {
        ToPitchDown();
    }

    [ContextMenu("To Roll Left")]
    protected void ContextMenuToRollLeft()
    {
        ToRollLeft();
    }

    [ContextMenu("To Roll Right")]
    protected void ContextMenuToRollRight()
    {
        ToRollRight();
    }
    #endregion
}
