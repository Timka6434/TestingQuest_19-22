using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput: IInputHandler
{
    private SelectionManager selectionManager;
    private Vector2 touchStart;
    private float minSwipeDistance = 50f;

    public void UpdateInput()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    touchStart = touch.position;
                    break;

                case TouchPhase.Ended:
                    float deltaX = touch.position.x - touchStart.x;

                    if(deltaX > minSwipeDistance )
                    {
                        selectionManager.NextObject();
                    }
                    else if( deltaX < minSwipeDistance )
                    {
                        selectionManager.PrevObject();
                    }
                    break;
            }
        }
    }

    public void SetSelectionManager(SelectionManager manager)
    {
        selectionManager = manager;
    }
}
