using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpMultiball : MonoBehaviour {

	public GameObject ball;

    public GameObject powerCan;

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
			var ballRot = hit.GetComponent<Rigidbody>().rotation;
			Quaternion rot1 = new Quaternion (ballRot.x, (ballRot.y + 1), ballRot.z, ballRot.w);
			Quaternion rot2 = new Quaternion (ballRot.x, (ballRot.y - 1), ballRot.z, ballRot.w);
			Instantiate (ball, hit.transform.position, rot1);
			Instantiate (ball, hit.transform.position, rot2);
			Debug.Log ("You triggered a multi-ball!");

            #region 1314371
            GameObject.FindGameObjectWithTag( "MainCamera" ).GetComponent<cannon>().playSound( 1 );
            Instantiate(powerCan, new Vector3(0, 0, 0), Quaternion.identity);
            #endregion

        }
	}
}
