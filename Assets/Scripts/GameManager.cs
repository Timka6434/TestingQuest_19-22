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

    public enum Choises
    {
        character,
        location,
        accept
    }

    private Choises choises = Choises.character;

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

        inputHandler.SetSelectionManager(selectionManager);
        selectionManager.SelectionChanged += uiManager.UpdateUI;
    }

    void Update()
    {
        if (choises == Choises.character)
        {
            foreach (Character character in characterList)
            {
                selectionManager.AddObject(character);
            }
        }
        else
        {
            foreach (Location location in locationList)
            {
                selectionManager.AddObject(location);
            }
        }
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
    public void SelectCurrentObject()
    {
        selectionManager.Clear();
        choises = Choises.location;
    }
}
