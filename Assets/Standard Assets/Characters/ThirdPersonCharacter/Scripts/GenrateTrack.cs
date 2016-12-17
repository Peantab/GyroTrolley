using UnityEngine;
using System.Collections;

public class GenrateTrack : MonoBehaviour {
	public GameObject[] chunks;
	public const int MAX = 451;
	public const float chunk_size_coef = 1f;
	private GameObject[] chunkBuffer = new GameObject[MAX];
	private int index = 151;
	private ulong total = 151;
	// Use this for initialization
	void Start () {
		for (int i=0; i<index; i++) {
			chunkBuffer[i] = GameObject.Instantiate(chunks[0]);
			chunkBuffer[i].transform.position = new Vector3(0f,0f,i*chunk_size_coef);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (chunkCounter.countCalls > 0) {
			chunkCounter.countCalls--;
			Destroy (chunkBuffer[index]);
			chunkBuffer[index] = GameObject.Instantiate(chunks[0]);
			chunkBuffer[index].transform.position = new Vector3(0f,0f,total*chunk_size_coef);
			total++;
			index++;
			if(index >= MAX) index=0;
		}
			
	}
}
