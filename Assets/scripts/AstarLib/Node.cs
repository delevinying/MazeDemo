using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node{
	public Point point;
	public Node parent;
	public int G;
	public int H;
	public Node(int x,int y){
		this.point = new Point (x, y);
	}

	public Node(Point point,Node parent,int g,int h){
		this.point = point;
		this.parent = parent;
		G = g;
		H = h;
	}

	public int compareTo(Node o){
		if (o == null) return -1;
		if (G + H > o.G + o.H)
			return 1;
		else if (G + H < o.G + o.H) return -1;
		return 0;
	}
}
