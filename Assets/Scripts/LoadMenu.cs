using UnityEngine;
using System.Collections;

public class LoadMenu : MonoBehaviour {

	void Update ()
    {
	    if (Input.GetButtonDown("Menu"))
        {
            Application.LoadLevel(0);
        }
	}
    void Start()
    {
        if(MenuCtrl.FinalDifficulty!= "Tutoriel")
        {
            GameObject[] TutoUI = GameObject.FindGameObjectsWithTag("TutoUI");
            foreach(GameObject go in TutoUI)
            {
                go.SetActive(false);
            }
        }
    }
}
