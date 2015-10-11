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
}
