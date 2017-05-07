using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDonutPlacement : MonoBehaviour
{
	private string tileName;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	public void setTileString(string theTileName)
	{
		tileName = theTileName;
	}

	public string getTileString()
	{
		return tileName;
	}
}
