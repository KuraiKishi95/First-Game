using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKumaCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        HeartoKuma blackHeartoKuma = collision.GetComponent<HeartoKuma>();
    }
}
