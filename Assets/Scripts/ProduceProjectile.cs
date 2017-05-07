using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceProjectile : MonoBehaviour {

	public float prodTimer = 0.2f;
	public GameObject projectilePrefab;
	GameObject projectileClone;

	GameObject lane;
	private string laneName;
	private bool startedShooting = false;

	// Use this for initialization
	void Start () {
		lane = GameObject.Find (laneName);
	}
	
	// Update is called once per frame
	void Update () {

		if (lane.GetComponent<ShootOnLane> ().copActive == true && startedShooting == false)
		{
			InvokeRepeating ("createProjectile", 0, prodTimer);
			startedShooting = true;
		}
		else if ( lane.GetComponent<ShootOnLane> ().copActive == false )
		{
			CancelInvoke ();
			startedShooting = false;
		}
	}

	private void createProjectile(){
		projectileClone = Instantiate (projectilePrefab, transform.position, Quaternion.identity) as GameObject;
	}

	public void setLane(string name)
	{
		laneName = name;
	}
}
