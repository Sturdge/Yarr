//File: cabinboy.cs
//Author: 1314371
//Date Created: 27FEB @ 09:31
//Last Modified: N/A
//Description: File for cabin boy Artificial "Intelligence"
using UnityEngine;
using System.Collections;

public class cabinboy : MonoBehaviour {

	private int dir;

	void Start()
	{

		dir = 0;

	}

	void Update () {

        if( Time.timeScale == 1 )
        {

            move();

            switchDir();

            kill();

        }

	}

	void move()
	{

		if( dir == 0 )
		{
			
			transform.Translate( 0, 0, -0.1f );
			
		}
		else
		{
			
			transform.Translate( 0, 0, 0.1f );
			
		}

	}

	void switchDir()
	{

		if( transform.position.z <= -50 )
		{

			dir = 1;

		}

	}

	void kill()
	{

		if( transform.position.z >= 37 )
		{

			Destroy (this.gameObject);

		}

	}

}