using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class FloatVal : ScriptableObject
{
    //the initial value of the object
    public float initialVal;

    //the value during playtime
    public float RuntimeValue;
}