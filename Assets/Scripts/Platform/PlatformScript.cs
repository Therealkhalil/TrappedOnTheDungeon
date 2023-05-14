using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private float offset_Y = 5.5f;
    [SerializeField] private float platformSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        platformSpeed = Random.RandomRange(5.5F, 7.2F);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * platformSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
