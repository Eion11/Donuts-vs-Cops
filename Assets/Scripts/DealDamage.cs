using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour {

	public double damageAmount = 0;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cop")
        {
			other.gameObject.GetComponent<Health>().takeDamage(damageAmount);
			GetComponent<Health>().takeDamage(GetComponent<Health>().currentHealth);
        }
        


    }
}
