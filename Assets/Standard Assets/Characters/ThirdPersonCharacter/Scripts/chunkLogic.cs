using UnityEngine;
using System.Collections;

public class chunkLogic : MonoBehaviour {
	private bool entered;
	// Use this for initialization
	void Start () {
		entered = false;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		if (!entered) {
			chunkCounter.countCalls++;
			entered=true;
			//Debug.Log("AAAA");
		}
	}
}
