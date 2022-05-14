//File: ship.cs
//Author: 1314371
//Date Created: 04MAR2015 @ 08:40
//Last Modified: N/A
//Description: File to add bobbing motion to ships
using UnityEngine;
using System.Collections;

public class ship : MonoBehaviour {

    int timer;

    int dir;

    float y;

	void Start () {

        timer = 0;

        dir = 0;

        y = transform.position.y;

	}

	void Update () {
	
        timerTick();

        transform.position = new Vector3( transform.position.x, y, transform.position.z );

	}

    void timerTick()
    {

        if (timer < 50)
        {

                timer++;

        }
        else
        {

            if (dir == 0)
            {

                dir = 1;

                y -= 0.5f;

            }
            else
            {

                dir = 0;

                y += 0.5f;

            }

                timer = 0;

           }

      }
        

}
