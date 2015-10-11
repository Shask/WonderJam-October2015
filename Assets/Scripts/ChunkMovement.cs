using UnityEngine;
using System.Collections;

public class ChunkMovement : MonoBehaviour {

    public float ChunkSpeed = 3.0f;
    public float ChunkNormalSpeed = 3.0f;


   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        ChunkSpeed = gameObject.GetComponentInParent<ChunkSpawner>().CurrentMusicSpeed + ChunkNormalSpeed;

        float y = ChunkSpeed * Time.deltaTime;
        Vector3 NewPos = transform.position;
        NewPos.y += y;
        transform.position = NewPos;

        if (transform.position.y >= 30)
        {
            Destroy(gameObject);
        }
    }
   
}
