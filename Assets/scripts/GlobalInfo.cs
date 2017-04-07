using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInfo
{
    private static GlobalInfo _instance;
    public static GlobalInfo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GlobalInfo();
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

	public GlobalInfo()
	{
		money = 100;
		UpgradeLevel = new List<int> {
			0, 0, 0, 0, 0, 0
		};
        currentWave = 0;
	}

    public int money;
    public List<int> UpgradeLevel;

    public int currentWave;

    public int GetShooterUpgradeLevel()
    {
        return UpgradeLevel[0];
    }

    public int GetJudgementUpgradeLevel()
    {
        return UpgradeLevel[1];
    }

    public int GetCatSlowUpgradeLevel()
    {
        return UpgradeLevel[2];
    }

    public int GetPerfectRewardUpgradeLevel()
    {
        return UpgradeLevel[3];
    }

    public int GetBadPanelyUpgradeLevel()
    {
        return UpgradeLevel[4];
    }

    public int GetMeatPriceUpgradeLevel()
    {
        return UpgradeLevel[5];
    }
}
