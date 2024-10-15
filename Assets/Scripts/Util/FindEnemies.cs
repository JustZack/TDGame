using System;
using UnityEngine;

class FindEnemies {
    public static GameObject Nearest(Vector3 comparedTo, float maxDistance = Mathf.Infinity) {
        return Find.NearestWithTag(comparedTo, Tags.Enemy, maxDistance);
    }
}