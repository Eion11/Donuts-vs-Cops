using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
	
	GameObject[] pauseObjects;
	bool paused = false;
	void Start () 
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("ShowOnPause");
		hidePaused ();
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

	public void Reload()
	{
		//put load level code here
		//SceneManager.LoadScene()....
		//SceneManager is a built in Unity class.
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

	//loads inputted level
	public void LoadLevel(string levelName)
	{
		Application.LoadLevel (levelName);
	}

	public bool getPausedState()
	{
		return paused;
	}
}
