using UnityEngine;

namespace DllSky.Classes
{
    public class Vector3Int
    {
        #region Get/Set
        public int X { get; set; }
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
}