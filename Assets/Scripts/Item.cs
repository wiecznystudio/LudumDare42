using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class Item : ScriptableObject {

	public Sprite itemIcon;
	public string itemName;
	public string itemDesc;

}
