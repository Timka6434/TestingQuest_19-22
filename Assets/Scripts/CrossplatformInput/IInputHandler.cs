using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputHandler
{
    void UpdateInput();
    void SetSelectionManager(SelectionManager manager);
}
