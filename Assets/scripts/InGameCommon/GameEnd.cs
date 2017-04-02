using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEndReceiver
{
}

public static class GameEndReceiverExtension
{
    public static void OnGameEnd(this IGameEndReceiver receiver)
    {
        MonoBehaviour component = receiver as MonoBehaviour;
        if (component != null)
        {
            component.enabled = false;
        }
    }
}

public class GameEnd : MonoBehaviour
{
    public static GameEnd Instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instance = this;
    }

	public bool isGameEnd = false;

    public GameObject clear;
    public GameObject fail;

    public void Clear()
    {
        Stop();
		clear.SetActive(true);
        // BackgroundMusic.FadeOutAndChangeScene("Shop");
    }

    public void Fail()
    {
        Stop();
		fail.SetActive(true);
        // BackgroundMusic.FadeOutAndChangeScene("Start");
    }

    private void Stop()
    {
		isGameEnd = true;
        Transform[] gameEndReceivers = FindObjectsOfType<Transform>() as Transform[];
        
        foreach (var receiver in gameEndReceivers)
        {
            var gameendReceivers = receiver.GetComponents<IGameEndReceiver>();
			foreach (var gameendReceiver in gameendReceivers)
			{
				Debug.Log("find gameend receiver " + gameendReceiver);
                gameendReceiver.OnGameEnd();				
			}
        }


        //dirty method
        var waveTime = FindObjectOfType<WaveTime>();
        if (waveTime) {
            Destroy(waveTime);
        }
    }
  
}
