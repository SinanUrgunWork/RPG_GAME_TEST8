using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public GameObject thisEnemy;
    private bool outlineOn = false;
    private AnimatorStateInfo enemyInfo;
    private NavMeshAgent nav;
    private Animator anim;
    private float x, z, velocitySpeed;
    public GameObject player;
    private float distance;
    private bool isAttacking = false;
    public float attackRange = 2.0f;
    public float runRange = 12.0f;
    public int enemyHealth = 100;
    private int currentHealth;
    private bool isAlive = true;
    public Image healtBar;
    private float fillHealth;
    public GameObject cam;
    public float rotateSpeed = 50.0f;
    public GameObject coins;




    // Start is called before the first frame update
    void Start()
    {
        thisEnemy.GetComponent<Outline>().enabled = false;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.avoidancePriority = Random.Range(5, 75);
        currentHealth = enemyHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (cam == null)
        {
            cam = GameObject.Find("Main Camera");
        }

        healtBar.transform.LookAt(cam.transform.position);
        if (isAlive == true)
        {


            if (outlineOn == false)
            {
                outlineOn = true;
                if (SaveScript.theTarget == thisEnemy)
                {
                    thisEnemy.GetComponent<Outline>().enabled = true;
                }
            }
            if (outlineOn == true)
            {
                if (SaveScript.theTarget != thisEnemy)
                {
                    thisEnemy.GetComponent<Outline>().enabled = false;
                    outlineOn = false;
                }
            }
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            x = nav.velocity.x;
            z = nav.velocity.z;
            velocitySpeed = x + z;
            if (velocitySpeed == 0)
            {
                anim.SetBool("running", false);
            }
            else
            {
                anim.SetBool("running", true);
                isAttacking = false;
            }
            enemyInfo = anim.GetCurrentAnimatorStateInfo(0);
            distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < attackRange || distance > runRange)
            {
                nav.isStopped = true;
                if (distance < attackRange && enemyInfo.IsTag("nonAttack") && !anim.IsInTransition(0))
                {
                    if (isAttacking == false)
                    {
                        isAttacking = true;
                        anim.SetTrigger("attack");
                        Vector3 Pos = (player.transform.position - transform.position).normalized;
                        Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                        transform.rotation = Quaternion.Slerp(transform.rotation, PosRotation, Time.deltaTime * rotateSpeed);//spherical linear interpoation

                    }
                }
                if (distance < attackRange && enemyInfo.IsTag("attack"))
                {
                    if (isAttacking == true)
                    {
                        isAttacking = false;
                    }
                }
            }
            else if (distance > attackRange && enemyInfo.IsTag("nonAttack") && !anim.IsInTransition(0))
            {
                nav.isStopped = false;
                nav.destination = player.transform.position;
            }
            if (currentHealth > enemyHealth)
            {
                anim.SetTrigger("hit");
                currentHealth = enemyHealth;
                fillHealth = enemyHealth;
                fillHealth /= 100.0f;
                healtBar.fillAmount = fillHealth;
            }
        }
        if (enemyHealth <= 1 && isAlive == true)
        {
            isAlive = false;
            nav.isStopped = true;
            anim.SetTrigger("death");
            SaveScript.enemiesOnScreen--;
            thisEnemy.GetComponent<Outline>().enabled = false;
            outlineOn = false;
            nav.avoidancePriority = 1;
            StartCoroutine(IsDeath());
        }
    }
    IEnumerator IsDeath()
    {
        yield return new WaitForSeconds(1);
        Instantiate(coins, transform.position, transform.rotation);
        SaveScript.killAmt++;
        Destroy(gameObject, 0.2f);
    }

}
