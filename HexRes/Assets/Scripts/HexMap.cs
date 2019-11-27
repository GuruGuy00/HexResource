using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{

    public GameObject HexPrefab;
    public Material[] HexMaterials;

    int numRows = 20;
    int numCols = 40;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int column = 0; column < numCols; column++)
        {
            for (int row = 0; row < numRows; row++)
            {

                Hex h = new Hex(column, row);

                //Instantiate Hex
                GameObject hexGO = (GameObject)Instantiate(
                    HexPrefab,
                    h.Position(),
                    Quaternion.identity,
                    this.transform);

                //Vector3 pos = h.PositionFromCamera(
                //    Camera.main.transform.position,
                //    numRows,
                //    numCols
                //);


                //GameObject hexGO = (GameObject)Instantiate(
                //    HexPrefab,
                //    pos,
                //    Quaternion.identity,
                //    this.transform
                //);

                MeshRenderer mr = hexGO.GetComponentInChildren<MeshRenderer>();
                mr.material = HexMaterials[Random.Range(0, HexMaterials.Length)];
            }
        }

    }

}
