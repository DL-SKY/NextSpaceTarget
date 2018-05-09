using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Generator
{
    #region Variables
    #endregion

    #region Public methods
    public static int[,,] Generate(GeneratorData _data)
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

        //Игрок
        matrix[0, 0, 0] = (int)EnumSpaceObject.Player;

        return matrix;
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

    #region Constructor
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
