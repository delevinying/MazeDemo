using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Astar {

	public const int BAR = 1; // 障碍值
	public const int PATH = 2; // 路径
	public const int DIRECT_VALUE = 10; // 横竖移动代价
	public const int OBLIQUE_VALUE = 14; // 斜移动代价

	Queue<Node> openList = new Queue<Node>();
	List<Node> closeList = new List<Node>();

	public void start(MapInfo mapinfo){
		if (mapinfo == null)
			return;
		openList.Clear ();
		closeList.Clear ();
		openList.Enqueue (mapinfo.start);
		moveNodes (mapinfo);
	}

	private void moveNodes(MapInfo mapinfo){
		while (!openList.Equals (null)) {
			if (isCoordInClose(mapinfo.end.point))
			{
				drawPath(mapinfo.maps, mapinfo.end);
				break;
			}
			Debug.Log ("openList   " + openList.Count);
			Node current = openList.Dequeue ();
//			closeList.add(current);
			closeList.Add(current);
			addNeighborNodeInOpen(mapinfo,current);
		}
	}

	private void drawPath(int[,] maps,Node end){
		if (end == null || maps == null)
			return;
		Debug.Log ("总代价  " + end.G);
		while (end != null) {
			Point c = end.point;
			maps [c.y,c.x] = PATH;
			end = end.parent;
		}
	}

	private void addNeighborNodeInOpen(MapInfo mapInfo,Node current){
		int x = current.point.x;
		int y = current.point.y;
		// 左
		addNeighborNodeInOpen(mapInfo,current, x - 1, y, DIRECT_VALUE);
		// 上
		addNeighborNodeInOpen(mapInfo,current, x, y - 1, DIRECT_VALUE);
		// 右
		addNeighborNodeInOpen(mapInfo,current, x + 1, y, DIRECT_VALUE);
		// 下
		addNeighborNodeInOpen(mapInfo,current, x, y + 1, DIRECT_VALUE);
		// 左上
		addNeighborNodeInOpen(mapInfo,current, x - 1, y - 1, OBLIQUE_VALUE);
		// 右上
		addNeighborNodeInOpen(mapInfo,current, x + 1, y - 1, OBLIQUE_VALUE);
		// 右下
		addNeighborNodeInOpen(mapInfo,current, x + 1, y + 1, OBLIQUE_VALUE);
		// 左下
		addNeighborNodeInOpen(mapInfo,current, x - 1, y + 1, OBLIQUE_VALUE);
	}

	private void addNeighborNodeInOpen(MapInfo mapInfo,Node current, int x, int y, int value)
	{
		if (canAddNodeToOpen(mapInfo,x, y))
		{
			Node end=mapInfo.end;
			Point coord = new Point(x, y);
			int G = current.G + value; // 计算邻结点的G值
			Node child = findNodeInOpen(coord);
			if (child == null)
			{
				int H=calcH(end.point,coord); // 计算H值
				if(isEndNode(end.point,coord))
				{
					child=end;
					child.parent=current;
					child.G=G;
					child.H=H;
				}
				else
				{
					child = new Node(coord, current, G, H);
				}
//				openList.add(child);
				openList.Enqueue(child);
			}
			else if (child.G > G)
			{
				child.G = G;
				child.parent = current;
//				openList.add(child);
				openList.Enqueue(child);
			}
		}
	}

	private Node findNodeInOpen(Point point)
	{
		if (point == null || openList.Equals(null)) 
			return null;

		//for (Node node : openList)
		foreach(Node node in openList)
		{
			if (node.point.equals(point))
			{
				return node;
			}
		}
		return null;
	}

	private int calcH(Point end,Point coord)
	{
		return Mathf.Abs(end.x - coord.x)
			+ Mathf.Abs(end.y - coord.y);
	}

	private bool isEndNode(Point end,Point coord)
	{
		return coord != null && end.equals(coord);
	}

	private bool canAddNodeToOpen(MapInfo mapInfo,int x, int y)
	{
		// 是否在地图中
		if (x < 0 || x >= mapInfo.width || y < 0 || y >= mapInfo.hight) return false;
		// 判断是否是不可通过的结点
		if (mapInfo.maps[y,x] == BAR) return false;
		// 判断结点是否存在close表
		if (isCoordInClose(x, y)) return false;

		return true;
	}

	private bool isCoordInClose(Point coord)
	{
		return coord!=null&&isCoordInClose(coord.x, coord.y);
	}

	private bool isCoordInClose(int x, int y)
	{
		if (closeList.Equals(null)) return false;
//		for (Node node : closeList)
		foreach(Node node in closeList)
		{
			if (node.point.x == x && node.point.y == y)
			{
				return true;
			}
		}
		return false;
	}
}
