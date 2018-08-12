using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {

	// variables
	[Header("Sprawnable Objects Prefabs")]
	public GameObject castlePrefab;
	public GameObject housePrefab;
	public GameObject wellPrefab;
	public GameObject toiletPrefab;
	public GameObject stablePrefab;
	public GameObject treePrefab;
	public GameObject towerPrefab;
	public GameObject rockPrefab;
	public GameObject plashPrefab;
	public GameObject bonfirePrefab;
	public GameObject justguyPrefab;
	public GameObject llamaPrefab;

	[Header("Map Generate Transforms")]
	public Transform objects;
	public Transform elements;

	float sizeX = 12f, sizeY = 8f;

	// generate map functions
	public bool Generate() {
		int temp;
		float x = 0, newX, y = 0, newY;

		// START GENERATE

		// generate plash 3-6
		temp = Random.Range(3, 7);
		for(int i = 0; i < temp; i++) {
			newX = SetX(Random.RandomRange(-sizeX, sizeX));
			newY = SetY(Random.RandomRange(-sizeY, sizeY));
			GameObject plash = Instantiate(plashPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
			plash.transform.SetParent(objects);
		}

		// generate trees 15-25
		temp = Random.Range(15, 26);
		for(int i = 0; i < temp; i++) {
			newX = SetX(Random.RandomRange(-sizeX, sizeX));
			newY = SetY(Random.RandomRange(-sizeY, sizeY));
			GameObject tree = Instantiate(treePrefab, new Vector3(newX, newY, 0), Quaternion.identity);
			tree.transform.SetParent(objects);
		}

		// generate rocks 5-15
		temp = Random.Range(5, 16);
		for(int i = 0; i < temp; i++) {
			newX = SetX(Random.RandomRange(-sizeX, sizeX));
			newY = SetY(Random.RandomRange(-sizeY, sizeY));
			GameObject rock = Instantiate(rockPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
			rock.transform.SetParent(objects);
		}

		// generate castles 3-4 with houses etc
		temp = Random.Range(3, 5);
		for(int i = 0; i < temp; i++) {
			switch(i) {
				case 0:
					x = Random.Range(-sizeX + 2, -2);
					y = Random.Range(-sizeY + 2, -2);
					break;
				case 1:
					x = Random.Range(2, sizeX - 2);
					y = Random.Range(-sizeY + 2, -2);
					break;
				case 2:
					x = Random.Range(-sizeX + 2, -2);
					y = Random.Range(2, sizeY - 2);
					break;
				case 3:
					x = Random.Range(2, sizeX - 2);
					y = Random.Range(2, sizeY - 2);
					break;
				}
			
			// castle prefab
			GameObject castle = Instantiate(castlePrefab, new Vector3(x, y, 0), Quaternion.identity);
			castle.transform.SetParent(objects);

			// generate houses 1-3
			int houses = Random.Range(1,4);
			for(int j = 0; j < houses; j++) {
				newX = SetX(Random.onUnitSphere.x*4f + x);
				newY = SetY(Random.onUnitSphere.y*4f + y);
				GameObject house = Instantiate(housePrefab, new Vector3(newX, newY, 0), Quaternion.identity);
				house.transform.SetParent(objects);
			}

			// generate well
			newX = SetX(Random.onUnitSphere.x*2f + x);
			newY = SetY(Random.onUnitSphere.y*2f + y);
			GameObject well = Instantiate(wellPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
			well.transform.SetParent(objects);

			// generate stable 
			if(Random.Range(0.0f, 1.1f) <= 0.7f) {
				newX = SetX(Random.onUnitSphere.x*6f + x);
				newY = SetY(Random.onUnitSphere.y*6f + y);
				GameObject stable = Instantiate(stablePrefab, new Vector3(newX, newY, 0), Quaternion.identity);
				stable.transform.SetParent(objects);
			}

		} // end of castle generate

		// generate toilet 4-6
		temp = Random.Range(4, 7);
		for(int i = 0; i < temp; i++) {
			newX = SetX(Random.RandomRange(-sizeX, sizeX));
			newY = SetY(Random.RandomRange(-sizeY, sizeY));
			GameObject toilet = Instantiate(toiletPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
			toilet.transform.SetParent(objects);
		}

		// generate bonfire 1-5
		temp = Random.Range(1, 6);
		for(int i = 0; i < temp; i++) {
			newX = SetX(Random.RandomRange(-sizeX, sizeX));
			newY = SetY(Random.RandomRange(-sizeY, sizeY));
			GameObject bonfire = Instantiate(bonfirePrefab, new Vector3(newX, newY, 0), Quaternion.identity);
			bonfire.transform.SetParent(objects);
		}

		// generate tower 1-3
		temp = Random.Range(1, 4);
		for(int i = 0; i < temp; i++) {
			newX = SetX(Random.RandomRange(-sizeX, sizeX));
			newY = SetY(Random.RandomRange(-sizeY, sizeY));
			GameObject tower = Instantiate(towerPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
			tower.transform.SetParent(objects);
		}

		// generate llamas 1-3
		temp = Random.Range(1, 4);
		for(int i = 0; i < temp; i++) {
			newX = SetX(Random.RandomRange(-sizeX, sizeX));
			newY = SetY(Random.RandomRange(-sizeY, sizeY));
			GameObject llama = Instantiate(llamaPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
			llama.transform.SetParent(objects);
		}

		// generate epic just guy 1
		newX = SetX(Random.RandomRange(-sizeX, sizeX));
		newY = SetY(Random.RandomRange(-sizeY, sizeY));
		GameObject justguy = Instantiate(justguyPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
		justguy.transform.SetParent(objects);


		// map generated

		return true;
	}


	float SetX(float x) {
		if(x > sizeX) x = sizeX;
		else if(x < -sizeX) x = -sizeX;
		return x;
	}
	float SetY(float y) {
		if(y > sizeY) y = sizeY;
		else if(y < -sizeY) y = -sizeY;
		return y;
	}
}
