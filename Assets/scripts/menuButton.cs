using UnityEngine;
using System.Collections;

public class menuButton : MonoBehaviour {

	public Canvas[] menuScreens;

	void Start(){
		ScreenSwitch (0);
	}

	public void NextLevelButton(int index)			//loads the specified level when the button is clicked
	{
		Application.LoadLevel(index);
	}
	
	public void NextLevelButton(string levelName)	//loads the specified level when the button is clicked
	{
		Application.LoadLevel(levelName);
	}

	public void ScreenSwitch(int index)				//switches between the menu panels
	{
		foreach(Canvas screen in menuScreens){
			screen.enabled = false;
		}
		menuScreens[index].enabled = true;
	}

	public void FullScreenToggle(){					//toggles fullscreen on and off
		if (Screen.fullScreen)
		{
			Screen.fullScreen = false;
		}
		else
		{
			Screen.fullScreen = true;
		}
	}

	public void ExitGame()							//exits the game
	{
		Application.Quit();
	}
}
