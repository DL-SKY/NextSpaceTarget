using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Generator
{
    #region Variables
    #endregion

    #region Public methods
    public static int[,,] GenerateGameBoard(GeneratorData _data)
    {
        int[,,] matrix = new int[_data.LengthX, _data.LengthY, _data.LengthZ];

        //Игровое поле, объекты
        for (int x = 0; x < _data.LengthX; x++)
            for (int y = 0; y < _data.LengthY; y++)
                for (int z = 0; z < _data.LengthZ; z++)
                {
                    float random = Random.Range(0.0f, 100.0f);

                    if (random <= _data.PercentBox)
                        random = (float)EnumSpaceObject.Box;
                    /*else if (random <= percentCube + percentEnemies + (countSectors / 100.0f))
                        random = (float)EnumSpaceObject.Enemy;*/
                    else
                        random = (float)EnumSpaceObject.Void;

                    matrix[x, y, z] = (int)random;
                }        

        return matrix;
    }

    public static Vector3Int GeneratePlayerPosition(GeneratorData _data)
    {
        var result = new Vector3Int();

        int halfX = _data.LengthX / 2;
        int halfY = _data.LengthY / 2;
        int beyondZ = (int)ConstantsGameSettings.BEYOND_BORDERS;

        int playerX = Random.Range(halfX - 2, halfX + 3);
        int playerY = Random.Range(halfY - 2, halfY + 3);
        int playerZ = Random.Range(-Mathf.Max(beyondZ-2, 4), (int)-3);

        result.Set(playerX, playerY, playerZ);
        return result;
    }
    #endregion

    #region Private methods    
    #endregion
}

public class GeneratorData
{
    #region Length
    private int lengthX;
    private int lengthY;
    private int lengthZ;

    public int LengthX
    {
        get { return lengthX; }
        set { lengthX = value; }
    }
    public int LengthY
    {
        get { return lengthY; }
        set { lengthY = value; }
    }
    public int LengthZ
    {
        get { return lengthZ; }
        set { lengthX = value; }
    }
    #endregion

    #region Probabilities
    private float percentBox;

    public float PercentBox
    {
        get { return percentBox; }
        set { percentBox = value; }
    }
    #endregion

    #region Constructors
    public GeneratorData(int _lengthX, int _lengthY, int _lengthZ, float _percentBox)
    {
        lengthX = _lengthX;
        lengthY = _lengthY;
        lengthZ = _lengthZ;

        percentBox = _percentBox;
    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    #endregion
}

public class Vector3Int
{
    #region Get/Set
    public int X { get; set;}
    public int Y { get; set; }
    public int Z { get; set; }
    #endregion

    #region Constructors
    public Vector3Int(int _x = 0, int _y = 0, int _z = 0)
    {
        X = _x;
        Y = _y;
        Z = _z;
    }

    public Vector3Int(Vector3 _vector3)
    {
        X = Mathf.RoundToInt(_vector3.x);
        Y = Mathf.RoundToInt(_vector3.y);
        Z = Mathf.RoundToInt(_vector3.z);
    }
    #endregion

    #region Public methods
    public void Set(int _x, int _y, int _z)
    {
        X = _x;
        Y = _y;
        Z = _z;
    }
    #endregion
}
