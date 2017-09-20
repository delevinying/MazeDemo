using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDemo{
	private MapInfo info;
	private int[,] maps;
	public RunDemo(int[,] maps,int width,int heigth,int startX,int startY,int endX,int endY){
		Debug.Log ("Hello world");
		this.maps = maps;
//		int[,] maps = maps;
//		{ 
//			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//			{ 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0 },
//			{ 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
//			{ 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
//			{ 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
//			{ 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 } 
//		};
//		MapInfo info= new MapInfo(maps,15,7,new Node(1, 5), new Node(10, 5));
		info = new MapInfo(maps,width,heigth,new Node(startX,startY),new Node(endX,endY));

		//return 0;
	}

	public int[,] getNewArray(){
		new Astar().start(info);
		return printMap (maps);
	}

	string  str;
	public int[,] printMap(int[,] maps)
	{
		for (int i = 0; i < 7; i++)
		{
			str = "";
			for (int j = 0; j < 15; j++)
			{
//				System.out.print(maps[i][j] + " ");
//				Debug.Log(maps[i,j] + " ");
				str += " " + maps [i, j];
			}
			Debug.Log(str);
		}
		return maps;
	}
}
