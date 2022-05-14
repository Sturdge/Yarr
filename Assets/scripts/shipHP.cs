//File: shipHP.cs
//Author: 1314371
//Date Created: 05MAR2015 @ 12:12
//Last Modified: 05MAR2015 @ 12:55
//Description: File for ship health
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shipHP : MonoBehaviour {

    private int hp;

    public Text hpTxt;

	void Start () {

        hp = 10;

	}

	void Update () {

        hpTxt.text = "Health: " + hp.ToString();

	}

    void OnTriggerEnter( Collider other )
    {

        if( other.tag == "projectileEnemy" )
        {

            if (hp > 1)
            {

                hp--;

            }
            else
            {

                Application.LoadLevel( "MainMenu" );

            }

        }
        

    }

}
