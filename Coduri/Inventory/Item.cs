using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object")]

public class Item : ScriptableObject
{

    [Header("Gameplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);



    [Header("Ui")]
    public bool stackable = true;


    [Header("Both")]
    public Sprite image;

}
public enum ItemType
{
    BuildingBlock,
    Tool
}
public enum ActionType
{
    Dig,
    Mine
}