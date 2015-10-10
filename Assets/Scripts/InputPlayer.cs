using UnityEngine;
using System.Collections;

public class InputPlayer : MonoBehaviour {

    private BoxCollider RangeBox;
    private ArrayList EnemyOnRange;
    // Use this for initialization

    private ScoreManager scoreManager;
	void Start () {

        RangeBox = GetComponent<BoxCollider>();
        EnemyOnRange = new ArrayList();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire4"))
        {
            if(EnemyOnRange.Count == 0)
            {
                scoreManager.MissEnemy();
            }
            else
            {
                //First enemy in the array would be the closest
                GameObject enemy = (GameObject)EnemyOnRange[0];
                EnemyID enemyID= enemy.GetComponent<EnemyID>();
                
                if(Input.GetButtonDown(enemyID.input))
                {
                    //bon input
                }
                else
                {
                    //mauvaise input
                }
            }
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            EnemyOnRange.Add(collision.gameObject); 
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyOnRange.Remove(collision.gameObject);
        }
    }

}
