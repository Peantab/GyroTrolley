using UnityEngine;
using System;
using System.Collections;

public class GenrateTrack : MonoBehaviour {
	public GameObject[] chunks;
    public GameObject[] chunksTown;
	public const int MAX = 451;
	public const float chunk_size_coef = 10f;
	private GameObject[] chunkBuffer = new GameObject[MAX];
	private int index = 15;
	private ulong total = 15;
    private System.Random rand;
    // Use this for initialization
    void Start () {
        rand = new System.Random();
		for (int i=0; i<(index-1); i++) {
			chunkBuffer[i] = GameObject.Instantiate(chunks[rand.Next() % (chunks.Length-1)]);
			chunkBuffer[i].transform.position = new Vector3(0f,0f,i*chunk_size_coef);
		}
        chunkBuffer[index-1] = GameObject.Instantiate(chunks[2]);
        chunkBuffer[index-1].transform.position = new Vector3(0f, 0f, (index-1) * chunk_size_coef);
    }
	
	// Update is called once per frame
	void Update () {
		if (chunkCounter.countCalls > 0) {
			chunkCounter.countCalls--;
			Destroy (chunkBuffer[index]);
			chunkBuffer[index] = GameObject.Instantiate(chunksTown[rand.Next() % (chunksTown.Length)]);
            chunkBuffer[index].transform.position = new Vector3(0f,0f,total*chunk_size_coef);
			total++;
			index++;
			if(index >= MAX) index=0;
		}
			
	}
}
