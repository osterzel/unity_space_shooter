using UnityEngine;
using System.Collections;

public class GameRestart : MonoBehaviour {
	
	void OnGUI() {

		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2, 100, 50), "Restart"))
						Application.LoadLevel (0);
		//if (GUI.Button(new Rect(190, 320, 100, 50), "Restart"))
		//	Application.LoadLevel(0);
	}
	


}