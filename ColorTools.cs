using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorTools 
{
    public static Color whiteTransparent = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    public static Color whiteOpaque = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    public static Color blackTransparent = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    public static Color blackOpaque = new Color(0.0f, 0.0f, 0.0f, 1.0f);

    public static Color alphaMask = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
    public static Color colorMask = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);

    public static Color GetSemiTransparentWhite(float alpha)
    {
        return whiteTransparent + alphaMask * alpha;
    }

    public static Color SetColorAlpha(Color col, float alpha)
    {
        return col * colorMask + alphaMask * alpha;
    }
}
