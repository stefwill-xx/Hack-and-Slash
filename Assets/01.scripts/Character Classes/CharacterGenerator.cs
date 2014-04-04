using UnityEngine;
using System.Collections;

public class CharacterGenerator : MonoBehaviour {

	private PlayerCharacter _toon;

	// Use this for initialization
	void Start () {
		_toon = new PlayerCharacter();
		_toon.Awake();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
//		GUI.skin = mySkin;
		
		DisplayName();
//		DisplayPointsLeft();
//		DisplayAttributes();
//		DisplayVitals();
//		DisplaySkills();
		
		
	}
	private void DisplayName() {
		GUI.Label(new Rect(10, 10, 50, 25), "Name:");
		_toon.Name = GUI.TextField(new Rect(115, 10, 100, 25), _toon.Name);
	}

}
