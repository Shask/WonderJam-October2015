using UnityEngine;
using System.Collections;

public class MovementCtrl : MonoBehaviour {
    private float stepSize = 2.5f;
    private float moveTime = 1;
    private short lane = 4;


    // Use this for initialization
    void Start () {
    }
	
	void Update ()
    {
        if (Input.GetAxis("Horizontal")==-1 && checkBound("left"))
        {
            Vector3 end = new Vector3(gameObject.transform.position.x - stepSize, gameObject.transform.position.y, gameObject.transform.position.z);
            MoveObjects(gameObject.transform.position, end);
            gameObject.transform.position = end;
        }
        if (Input.GetAxis("Horizontal") == 1 && checkBound("right"))
        {
            Vector3 end = new Vector3(gameObject.transform.position.x + stepSize, gameObject.transform.position.y, gameObject.transform.position.z);
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
