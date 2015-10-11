using UnityEngine;
using System.Collections;

public class FloorRythm : MonoBehaviour {

    public string DangerTag ="Purple";
    private Transform[] childs;
	// Use this for initialization
	void Start () {
        childs = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            childs[i] = transform.GetChild(i);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void switchLane()
    {
        string PurTag = "Purple";
        string PinTag = "Pink";
        for (int i = 0; i < transform.childCount; i++)
        {
            if (childs[i].tag == PurTag)
            {
                childs[i].tag = PinTag;
            }
            else
            {
                childs[i].tag = PurTag;
            }
        }
    }
}
