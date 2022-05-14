//File: engineer.cs
//Author: 1314371
//Date Created: 20FEB2015 @ 09:18
//Last Modified: 09MAR2015 @ 08:13
//Description: File for cannon control
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cannon : MonoBehaviour{

	public GameObject[] cannons = new GameObject[4];

    public GameObject[] aim = new GameObject[4];

	public GameObject cursor;

    public GameObject cannonBall;

    public GameObject pausePanel;

    public AudioClip[] voiceOver = new AudioClip[5];

    public Text rageTxt;

    private int[] rotY = new int[4];

    private int[] cooldown = new int[4];

	private int activeCannon;

    private int rage;

    private int scoreMultiplier;

    private bool camtest;

    private bool isPaused;

	void Start () {

        this.transform.eulerAngles = new Vector3(90, 270, 0);

        this.transform.position = new Vector3(10.5f, 120, -1);

        isPaused = false;

        camtest = false;

        activeCannon = 0;

        for (int i = 0; i < 4; i++ )
        {

            rotY[i] = 0;

            aim[i].SetActive(false);

            cooldown[i] = 0;

        }

        aim[activeCannon].SetActive(true);

        scoreMultiplier = 1;

	}

	void Update () {

        rageTxt.text = "Score: " + rage.ToString();

		cursor.transform.position = cannons[activeCannon].transform.position;

        cursor.transform.position = new Vector3(cursor.transform.position.x, 10.5f, cursor.transform.position.z);

        if( camtest )
        {

            this.transform.position = cannons[activeCannon].transform.position;

            this.transform.position = new Vector3(cursor.transform.position.x, 15, cursor.transform.position.z);

            this.transform.eulerAngles = new Vector3(cannons[activeCannon].transform.eulerAngles.x, cannons[activeCannon].transform.eulerAngles.y + 270, cannons[activeCannon].transform.eulerAngles.z);

        }

        cannonControl();

        cooling();

        if( Input.GetKeyDown( KeyCode.P ) )
        {

            changeCam();

        }

        if( Input.GetKeyDown( KeyCode.Escape ) )
        {

            togglePause();

        }
        
	}

    void cannonControl()
    {

        #region fire
        if ( Input.GetKeyDown(KeyCode.Space) )
        {

            if( cooldown[activeCannon] == 0 )
            {

                playSound(4);

                cooldown[activeCannon] = 150;

                Instantiate(cannonBall, cannons[activeCannon].transform.position, cannons[activeCannon].transform.localRotation);

                if (activeCannon < 3)
                {

                    activeCannon++;

                }
                else
                {

                    activeCannon = 0;

                }

                for (int i = 0; i < 4; i++)
                {

                    aim[i].SetActive(false);

                }

                aim[activeCannon].SetActive(true);

            }
            

        }
        #endregion

        #region rotate
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            if( rotY[activeCannon] > -40)
            {

                rotY[activeCannon]--;
            }

            cannons[activeCannon].transform.eulerAngles = new Vector3( 0, rotY[activeCannon], 0 ); 

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            if( rotY[activeCannon] < 40)
            {

                rotY[activeCannon]++;
            }

            cannons[activeCannon].transform.eulerAngles = new Vector3( 0, rotY[activeCannon], 0 ); 

        }
        #endregion

    }

    void changeCam()
    {

        if( !camtest )
        {

            camtest = true;

            this.transform.eulerAngles = new Vector3( 0, 270, 0 );

        }
        else
        {

            camtest = false;

            this.transform.eulerAngles = new Vector3( 90, 270, 0 );

            this.transform.position = new Vector3( 10.5f, 120, -1 );

        }

    }

    public void setMulti( int x )
    {

        scoreMultiplier = x;
        
    }

	public void incRage()
	{
        
        rage += ( 1 * scoreMultiplier );

	}

    public int getRage()
    {

        return rage;

    }

    public void playSound( int x )
    {

        GetComponent<AudioSource>().clip = voiceOver[x];

        GetComponent<AudioSource>().Play();

    }

    void cooling()
    {

        for (int i = 0; i < 4; i++ )
        {

            if( cooldown[i] > 0 )
            {

                cooldown[i]--;

            }

        }

    }

    public void togglePause()
    {

        if( isPaused )
        {

            pausePanel.SetActive( false );

            isPaused = false;

            Time.timeScale = 1;

        }
        else
        {

            pausePanel.SetActive( true );

            isPaused = true;

            Time.timeScale = 0;

        }

    }

    public void toMenu()
    {

        Application.LoadLevel( "MainMenu" );

    }

}
