//File: objectSpawn.cs
//Author: 1314371
//Date Created: 09MAR2015 @ 10:23
//Last Modified: N/A
//Description: File for object spawner script
using UnityEngine;
using System.Collections;

public class objectSpawn : MonoBehaviour {

    public GameObject obj;

    public GameObject sparkle;

    private float timer;

    Vector3 pos;

	void Start () {

        timer = 10;

        pos = new Vector3( transform.position.x, transform.position.y + 2, transform.position.z );

	}

	void Update () {
	
        if( transform.childCount == 0 )
        {

            if( timer > 0 )
            {

                timer -= Time.deltaTime;

            }
            else
            {

                timer = 10;

                Instantiate(sparkle, pos, Quaternion.identity);

                Instantiate(obj, pos, Quaternion.identity);

            }

            

        }

	}
}
