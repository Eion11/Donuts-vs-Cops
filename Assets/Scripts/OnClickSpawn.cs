using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSpawn : MonoBehaviour {

    public GameObject donutPrefab;
    GameObject donutClone;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnMouseOver()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            PlaceTower();
        }
    }

    private void PlaceTower()
    {
        donutClone = Instantiate(donutPrefab, transform.position, Quaternion.identity) as GameObject;
    }
}
