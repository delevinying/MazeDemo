using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	// Use this for initialization
	public GameObject black;
	public GameObject yellow;
	public GameObject xg;

	public  int startX;
	public  int startY;


	public int[,] mazeNum=new int[,]
	{ 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1 },
		{ 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1 },
		{ 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } 
	};

//	{
//		{1,0,1,1,1,1,1,1,1,1},
//		{1,0,0,1,0,0,0,0,0,1},
//		{1,1,0,1,0,1,0,1,0,1},
//		{1,0,0,0,0,1,1,1,0,1},
//		{1,0,1,1,0,0,0,1,0,1},
//		{1,0,0,1,0,1,1,1,0,1},
//		{1,1,0,0,0,1,0,0,0,1},
//		{1,0,0,1,0,1,1,0,1,1},
//		{1,1,0,0,0,0,0,0,0,1},
//		{1,1,1,1,1,1,1,1,0,1}
//	}; 

	void Start () {
		for (int x = 0; x < 7; x++)
		{
			for (int y = 0; y < 15; y++)
			{
				if (mazeNum [x, y] == 1) {
					Instantiate (black, new Vector3 (startX + 2*(x - 1), startY + 2*(y - 1), 0), Quaternion.identity);
				} else if(mazeNum [x,y] == 0){
					Instantiate (yellow, new Vector3 (startX + 2*(x - 1), startY + 2*(y - 1), 0), Quaternion.identity);
				}
			}
		}
		Debug.Log ("run     runDemo");
		RunDemo runDemo = new RunDemo (mazeNum,15,7,1,5,10,5);
			//(maps,15,7,new Node(1, 5), new Node(10, 5));
			//new RunDemo (mazeNum,10,10,0,1,9,9);
//		int [,] newArray 
		mazeNum = runDemo.getNewArray();
		drawPath ();
	}

	private void drawPath(){
		for (int x = 0; x < 7; x++)
		{
			for (int y = 0; y < 15; y++)
			{
				if (mazeNum [x, y] == 2) {
					Instantiate (xg, new Vector3 (startX + 2*(x - 1), startY + 2*(y - 1), 0), Quaternion.identity);
				} 
			}
		}
	}
	
	// Update is called once per frame
	bool isFrist = true;
	void Update () {
//		if (isFrist) {
//			Debug.Log ("run     runDemo");
//
//			isFrist = false;
//		}
//
//
	}


}
