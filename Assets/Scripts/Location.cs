using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Location : SelectableObject
{
    [SerializeField] private uint _sceneID;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;

    public Sprite spriteView
    {
        get { return _sprite; }
    }

    public override void LoadData()
    {
        ID = _sceneID;
        Description = _description;
    }

    public void Accept(Scene scene)
    {

    }
}
