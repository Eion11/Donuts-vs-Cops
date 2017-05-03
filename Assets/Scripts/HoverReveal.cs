using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverReveal : MonoBehaviour {

	public bool visible;

	// Use this for initialization
	void Start ()
	{
		visible = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (visible)
		{
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.25f);
		}
		else
		{
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.1f);
		}
	}

	private void OnMouseOver()
	{
		visible = true;
	}

	private void OnMouseExit()
	{
		visible = false;
	}
}
