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
}