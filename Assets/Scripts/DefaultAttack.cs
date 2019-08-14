using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttack : MonoBehaviour
{
    private Attacker attacker = null;

    public void Awake()
    {
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if(otherObject.GetComponent<Defender>())
        {
            attacker.Attack(otherObject);
        }
    }
}
