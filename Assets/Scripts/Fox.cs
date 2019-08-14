using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private Attacker attacker = null;

    public void Awake()
    {
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        /*
        if (otherObject.tag == "Gravestone")
        {
            attacker.GetComponent<Animator>().SetTrigger("JumpTrigger");
        } else */

        if (otherObject.GetComponent<Defender>())
        {
            attacker.Attack(otherObject);
        }
    }
}
