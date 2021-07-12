using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        HeartoKuma heartoKuma = collision.GetComponent<HeartoKuma>();

        if (heartoKuma != null)
        {
            Destroy(gameObject);
        }

    }
}
