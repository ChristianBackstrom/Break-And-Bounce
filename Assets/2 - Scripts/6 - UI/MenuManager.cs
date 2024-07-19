using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public void QuitGame()
	{
		// Quit the game
		Application.Quit();
	}

	public void LoadScene(string name)
	{
		// Load the scene with the given name
		SceneManager.LoadScene(name);
	}
}
