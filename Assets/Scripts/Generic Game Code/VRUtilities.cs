using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRUtilities { 
    /**
     * @param float1  1 number you want to compare
     * @param float2  2nd number you want to compare
     * @param precision  the tolerance
     */
    public static bool AlmostEquals(float float1, float float2, float precision) {
        return (Math.Abs(float1 - float2) <= precision);
    }
}
