using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHeartoKuma : MonoBehaviour
{
    int spawnCounter = 0;
    bool freezeStatus = false;

    public void Die()
    {
        Destroy(gameObject);
    }

    public void FreezePlayer()
    {
        StartCoroutine(FreezeTimer());
    }

    IEnumerator FreezeTimer()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        if (freezeStatus == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            spawnCounter++;
            freezeStatus = true;
        }

        if (spawnCounter > 2)
        {
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(2f);

        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        freezeStatus = false;
    }

}
