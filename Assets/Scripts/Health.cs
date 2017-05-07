using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public double maxHealth = 10;
	public double currentHealth;
	public double deathTestDamage = 0.1;

	// Use this for initialization
	void Start()
	{
		currentHealth = maxHealth;	
	}
	
	// Update is called once per frame
	void Update()
	{
		takeDamage(deathTestDamage);
	}

	public void takeDamage(double damage)
	{
		if (currentHealth - damage >= 0)
		{
			currentHealth -= damage;
		}
		else
		{
			currentHealth = 0;
		}
	}
}
