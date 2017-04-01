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
    }

	public GlobalInfo()
	{
		money = 0;
		UpgradeLevel = new List<int> {
			0, 0, 0, 0, 0, 0
		};
	}

    public int money;
    public List<int> UpgradeLevel;

}
