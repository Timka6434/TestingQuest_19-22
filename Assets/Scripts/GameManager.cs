using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UiManager uiManager;
    public SelectionManager selectionManager;
    public IInputHandler inputHandler;

    [SerializeField] public List<Character> characterList = new List<Character>();
    [SerializeField] public List<Location> locationList = new List<Location>();

    void Start()
    {
        selectionManager = new SelectionManager();

        if (Application.isMobilePlatform)
        {
            inputHandler = new MobileInput();
        }
        else
        {
            inputHandler = new DesktopInput();
        }
        foreach (Character character in characterList)
        {
            selectionManager.AddObject(character);
        }
        inputHandler.SetSelectionManager(selectionManager);
        selectionManager.SelectionChanged += uiManager.UpdateUI;
    }

    void Update()
    {
        inputHandler.UpdateInput();
    }
    
    public void SelectNextObject()
    {
        selectionManager.NextObject();
    }

    public void SelectPreviousObject()
    {
        selectionManager.PrevObject();
    }
    public void SelectCurrentObject(int index)
    {
        selectionManager.SelectObject(index);
    }
}
