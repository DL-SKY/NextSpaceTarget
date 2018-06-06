

public class SpaceshipData : SpaceshipsConfig
{
    #region Variables
    public bool isPlayer;

    private SpaceshipsConfig config;
    #endregion

    #region Constructors
    /*public SpaceshipData(SpaceshipsConfig _currentData)
    {
        this.Copy(_currentData);
        SetConfig();
    }*/

    public SpaceshipData(string _id)
    {
        SetConfig(_id);
        this.Copy(config);       
    }
    #endregion

    #region Public methods
    public SpaceshipsConfig GetConfig()
    {
        return config;
    }    
    #endregion

    #region Private methods
    private void SetConfig()
    {
        config = Global.Instance.CONFIGS.spaceships.GetConfig(id);
    }

    private void SetConfig(string _id)
    {
        config = Global.Instance.CONFIGS.spaceships.GetConfig(_id);
    }
    #endregion
}