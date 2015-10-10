using UnityEngine;
using System.Collections;

public class MovementCtrl : MonoBehaviour {
    private float stepSize = 2;
    private float moveTime = 1;
    private short lane = 4;


    // Use this for initialization
    void Start () {
    }
	
	void Update ()
    {
        if (Input.GetKeyDown("a") && checkBound("left"))
        {
            Vector3 end = new Vector3(gameObject.transform.position.x - stepSize, 0, 0);
            MoveObjects(gameObject.transform.position, end);
            gameObject.transform.position = end;
        }
        if (Input.GetKeyDown("d") && checkBound("right"))
        {
            Vector3 end = new Vector3(gameObject.transform.position.x + stepSize, 0, 0);
            MoveObjects(gameObject.transform.position, end);
            gameObject.transform.position = end;
        }
    }

    void MoveObjects(Vector3 startPos, Vector3 endPos)
    {
        float i = 0, rate = 1 / moveTime;
        while (i < 1)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, i));
        }
    }

    bool checkBound(string side)
    {
        float max = stepSize * (lane - 1) / 2;
        if (side == "left")
        {
            if (gameObject.transform.position.x <= - max)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            if (gameObject.transform.position.x >= max)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
