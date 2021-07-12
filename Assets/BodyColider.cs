using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        BlackHeartoKuma blackHeartoKuma = collision.GetComponent<BlackHeartoKuma>();
    }
}
