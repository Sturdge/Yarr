//File: cannonBall.cs
//Author: 1314371
//Date Created: 20FEB2015 @ 10:26
//Last Modified: 04MAR2015 @ 10:13
//Description: File for cannon ball mechanics
using UnityEngine;
using System.Collections;

public class cannonBall : MonoBehaviour {

    public static int velocity;

    private int rng;

    public GameObject explosion;

    public GameObject blood;

    public GameObject[] power = new GameObject[3];

	void Start () {

        if( this.tag == "projectilePlayer" )
        {

            velocity = -100;

        }
        else 
        {

            velocity = 100;

        }

        GetComponent<Rigidbody>().velocity = transform.TransformDirection( new Vector3( velocity, 0, 0 ) );

	}

	void Update () {

	}

    void OnTriggerEnter( Collider other )
    {

        if (other.tag != "gameZone")
        {
            if (this.tag == "projectilePlayer")
            {

                if ( other.tag != "Player" && other.tag != "cannonP" && other.tag != "projectilePlayer" && other.tag != "shield" && other.tag != "ship" )
                {
					Destroy(other.gameObject);

                    #region items
                    if (other.tag == "cabinboy")
                    {

                        Instantiate(blood, other.transform.position, Quaternion.identity);

                    }
                    else if (other.tag == "engineer")
                    {

                        Instantiate(blood, other.transform.position, Quaternion.identity);

                    }
                    else
                    {

                        Instantiate(explosion, other.transform.position, Quaternion.identity);

                    }
                    #endregion

                    #region powerUps

                    if (other.tag != "powerUp")
                    {

                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cannon>().incRage();

                        rng = Random.Range(0, 20);

                        if (rng >= 0 && rng <= 2)
                        {

                            Instantiate(power[0], other.transform.position, Quaternion.identity);

                        }
                        else if (rng >= 3 && rng <= 5)
                        {

                            Instantiate(power[1], other.transform.position, Quaternion.identity);

                        }
                        else if (rng >= 6 && rng <= 8)
                        {

                            Instantiate(power[2], other.transform.position, Quaternion.identity);

                        }
                        else if (rng >= 9 && rng <= 11)
                        {

                            Instantiate(power[3], other.transform.position, Quaternion.identity);

                        }

                    }

                    #endregion

                }

            }

            if ( this.tag == "projectileEnemy" )
            {

                if ( other.tag != "cannonE" && other.tag != "boss" )
                {

                    Destroy( this.gameObject );

                }

                if( other.tag == "shield" )
                {

                    Destroy( this.gameObject );

                    Destroy( other.gameObject );

                }

            }

        }

    }

    void OnTriggerExit( Collider other )
    {

        if(other.tag == "gameZone")
        {

            Destroy(this.gameObject);

        }

    }

}
