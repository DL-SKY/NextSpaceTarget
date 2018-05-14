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