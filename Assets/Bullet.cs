using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public const float L_BOARDER = -50.76f;
    public const float R_BOARDER = 71.96f;

    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        if (transform.position.x <= L_BOARDER)
        {
            transform.SetPositionAndRotation(new Vector2(transform.position.x + 122.72f, transform.position.y), Quaternion.identity);
        }

        if (transform.position.x >= R_BOARDER)
        {
            transform.SetPositionAndRotation(new Vector2(transform.position.x - 122.72f, transform.position.y), Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        BlackHeartoKuma blackHeartoKuma  = collision.GetComponent<BlackHeartoKuma>();
        HeartoKuma heartoKuma = collision.GetComponent<HeartoKuma>();

        if (blackHeartoKuma != null)
        {
            blackHeartoKuma.FreezePlayer();
        }

        Destroy(gameObject);

        if (heartoKuma != null)
        {
            heartoKuma.FreezePlayer();
        }
    }
}
