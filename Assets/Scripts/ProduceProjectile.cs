using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceProjectile : MonoBehaviour
{
	public float projectileFireRate;
	public GameObject projectilePrefab;
	private GameObject lane;
	private bool startedShooting = false;

	// Use this for initialization
	void Start()
	{
		lane = GetComponent<DonutTilePlacement>().lane;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (lane.GetComponent<DetectCopInLane>().copActive == true && startedShooting == false)
		{
			InvokeRepeating("createProjectile", 0, projectileFireRate);
			startedShooting = true;
		}
		else if (lane.GetComponent<DetectCopInLane>().copActive == false)
		{
			CancelInvoke();
			startedShooting = false;
		}
	}

	private void createProjectile()
	{
		Instantiate(projectilePrefab, transform.position, Quaternion.identity);
	}
}
