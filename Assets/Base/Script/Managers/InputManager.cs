using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    public Vector2 fingerUp;
    public Vector2 fingerDown;
    public float SWIPE_THRESHOLD = 20f;


    public Vector3 ClickedPosition;
    private void OnMouseDown()
    {
        //OnMouseDown ve Drag, Atandiklari cismin uzerine tiklanip tiklanmadigini kontrol eder
    }

    private void OnMouseDrag()
    {
        // Drag & Drop Action
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("Dragging with an object with Collider");
        }
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Evrensel olarak mouseye basilmis mi
            ClickedPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Debug.Log("Tap Action with X:" + ClickedPosition.x + ", Y:" + ClickedPosition.y);
        }

        // Swipe Action Detection
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            // Detects swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                fingerDown = touch.position;
                checkSwipe();
            }

            // Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }

    public void checkSwipe()
    {
        // Check if Vertical Swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0) // Up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0) //Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0) // Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0) // Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        // No Movement At all
        else
        {
            Debug.Log("No Swipe");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    public void OnSwipeUp()
    {
        Debug.Log("Swipe Up");
    }

    public void OnSwipeDown()
    {
        Debug.Log("Swipe Down");

    }

    public void OnSwipeRight()
    {
        Debug.Log("Swipe Right");

    }

    public void OnSwipeLeft()
    {
        Debug.Log("Swipe Left");

    }
}
