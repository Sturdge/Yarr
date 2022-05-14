using UnityEngine;
using System.Collections;

public class PowerUpShield : MonoBehaviour {
	
	public GameObject shield;

    public GameObject power;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate( 2, 2, 0 );
	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.tag == "projectilePlayer")
		{
			Vector3 pos = new Vector3(15.24f, 11.9f, -7.84f);
			Quaternion rot = new Quaternion(0,0,0,0);
			Instantiate (shield, pos, rot);
			Debug.Log ("You got the Shield!");

            #region 1314371
            GameObject.FindGameObjectWithTag( "MainCamera" ).GetComponent<cannon>().playSound( 0 );
            Instantiate(power, new Vector3(0, 0, 0), Quaternion.identity);
            #endregion

        }
	}
}
