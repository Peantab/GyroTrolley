using UnityEngine;
using System.Collections;

public class GenrateTrack : MonoBehaviour {
	public GameObject[] chunks;
	public const int MAX = 451;
	public const float chunk_size_coef = 10f;
	private GameObject[] chunkBuffer = new GameObject[MAX];
	private int index = 20;
	private ulong total = 20;
	// Use this for initialization
	void Start () {
		for (int i=0; i<(index-1); i++) {
			chunkBuffer[i] = GameObject.Instantiate(chunks[0]);
			chunkBuffer[i].transform.position = new Vector3(0f,0f,i*chunk_size_coef);
		}
        chunkBuffer[index-1] = GameObject.Instantiate(chunks[1]);
        chunkBuffer[index-1].transform.position = new Vector3(0f, 0f, (index-1) * chunk_size_coef);
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
