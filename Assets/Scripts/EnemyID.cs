using UnityEngine;
using System.Collections;

public class EnemyID : MonoBehaviour {

    public string input;
    private System.Random random;
    public Material[] mat;

    // Use this for initialization
    void Start () {
        random = new System.Random();
        int EnemyType = random.Next(1, 5);
        //generate a random input to kill it
        input = "Fire"+ EnemyType;//+ random.Next(0,4);
        GetComponent<Renderer>().material = mat[EnemyType-1];

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
