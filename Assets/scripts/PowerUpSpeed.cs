using UnityEngine;
using System.Collections;

public class PowerUpSpeed : MonoBehaviour {

	private float speedTimer;
	private float speedLife = 7.5f;

    public GameObject power;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate( 2, 2, 0 );
		if (Time.time > speedTimer + speedLife && cannonBall.velocity == -200){
			cannonBall.velocity = -100;
			Debug.Log ("The turbo power ran out.");
		}
	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.tag == "projectilePlayer")
		{
			hit.GetComponent<Rigidbody>().velocity = (hit.GetComponent<Rigidbody>().velocity * 2);
			Debug.Log ("You got the turbo power!");
			cannonBall.velocity = -200;
			speedTimer = Time.time;

            #region 1314371
            GameObject.FindGameObjectWithTag( "MainCamera" ).GetComponent<cannon>().playSound( 2 );
            Instantiate(power, new Vector3(0, 0, 0), Quaternion.identity);
            
            #endregion
        }
	}
}
