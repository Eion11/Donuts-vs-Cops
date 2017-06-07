using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour 
{
	
	GameObject[] pauseObjects;
	GameObject[] confermationObjects;
	GameObject[] mainMenuObjects;
	bool paused = false;

	private enum enQuery 
	{
		Restart, Exit, MainMenu
	};

	private enQuery enCurrent;


	void Start () 
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("ShowOnPause");
		confermationObjects = GameObject.FindGameObjectsWithTag ("ShowOnConfermation");
		mainMenuObjects = GameObject.FindGameObjectsWithTag ("ShowOnMainMenu");
		hidePaused ();
		hideConfermation ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				paused = true;
				showPaused ();
			} else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				paused = false;
				hidePaused ();
			}
		}
	}

	public void SetQueryToRestart()
	{
		enCurrent = enQuery.Restart;
	}

	public void SetQueryToMainMenu()
	{
		enCurrent = enQuery.MainMenu;
	}

	public void SetQueryToExit()
	{
		enCurrent = enQuery.Exit;
	}

	public void ExecuteCurrentQuery()
	{
		if (enCurrent == enQuery.Restart)
		{
			Reload ();
		}
		else if (enCurrent == enQuery.MainMenu)
		{
			LoadMainMenu ();
		}
		else if (enCurrent == enQuery.Exit)
		{
			Application.Quit ();
		}
	}

	public void ToggleConfermationOn()
	{
		hidePaused ();
		hideMainMenu ();
		showConfermation ();
	}

	public void ToggleConfermationOff()
	{
		hideConfermation ();
		showMainMenu ();
		showPaused ();
	}

	private void Reload()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene (scene.name);
	}

	private void Exit()
	{
		Application.Quit ();
	}

	//controls the pausing of the scene
	public void pauseControl()
	{
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			paused = true;
			showPaused();
		} else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			paused = false;
			hidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused()
	{
		foreach(GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused()
	{
		foreach(GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	//shows objects with ShowOnMainMenu tag
	public void showMainMenu()
	{
		foreach(GameObject g in mainMenuObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnMainMenu tag
	public void hideMainMenu()
	{
		foreach(GameObject g in mainMenuObjects)
		{
			g.SetActive(false);
		}
	}

	//shows objects with ShowOnConfermation tag
	public void showConfermation()
	{
		foreach(GameObject g in confermationObjects)
		{
			g.SetActive (true);
		}
	}

	//hides objects with ShowOnConfermation tag
	public void hideConfermation()
	{
		foreach(GameObject g in confermationObjects)
		{
			g.SetActive (false);
		}
	}

	private void LoadMainMenu()
	{
		LoadLevel ("Main Menu");
	}

	//loads inputted level
	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene (levelName);
	}

	public bool getPausedState()
	{
		return paused;
	}
}
