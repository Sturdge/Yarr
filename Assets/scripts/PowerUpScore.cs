using UnityEngine;
using System.Collections;

public class PowerUpScore : MonoBehaviour {

	private float scoreTimer;
	private float scoreLife = 7.5f;

    public GameObject powerTxt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate( 2, 2, 0 );
		if (Time.time > scoreTimer + scoreLife){
            GameObject.Find( "Main Camera" ).GetComponent<cannon>().setMulti( 1 );
		}
	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.tag == "projectilePlayer")
		{
            GameObject.Find("Main Camera").GetComponent<cannon>().setMulti( Random.Range( 2, 5 ) );
			scoreTimer = Time.time;

            #region 1314371
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cannon>().playSound(3);
            Instantiate(powerTxt, new Vector3(0, 0, 0), Quaternion.identity);
            #endregion


		}
	}
}
