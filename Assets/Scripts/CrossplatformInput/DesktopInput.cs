using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopInput : IInputHandler
{
   public SelectionManager selectionManager;

   public void UpdateInput()
   {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            selectionManager.SelectObject();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectionManager.PrevObject();
        }
        if( Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectionManager.NextObject(); 
        }
   }

    public void SetSelectionManager(SelectionManager manager)
    {
        selectionManager = manager;
    }
}
