using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEditor.SceneManagement;

public class SelectionManager
{
    private List<SelectableObject> selectableObjects = new List<SelectableObject>();
    private SelectableObject currentSelection;
    private int currentIndex = 0;

    public event Action<SelectableObject> SelectionChanged;

    private void SelectObject(int index)
    {
        currentSelection = selectableObjects[index];
        currentSelection.LoadData();
        SelectionChanged?.Invoke(currentSelection);
    }

    public void AddObject(SelectableObject selectedObject)
    {
        selectableObjects.Add(selectedObject);
    }
    public void SelectObject(int? id = null)
    {
        if (id == null)
        {
            NextObject();
        }
        else
        {
            var objectToSelect = selectableObjects.FirstOrDefault(obj => obj.ID == id);
            if (objectToSelect != null)
            {
                SelectObject(selectableObjects.IndexOf(objectToSelect));
            }
            else
            {
                Debug.Log($"Object with ID {id} not found");
            }
        }
    }

    public void NextObject()
    {
        if (selectableObjects.Count == 0) return;
        currentIndex = (currentIndex + 1) % selectableObjects.Count;
        SelectObject(currentIndex); 
    }

    public void PrevObject()
    {
        if (selectableObjects.Count == 0) return;
        currentIndex = (currentIndex - 1 + selectableObjects.Count) % selectableObjects.Count;
        SelectObject(currentIndex); 
    }

    public void Clear()
    {
        selectableObjects.Clear(); 
        currentSelection = null;
        currentIndex = 0; 
    }
    public SelectableObject GetCurrentSelection()
    {
        return currentSelection; 
    }
}

