using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Point {

	public int x;
	public int y;
	public Point(int x,int y){
		this.x = x;
		this.y = y;
	}
	// eq

	public bool equals(System.Object point){
		if (point == null) return false;
//		if (obj instanceof Coord)
		if(!((Point)point).Equals(null))
//		foreach(Point c in point)
		{	
			Point c = (Point)point;
			return x == c.x && y == c.y;
		}
		return false;
	}
}
