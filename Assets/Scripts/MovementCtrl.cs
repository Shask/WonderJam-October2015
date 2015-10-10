using UnityEngine;
using System.Collections;

public class MovementCtrl : MonoBehaviour {
    public float stepSize = 2.5f;
    public float moveTime = 0.2f;
    public short lane = 4;
    public float centerOffset = 0.5f;
    public string movementOrientation = "Horizontal";
    public float jumpHeight = 0.2f;
    private float i = 0;
    private Vector3 animationEndPos, animationStartPos;
    private short moveDirection = 0;

    public float CooldownTimeBetweenLaneSwitch = 0.2f;
    private float CDMove = 0.0f;

    // Use this for initialization
    void Start () {

    }
	
	void FixedUpdate ()
    {
        if (CDMove >= 0.0f)
            CDMove -= Time.deltaTime;

        float stepX = movementOrientation == "Horizontal" ? stepSize: 0;
        float stepY = movementOrientation == "Vertical" ? stepSize : 0;
        if (moveDirection == 0)
        {
            animationStartPos = gameObject.transform.position;
            if (Input.GetAxis(movementOrientation) < -0.2f && checkBound("negative") && CDMove <= 0.0f)
            {
                moveDirection = -1;
                animationEndPos = new Vector3(gameObject.transform.position.x - stepX, gameObject.transform.position.y - stepY, gameObject.transform.position.z);
                MoveObjects(animationStartPos, animationEndPos);
                //CDMove = CooldownTimeBetweenLaneSwitch;
            }
            if (Input.GetAxis(movementOrientation) > 0.2f && checkBound("positive") && CDMove <= 0.0f)
            {
                moveDirection = 1;
                animationEndPos = new Vector3(gameObject.transform.position.x + stepX, gameObject.transform.position.y + stepY, gameObject.transform.position.z);
                MoveObjects(animationStartPos, animationEndPos);
                //CDMove = CooldownTimeBetweenLaneSwitch;
            }
        }
        else
        {
            if (i >= 1)
            {
                i = 0;
                moveDirection = 0;
                gameObject.transform.position = animationEndPos;
                //CDMove = CooldownTimeBetweenLaneSwitch;
            }
            else
            {
                MoveObjects(animationStartPos, animationEndPos);
                //CDMove = CooldownTimeBetweenLaneSwitch;
            }
        }
    }

    void MoveObjects(Vector3 startPos, Vector3 endPos)
    {
        float rate = 1 / moveTime;
        Vector3 midPos = new Vector3((startPos.x + endPos.x) / 2, jumpHeight + (startPos.y + endPos.y) / 2, 0);
        if (i < 0.5f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Slerp(startPos, midPos, i);print("up");print(Time.time);
        }
        else if (i < 1)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Slerp(startPos, endPos, Mathf.SmoothStep(0, 1, i));print("down");
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
