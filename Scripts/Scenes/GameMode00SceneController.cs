using DllSky.Managers;
using DllSky.Patterns;
using DllSky.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode00SceneController : Singleton<GameMode00SceneController>
{
    #region Variables
    public bool isInit = false;
    
    [Header("Matrix")]
    public int lengthX;
    public int lengthY;
    public int lengthZ;
    public float percentBox;

    [Header("Counters")]
    public int countVoxels;
    public int countVoid;
    public int countBoxs;

    [Header("Game")]
    public bool isPlayerTurn = false;


    [SerializeField]
    private Transform space;
    [SerializeField]
    private List<SpaceObject> objects = new List<SpaceObject>();
    [SerializeField]
    private SpaceObject player;
    #endregion

    #region Unity methods
    private void Start()
    {
        space = new GameObject("SPACE").transform;

        TestMethod();

        StartCoroutine(Initialize());
    }

    private void OnEnable()
    {
        //Подписываемся на события
        EventManager.eventOnStartPlayerTurn += HandlerOnStartPlayerTurn;
        EventManager.eventOnEndPlayerTurn += HandlerOnEndPlayerTurn;
    }

    private void OnDisable()
    {
        //Отписываемся от событий
        EventManager.eventOnStartPlayerTurn -= HandlerOnStartPlayerTurn;
        EventManager.eventOnEndPlayerTurn -= HandlerOnEndPlayerTurn;
    }
    #endregion

    #region Public methods
    public SpaceObject GetPlayer()
    {
        return player;
    }

    public List<SpaceObject> GetObjects()
    {
        return objects;
    }
    #endregion

    #region Private methods
    private void GenerateGameBoard()
    {
        isInit = false;
        isPlayerTurn = false;
        objects.Clear();

        if (lengthX < 1)
            lengthX = 10;
        if (lengthY < 1)
            lengthY = 10;
        if (lengthZ < 1)
            lengthZ = 10;

        //Очистка счетчиков и Игрового Поля
        countVoxels = 0;
        countVoid = 0;
        countBoxs = 0;
        CleanGameBoard();

        //Генерируем матрицу
        GeneratorData data = new GeneratorData(lengthX, lengthY, lengthZ, percentBox);
        var matrix = Generator.Generate(data);

        //Создаем Игровое Поле
        int x2, y2, z2;
        for (int x = 0; x < lengthX; x++)
            for (int y = 0; y < lengthY; y++)
                for (int z = 0; z < lengthZ; z++)
                {
                    x2 = x * (int)ConstantsGameSettings.CELL_SIZE;
                    y2 = y * (int)ConstantsGameSettings.CELL_SIZE;
                    z2 = z * (int)ConstantsGameSettings.CELL_SIZE;

                    countVoxels++;
                    switch (matrix[x, y, z])
                    {
                        case (int)EnumSpaceObject.Void:
                            countVoid++;
                            break;
                        case (int)EnumSpaceObject.Box:
                            countBoxs++;
                            var boxObj = Instantiate(ResourcesManager.LoadPrefab(ConstantsResourcesPath.SPACEOBJECTS, "Box01"), new Vector3(x2, y2, z2), Quaternion.identity, space);
                            objects.Add(boxObj.GetComponent<SpaceObject>());
                            break;

                        case (int)EnumSpaceObject.Player:
                            var playerObj = Instantiate(ResourcesManager.LoadPrefab(ConstantsResourcesPath.SPACESHIPS, "SpaceShip01"), new Vector3(x2, y2, z2), Quaternion.identity, space);
                            player = playerObj.GetComponent<SpaceObject>();
                            break;
                    }
                }

        isInit = true;
    }

    private void CleanGameBoard()
    {
        if (!space)
            return;

        var camera = Camera.main;
        camera.transform.SetParent(null);

        for (int i = 0; i < space.childCount; i++)
            Destroy(space.GetChild(i).gameObject);
    }

    private void HandlerOnStartPlayerTurn()
    {
        isPlayerTurn = true;
        player.PrepareToNewTurn();
    }

    private void HandlerOnEndPlayerTurn()
    {
        isPlayerTurn = false;
        StartCoroutine(StartAITurn());
    }
    #endregion

    #region Coroutines
    private IEnumerator Initialize()
    {
        //TODO: testing
        GenerateGameBoard();
        //Кадр для применения настроек создаваемых объектов на сцене
        yield return null;
        //------------------------------
        //isInit = true;
        ScreenManager.Instance.ShowScreen(ConstantsScreen.GAME_MODE_00);
    }

    private IEnumerator StartAITurn()
    {
        if (objects.Count > 0)
        {
            //Перебираем объекты на игровом поле с ИИ
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i] != null)
                {
                    //yield return new WaitForSeconds(0.1f);
                    //TODO...
                    //objects[i].
                    //yield return objects[i].ToAITurn();
                }
            }

            //Проверяем список на актуальность
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                if (objects[i] == null)
                    objects.RemoveAt(i);
            }
        }

        EventManager.CallOnStartPlayerTurn();


        yield return null;
    }
    #endregion

    #region Menu
    [ContextMenu("Generate Game Board")]
    private void ContextMenuGenerate()
    {
        GenerateGameBoard();
    }
    #endregion

    private void TestMethod()
    {
        if (percentBox <= 0.0f)
            percentBox = Random.Range(0.1f, 1.0f);
    }
}
