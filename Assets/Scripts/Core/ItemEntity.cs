using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemEntity
{
    public CargoType cargoType;
    public int quantity;
    public int cost;

    public enum CargoType
    {
        testA,
        testB,
    }
}
