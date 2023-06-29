using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public float damageAmt = 0.1f;
    private WaitForSeconds delayTime = new WaitForSeconds(1);
    private bool canAttack = true;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canAttack == true && SaveScript.invulnerable == false)
            {
                canAttack = false;
                SaveScript.playerHealth -= damageAmt;
                StartCoroutine(ResetDamage());
            }
        }
    }
    IEnumerator ResetDamage()
    {
        yield return delayTime;
        canAttack = true;
    }
}
