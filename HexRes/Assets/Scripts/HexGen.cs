using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.redblobgames.com/grids/hexagons/#basics
//https://catlikecoding.com/unity/tutorials/hex-map/part-1/
//https://github.com/quill18/MostlyCivilizedHexEngine/commits/master

public class HexGen : MonoBehaviour
{
	public int width = 6;
	public int height = 2;

	public HexCell cellPrefab;

	HexCell[] cells;

	void Awake()
	{
		cells = new HexCell[height * width];

		for (int z = 0, i = 0; z < height; z++)
		{
			for (int x = 0; x < width; x++)
			{
				CreateCell(x, z, i);
			}
		}
	}

	private void CreateCell(int x, int z, int i)
	{
		Vector3 position;
		position.x = (float)Mathf.Sin((60*Mathf.PI)/180) * x; //width
		position.y = 0f;
		position.z = z *.5f; //height

		//Debug.Log((float)Mathf.Sin((60 * Mathf.PI) / 180));

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;

	}
}
