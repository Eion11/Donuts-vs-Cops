using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceProjectile : MonoBehaviour {

	public float prodTimer = 0.2f;
	public GameObject projectilePrefab;
	GameObject projectileClone;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("createProjectile", prodTimer, prodTimer);
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void createProjectile(){
		projectileClone = Instantiate (projectilePrefab, transform.position, Quaternion.identity) as GameObject;
	}
}
