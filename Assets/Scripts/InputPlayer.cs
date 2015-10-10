using UnityEngine;
using System.Collections;

public class InputPlayer : MonoBehaviour {

    private BoxCollider RangeBox;
    private ArrayList EnemyOnRange;
    // Use this for initialization

    private ScoreManager scoreManager;

    public float CDShoot = 0.2f; //CoolDown between every fire input
    private float TimerShoot = 0.0f; //current timer between fire input


	void Start () {

       

        RangeBox = GetComponent<BoxCollider>();
        EnemyOnRange = new ArrayList();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {

        if (TimerShoot >= 0.0f)
            TimerShoot -= Time.deltaTime;

        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire4")) && TimerShoot<=0.0f)
        {
            TimerShoot = CDShoot;
            if (EnemyOnRange.Count == 0)
            {
                scoreManager.MissEnemy();
                Debug.Log("No enemy on range");
            }
            else
            {
                //First enemy in the array would be the closest
                GameObject enemy = (GameObject)EnemyOnRange[0];
                EnemyID enemyID= enemy.GetComponent<EnemyID>();
                
                if(Input.GetButtonDown(enemyID.input))
                {
                    //bon input
                    enemy.GetComponent<SimpleMoveEnemy>().DestroyedByPlayer();
                   // Debug.Log("Enemy hit");
                    EnemyOnRange.RemoveAt(0);
                }
                else
                {
                    enemy.GetComponent<SimpleMoveEnemy>().DestroyByBadinput();
                  //  Debug.Log("Wrong input");
                    EnemyOnRange.RemoveAt(0);
                    //mauvaise input
                }
            }
        }
	}

    void OnTriggerEnter(Collider collision)
    {
       // Debug.Log("Coucou");
        if(collision.gameObject.tag =="Enemy")
        {
            EnemyOnRange.Add(collision.gameObject); 
        }
    }
    void OnTriggerExit(Collider collision)
    {
       // Debug.Log("Goodbye");
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyOnRange.Remove(collision.gameObject);
        }
    }

}
