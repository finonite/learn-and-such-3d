using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Route", menuName = "ScriptableObjects/Waypoint", order = 1)]
public class Route2PointSO : ScriptableObject
{
    public Vector3 pointA;
    public Vector3 pointB;
}
