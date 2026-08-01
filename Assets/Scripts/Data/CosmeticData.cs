using UnityEngine;

public abstract class CosmeticData : ScriptableObject
{
    [Header("Identity")]
    public int id;

    public string itemName;

    [Header("Visual")]
    public Sprite previewSprite;

    [Header("Unlock")]
    public UnlockMethod unlockMethod;

    public int unlockValue;
}