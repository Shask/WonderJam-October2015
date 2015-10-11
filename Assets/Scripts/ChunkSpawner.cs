using UnityEngine;
using System.Collections;

public class ChunkSpawner : MonoBehaviour {


    private System.Random random;
    public float CurrentMusicSpeed;
    public AudioSystem audioSys;

//    private float cooldown = 1.0f;
 //   private float timer;

    // Use this for initialization
    void Start () {
        random = new System.Random();
        audioSys = GameObject.Find("Audio System").GetComponent<AudioSystem>();
        //    timer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        CurrentMusicSpeed = 30.0f * audioSys.debugvalue;
    /*    if(timer>0.0f)
        {
            timer -= Time.deltaTime;
        }*/

    }
    public void SpawnChunk()
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("Chunk"+ random.Next(1,4)), transform.position, transform.rotation);
        go.transform.parent = transform;
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag=="Chunk")
        {
            SpawnChunk();
       //     timer = cooldown;
        }
    }
}
