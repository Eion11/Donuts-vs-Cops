using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutTilePlacement : MonoBehaviour
{
	private string tileName;
	public GameObject lane;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	public void setTileNameString(string theTileName)
	{
		tileName = theTileName;
	}

	public string getTileNameString()
	{
		return tileName;
	}
}
