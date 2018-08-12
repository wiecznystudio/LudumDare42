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
	public Color rare = new Color32(18, 47, 44, 100);
	public int score;

}
