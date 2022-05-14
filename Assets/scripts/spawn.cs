//File: spawn.cs
//Author: 1314371
//Date Created: 27FEB2015 @ 09:20
//Last Modified: N/A
//Description: File for enemy spawner script
using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

	private int spawnTime;

	private int rng;

    private int spawned;

	public GameObject cabinBoy;

    public GameObject engineer;

	public GameObject[] spawners = new GameObject[5];


	void Start () {
	
		spawnTime = 200;

	}
	
	void Update () {

		if (spawnTime > 0) {

			spawnTime--;

		}
		else
		{

            spawnTime = 200; //spawnTime -= ( GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cannon>().getRage() / 10 );

            spawned = Random.Range(0, 9);

			rng = Random.Range( 0, 4 );

            if( spawned < 6 )
            {

                Instantiate(cabinBoy, spawners[rng].transform.position, Quaternion.identity);

            }
            else
            {

                Instantiate(engineer, spawners[4].transform.position, Quaternion.identity);

            }
			

		}

	}
}
