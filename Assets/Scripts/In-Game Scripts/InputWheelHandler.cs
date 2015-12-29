using UnityEngine;
using System.Collections;

public class InputWheelHandler : MonoBehaviour {

    // Use this for initialization
    public GameObject[] inputWheel;
    public Transform leftEndTransform;
    public Transform rightEndTransform;
    private Vector3 mousePos;
    Camera myCam;
    private bool draging = false;
    private bool isClickLeftWheel = false;
    float angleSegment;
    float angle;
    int lastindex;
    bool isFirstRotation;

    // Use this for initialization

    void Start()
    {
        //transform.rotation = Quaternion.Euler(0, 0, 90f);
        myCam = Camera.main;
        angleSegment = 360f / inputWheel.Length;
        isFirstRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(draging)
                setActiveInput();
            draging = false;
            //Debug.Log(angle);
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.transform.tag == "Left Wheel" )
                {
                    Debug.Log(hit.transform.tag);
                    isClickLeftWheel = true;

                }
                if (hit.transform.tag == "Right Wheel")
                {
                    Debug.Log(hit.transform.tag);
                    isClickLeftWheel = false;

                }
                draging = true;
            }
        }
        rotateObject();
    }
    void rotateObject()
    {
        if (draging)    // Only do if IsDraggable == true
        {
            mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 toTarget = mousePos - transform.position;
            Vector2 toEnd;
            if(isClickLeftWheel)
                toEnd= leftEndTransform.position - transform.position;
            else
                toEnd = rightEndTransform.position - transform.position;

            // Calculate how much we should rotate to get to the target
            angle = SignedAngle(toEnd, toTarget);

            // Flip sign if character is turned around
            angle *= Mathf.Sign(transform.root.localScale.x);

            // "Slows" down the IK solving
            //angle *= damping;

            // Wanted angle for rotation
            angle = -(angle - transform.eulerAngles.z);
            if (angle >= 360.0f)
                angle = angle - 360;
            if (angle <0.0f)
                angle = angle + 360;
            transform.rotation = Quaternion.Euler(0, 0, angle);

        }
    }
    float SignedAngle(Vector3 a, Vector3 b)
    {
        float angle = Vector3.Angle(a, b);
        float sign = Mathf.Sign(Vector3.Dot(Vector3.back, Vector3.Cross(a, b)));

        return angle * sign;
    }
    void setActiveInput()
    {
        float wheelAngle = angle - 90.0f - (angleSegment/2.0f);
        if (wheelAngle < 0.0f)
            wheelAngle = wheelAngle + 360;
        wheelAngle = 360 - wheelAngle;
        int index = (int)(wheelAngle / angleSegment);
        inputWheel[index].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);

        if(lastindex!=index&&!isFirstRotation)
            inputWheel[lastindex].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        lastindex = index;
        isFirstRotation = false;
        Debug.Log(wheelAngle);
        Debug.Log(index);

    }
}
