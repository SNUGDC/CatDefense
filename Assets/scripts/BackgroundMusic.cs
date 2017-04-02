using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instance = this;
    }

	IEnumerator banishCoroutine = null;

    public static void FadeOutAndChangeScene(string sceneName)
    {
        if (Instance != null)
        {
			if (Instance.banishCoroutine != null)
			{
				Debug.LogWarning("Already changing scene");
				return;
			}
			Instance.banishCoroutine = Instance.FadeOutAndChangeSceneRoutine(sceneName);
            Instance.StartCoroutine(Instance.banishCoroutine);
        }
        else
        {
			BackgroundMusic.FadeOutAndChangeScene(sceneName);
        }
    }

    IEnumerator FadeOutAndChangeSceneRoutine(string sceneName)
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeOut()
    {
        float remainTime = 1.0f;
        AudioSource source = GetComponent<AudioSource>();
        while (remainTime > 0)
        {
            source.volume = remainTime;
            remainTime -= Time.deltaTime;
            yield return null;
        }
    }
}
