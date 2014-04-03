using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour {

	public List<Transform> targets;
	public Transform selectedTarget;


	// Use this for initialization
	void Start () {
		targets = new List<Transform> ();
		selectedTarget = null;
//		myTransform = transform;
		
		AddAllEnemies();

	}

	public void AddAllEnemies(){
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Enemy");
		
		foreach(GameObject enemy in go)
			AddTarget(enemy.transform);
	}

	public void AddTarget(Transform enemy) {
		targets.Add(enemy);
	}

	private void TargetEnemy (){
		if (selectedTarget == null) {
//			sortTargetByDistance ();
			selectedTarget = targets [0];
		} else {
			int index = targets.IndexOf(selectedTarget);
			
			if(index < targets.Count - 1){
				index++;
			} else {
				index = 0;
			}
//			deselectTarget();
			selectedTarget = targets[index];
			
		}
//		selectTarget();	
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			TargetEnemy();			
		}
	}
}
