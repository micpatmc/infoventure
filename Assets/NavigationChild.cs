using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationChild : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject player;
    public Transform target;

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        transform.position = player.transform.position;
    }
    private void Update()
    {
        rb.velocity = Vector2.MoveTowards(player.transform.position, target.position, speed);

    }
}
