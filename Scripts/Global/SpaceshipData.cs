

public class SpaceshipData : SpaceshipsConfig
{
    #region Variables
    public bool isPlayer;

    private SpaceshipsConfig config;
    #endregion

    #region Constructors
    public SpaceshipData(SpaceshipsConfig _currentData)
    {
        this.Copy(_currentData);
        SetConfig();
    }
    #endregion

    #region Public methods
    public SpaceshipsConfig GetConfig()
    {
        return config;
    }

    public void SetConfig(string _id)
    {
        config = Global.Instance.CONFIGS.spaceships.GetConfig(_id);
    }
    #endregion

    #region Private methods
    private void SetConfig()
    {
        config = Global.Instance.CONFIGS.spaceships.GetConfig(id);
    }
    #endregion
}