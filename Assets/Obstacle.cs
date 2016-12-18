using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider col) {
        //if (!entered) {
        UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl.sinceCol = 0;
            //entered = true;
        //}
    }
}
