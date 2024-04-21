using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI currentCharacterView;
    [SerializeField] private TextMeshProUGUI currentLocationView;
 
    [SerializeField] private Image sprite2D;

    public void UpdateUI(SelectableObject selectableObject)
    {
        if(selectableObject != null)
        {
            nameText.text = selectableObject.Name;
            descriptionText.text = selectableObject.Description;

            if(selectableObject is Character character)
            {
                sprite2D.sprite = character.spriteView;
                currentCharacterView.text = $"Character: {character.Name}";
            }
            if(selectableObject is Location location) 
            { 
                sprite2D.sprite = location.spriteView;
                currentLocationView.text = $"Location: {location.Name}";
            }
        }
        else
        {
            nameText.text = "no object";
            descriptionText.text = "no info";
        }
    }
}
