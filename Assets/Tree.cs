using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private void Start()
    {
        int ran = Random.Range(25, 35);
        transform.localScale = new Vector2(ran, ran);
    }
}
