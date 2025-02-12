using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public bool isActive;

    [SerializeField]
    protected PowerupStats duration;

    public float GetDuration()
    {
        return duration.GetValue();
    }
}
