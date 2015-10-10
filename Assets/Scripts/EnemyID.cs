using UnityEngine;
using System.Collections;

public class EnemyID : MonoBehaviour {

    public string input;
    private System.Random random;

    // Use this for initialization
    void Start () {
        random = new System.Random();

        //generate a random input to kill it
        input = "Fire"+ random.Next(0,4);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
