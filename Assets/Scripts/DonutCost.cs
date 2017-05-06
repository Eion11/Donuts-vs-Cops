using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonutCost : MonoBehaviour {

	public int donutCost = 75;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = donutCost.ToString();
	}
}
