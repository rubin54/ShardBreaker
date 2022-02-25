using System;
using System.Collections.Generic;
using System.Numerics;

[System.Serializable]
public class SaveData
{
    public string name;
    public int ammo;
    public List<string> items;

    public Vector3 position;
    public Quaternion rotation;
}
