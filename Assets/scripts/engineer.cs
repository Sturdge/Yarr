//File: engineer.cs
//Author: 1314371
//Date Created: 04MAR2015 @ 09:36
//Last Modified: N/A
//Description: File for engineer Artificial "Intelligence"
using UnityEngine;
using System.Collections;

public class engineer : MonoBehaviour {

    public GameObject[] selectedCannon = new GameObject[3];

    public GameObject[] target = new GameObject[4];

    public GameObject cannonBall;

    private int selectedRNG;

    private int targetRNG;

    private int dir;

    private bool ready;

	void Start () {

        selectedRNG = Random.Range( 0, 2 );

        selectedCannon = GameObject.FindGameObjectsWithTag( "cannonE" );

        ready = false;

        dir = 0;

	}
	
	void Update () {

        if( Time.timeScale == 1 )
        {

            move();

            shoot();

        }

	}

    void move()
    {

        switch( dir )
        {

            case 0:
                
                transform.Translate(0, 0, -0.2f);

                break;

            case 1:

                transform.Translate(0, 0, 0.2f);

                break;

        }
        

        if( transform.position.z <= selectedCannon[selectedRNG].transform.position.z )
        {

            dir = 1;

            ready = true;

        }

        if( transform.position.z >= 45 )
        {

            Destroy(this.gameObject);

        }

    }

    void shoot()
    {

        if( ready )
        {

            Instantiate(cannonBall, selectedCannon[selectedRNG].transform.position, Quaternion.identity);

            ready = false;

        }
        
    }

}
