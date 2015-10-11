using UnityEngine;
using System.Collections;

public class EnemyID : MonoBehaviour {

    public string input;
    private System.Random random;
    public Material[] mat;
    public int EnemyType;
    // Use this for initialization
    void Start () {
        random = new System.Random();
        EnemyType = random.Next(1, 5);
        //generate a random input to kill it
        input = "Fire"+ EnemyType;//+ random.Next(0,4);
        GetComponent<Renderer>().material = mat[EnemyType-1];

	
	}
	
	// Update is called once per frame
	void Update () {
        float offsetbeat = GetComponent<SimpleMoveEnemy>().audioSys.debugvalue;
        offsetbeat *= 2.0f;
        GetComponent<Renderer>().material.color = mat[EnemyType - 1].color + new Color(offsetbeat, offsetbeat, offsetbeat, 0.0f);
    }
}
