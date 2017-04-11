using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour {

	public List<GameObject> tutorials;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		StartCoroutine(TutorialCoroutine());
	}

	IEnumerator TutorialCoroutine()
	{
		foreach (var tutorial in tutorials)
		{
			tutorials.ForEach(t => t.SetActive(false));
			tutorial.SetActive(true);
			yield return new WaitForSeconds(5f);
		}

		SceneManager.LoadScene("Main");
	}

	public void SkipTutorial()
	{
		SceneManager.LoadScene("Main");
	}
}
