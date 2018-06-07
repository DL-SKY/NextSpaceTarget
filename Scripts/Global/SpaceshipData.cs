using System.Collections.Generic;

public class SpaceshipData : SpaceshipsConfig
{
    #region Variables
    public bool isPlayer;
    public List<string> equipments = new List<string>();

    private SpaceshipsConfig config;    
    #endregion

    #region Constructors
    public SpaceshipData(string _id, int _lvl, List<string> _equipments, bool _player = false)
    {
        SetConfig(_id);
        this.Copy(config);

        level = _lvl;
        equipments = _equipments;

        isPlayer = _player;

        ApplyLevel();
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

    private void ApplyLevel()
    {
        if (level > 1)
        {
            hitPoints = config.hitPoints * ((level - 1) * config.coefLvlHP);
            maneuver = config.maneuver * ((level - 1) * config.coefLvlManeuver);
            repairTime = (int)(config.repairTime * ((level - 1) * config.coefLvlRepair));
        }
    }
    #endregion
}