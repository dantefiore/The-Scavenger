using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class VectorVal : ScriptableObject
{
    //the initial value of the object
    public Vector3 initialVal;

    //teh value of the object during playthrough
    public Vector3 defaultVal;
}