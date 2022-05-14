//File: powerIndicator.cs
//Author: 1314371
//Date Created: 09MAR2015 @ 09:39
//Last Modified: N/A
//Description: File for cannon control
using UnityEngine;
using System.Collections;

public class powerIndicator : MonoBehaviour {

	void Update () {

        for (int i = 0; i < 2; i++ )
        {

            if( GameObject.FindGameObjectsWithTag( "powerMsg" ) != null )
            {

                Destroy(this.gameObject);

            }

        }

	}
}
