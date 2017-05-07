using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float xMoveSpeed;
    public float maxX;
	private GameObject winCondition;
	private bool reachedEnd = false;

    // Use this for initialization
    void Start()
    {
		winCondition = GameObject.Find ("WinCondition");
    }

    // Update is called once per frame
    void Update()
    {
        updatePosition();
        checkMaxX();
    }

    private void updatePosition()
    {
        float x = transform.position.x + xMoveSpeed;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }

    private void checkMaxX()
    {
        if(maxX>0)
        { 

            if (transform.position.x > maxX)
            {
                GetComponent<Health>().takeDamage(GetComponent<Health>().maxHealth);
            }
        }
        else
        {
            if (transform.position.x < maxX)
            {
				xMoveSpeed = 0;

				if (reachedEnd == false) {
					winCondition.GetComponent<WinCondition> ().copsPassed += 1;
					reachedEnd = true;
				}
            }
        }
    }
}
