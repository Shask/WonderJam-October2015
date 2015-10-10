using UnityEngine;
using System.Collections;

public class MovementCtrl : MonoBehaviour {
    public float stepSize = 2.5f;
    public float moveTime = 1;
    public short lane = 4;
    public float centerOffset = 0.5f;
    public string movementOrientation = "Horizontal";

    public float CooldownTimeBetweenLaneSwitch = 0.2f;
    private float CDMove = 0.0f;

    // Use this for initialization
    void Start () {

    }
	
	void Update ()
    {
        if (CDMove >= 0.0f)
            CDMove -= Time.deltaTime;

        float stepX = movementOrientation == "Horizontal" ? stepSize: 0;
        float stepY = movementOrientation == "Vertical" ? stepSize : 0;
        if (Input.GetAxis(movementOrientation) == -1 && checkBound("negative") && CDMove <= 0.0f)
        {
            Vector3 end = new Vector3(gameObject.transform.position.x - stepX, gameObject.transform.position.y - stepY, gameObject.transform.position.z);
            MoveObjects(gameObject.transform.position, end);
            gameObject.transform.position = end;
            CDMove = CooldownTimeBetweenLaneSwitch;
        }
        if (Input.GetAxis(movementOrientation) == 1 && checkBound("positive") && CDMove <= 0.0f)
        {
            Vector3 end = new Vector3(gameObject.transform.position.x + stepX, gameObject.transform.position.y + stepY, gameObject.transform.position.z);
            MoveObjects(gameObject.transform.position, end);
            gameObject.transform.position = end;
            CDMove = CooldownTimeBetweenLaneSwitch;
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
        float pos = movementOrientation == "Horizontal" ? gameObject.transform.position.x : gameObject.transform.position.y;
        if (side == "negative")
        {
            if (pos <= -max + centerOffset / 2)
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
            if (pos >= max + centerOffset / 2)
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
