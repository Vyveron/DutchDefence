using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static GameObject inHand;


    public static void Give(GameObject gm)
    {
        inHand = gm;
    }

    private void Update()
    {
        if (inHand != null && (Vector2)inHand.transform.position != RoundedMousePosiiton.position)
        {
            RefreshPosition();
        }
    }
    private void RefreshPosition()
    {
        inHand.transform.position = RoundedMousePosiiton.position;
    }
}
