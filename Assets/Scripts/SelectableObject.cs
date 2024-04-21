using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SelectableObject
{
    public uint ID { get;  set; }
    public string Name { get; set; }
    public string Description { get; set; }


    public abstract void LoadData();
}
