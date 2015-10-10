using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {


    public int score = 0;
    public int combo = 1;

    public int succesStrike = 0;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void Hit()
    {
        score += 100 * combo;
        succesStrike++;
        ComboManager();
    }
  public void MissEnemy()
    {
        combo = 1;
        succesStrike = 0;
    }

    public void MissPlacement()
    {
        combo = 1;
    }


   private void ComboManager()
    {
        //increase the combo score every time the player do a succes strike of 5
        if (succesStrike % 5 == 1 && combo<=5)
            combo++;
    }
}
