using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBotGap : MonoBehaviour
{
    [SerializeField] public Transform leftTopGap;

    void OnTriggerEnter2D(Collider2D collision)
    {
        BlackHeartoKuma blackHeartoKuma = collision.GetComponent<BlackHeartoKuma>();
        HeartoKuma heartoKuma = collision.GetComponent<HeartoKuma>();

        if (blackHeartoKuma != null)
        {
            blackHeartoKuma.transform.SetPositionAndRotation(new Vector2(blackHeartoKuma.transform.position.x, leftTopGap.transform.position.y - 6f), blackHeartoKuma.transform.rotation);
        }

        if (heartoKuma != null)
        {
            heartoKuma.transform.SetPositionAndRotation(new Vector2(heartoKuma.transform.position.x, leftTopGap.transform.position.y - 6f), heartoKuma.transform.rotation);
        }
    }
}
