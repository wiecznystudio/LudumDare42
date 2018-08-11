using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class Item : ScriptableObject {

	public int itemID;
	public Sprite itemIcon;
	public string itemName;
	public string itemDesc;
	public float chance;

}
