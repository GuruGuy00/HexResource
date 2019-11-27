using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=YBrSpruDBqY 25:32

/// <summary>
/// 
/// </summary>
public class Hex
{
    // Q + R + S = 0
    // S = -(Q + R)

    public readonly int Q; //Column
    public readonly int R; //Row
    public readonly int S; //

    static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;

    float radius = .5f;

    public Hex(int q, int r)
    {
        this.Q = q;
        this.R = r;
        this.S = -(q + r);
    }

    /// <summary>
    
    /// </summary>
    /// <returns></returns>
    public Vector3 Position()
    {

        return new Vector3(
            HexHorizontalSpacing() * (this.Q + this.R/2f),
            0,
            HexVerticalSpacing() * this.R);
    }

    public float HexHeight()
    {
        return radius * 2;
    }

    public float HexWidth()
    {
        return WIDTH_MULTIPLIER * HexHeight();
    }

    public float HexVerticalSpacing()
    {
        return HexHeight() * 0.75f;
    }

    public float HexHorizontalSpacing()
    {
        return HexWidth();
    }

    public Vector3 PositionFromCamera(Vector3 cameraPosition, float numRows, float numCols)
    {
        float mapHeight = numRows * HexVerticalSpacing();
        float mapWidth = numCols = HexHorizontalSpacing();

        Vector3 position = Position();

        float howManyWidthsFromCamera = (position.x - cameraPosition.x) / mapWidth;

        if (Mathf.Abs(howManyWidthsFromCamera) <= .5f)
        {
            return position;
        }

        if (howManyWidthsFromCamera > 0 )
        {
            howManyWidthsFromCamera += 0.5f;
        }
        else
        {
            howManyWidthsFromCamera -= 0.5f;
        }

        int howManyWidthToFix = (int)howManyWidthsFromCamera;

        position.x -= howManyWidthToFix * mapWidth;

        return position;

    }

}
