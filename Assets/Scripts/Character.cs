using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Character : SelectableObject
{
    [SerializeField] private uint _id;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;

    public Sprite spriteView
    {
        get { return _sprite; }
    }

    public override void LoadData()
    {
        ID = _id;
        Name = _name;
        Description = _description;
    }
}
