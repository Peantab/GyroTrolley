using UnityEngine;
using System.Collections;

public class CamFollowScript : MonoBehaviour {
	public Transform m_Cam;
	public Transform character;
	public float deltaX;
	public float deltaY;
	public float deltaZ;
	public float rotateX;
	// Use this for initialization
	void Start () {
		m_Cam.Rotate(new Vector3 (rotateX,0,0));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = character.position;

		pos.x += deltaX;
		pos.y += deltaY;
		pos.z += deltaZ;

		m_Cam.position = pos;
	}
}
