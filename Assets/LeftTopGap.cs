using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTopGap : MonoBehaviour
{
    [SerializeField] public Transform leftBotGap;
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        BlackHeartoKuma blackHeartoKuma = collision.GetComponent<BlackHeartoKuma>();
        HeartoKuma heartoKuma = collision.GetComponent<HeartoKuma>();

        if (blackHeartoKuma != null)
        {
            blackHeartoKuma.transform.SetPositionAndRotation(new Vector2(blackHeartoKuma.transform.position.x, leftBotGap.transform.position.y + 5f), blackHeartoKuma.transform.rotation);
        }

        if (heartoKuma != null)
        {
            heartoKuma.transform.SetPositionAndRotation(new Vector2(heartoKuma.transform.position.x, leftBotGap.transform.position.y + 5f), heartoKuma.transform.rotation);
        }
    }
}
