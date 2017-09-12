using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	// Use this for initialization
	public GameObject black;
	public GameObject yellow;

	public  int startX;
	public  int startY;

	public int[,] mazeNum=new int[,]{
		{1,0,1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1,0,1}
	}; 

	void Start () {
		for (int y = 0; y < 10; y++)
		{
			for (int x = 0; x < 10; x++)
			{
				if (mazeNum [x, y] == 0) {
					Instantiate (black, new Vector3 (startX + 2*(x - 1), startY + 2*(y - 1), 0), Quaternion.identity);
				} else {
					Instantiate (yellow, new Vector3 (startX + 2*(x - 1), startY + 2*(y - 1), 0), Quaternion.identity);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
