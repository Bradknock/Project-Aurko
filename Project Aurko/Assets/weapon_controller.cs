using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_controller : MonoBehaviour
{
    public GameObject Sword; // "GameObject" should be lowercase
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (CanAttack)
            {
                SwordAttack();
            }
        }
    }

    public void SwordAttack()
    {
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("attack"); // "SetTrigger" should be capitalized
        StartCoroutine(ResetAttackCooldown()); // "StartCoroutine" should be capitalized
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown); // "yield" and "WaitForSeconds" should be capitalized
        CanAttack = true;
    }
}
