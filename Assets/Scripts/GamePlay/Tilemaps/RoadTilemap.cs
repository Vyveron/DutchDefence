using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class RoadTilemap : MonoBehaviour
{
    public static Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }
}
