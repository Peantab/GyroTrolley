using UnityEngine;
using System.Collections;

public class MoveObjectForward : MonoBehaviour {
	public Transform m_Cam;
	public Transform character;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = character.position;
		m_Cam.position = pos;
	}
}
