using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMover : MonoBehaviour
{
    public GameObject target;
    public GameObject obj;
    public float speed = 5;
    public float lifetime = 1.5f;
    public bool enemySeeker = false;
    public bool nonMoving = false;
    public bool falowPlayer = false;
    public bool invulnerability = false;
    public bool strength = false;
    public bool heal = false;
    private GameObject playerObj;
    private GameObject targetSave;
    public float manaCost = 0.05f;
    public int damageAmt = 30;
    public GameObject lastObj;
    // Update is called once per frame
    void Start()
    {
        targetSave = SaveScript.theTarget;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if (invulnerability == true)
        {
            SaveScript.invulnerable = true;
        }
        if (heal == true)
        {
            SaveScript.playerHealth = 1.0f;
        }
        if (strength == true)
        {
            SaveScript.strengthIncrease = 1;
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.LerpUnclamped(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        if (enemySeeker == true)
        {
            if (targetSave != null)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, targetSave.transform.position, speed * Time.deltaTime);

            }
            else
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

            }
        }
        if (nonMoving == true)
        {
            if (targetSave != null)
            {
                transform.position = targetSave.transform.position;
            }
            else
            {
                Destroy(obj);
            }
        }
        if (falowPlayer == true)
        {
            transform.position = playerObj.transform.position;
            //lifetime = 100;
            if (SaveScript.manaAmt <= 0.02)
            {
                Destroy(obj);
            }
        }
        SaveScript.manaAmt -= manaCost * Time.deltaTime;
        Destroy(obj, lifetime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("spider") && other.transform.gameObject != lastObj)
        {
            other.transform.gameObject.GetComponent<EnemyMove>().enemyHealth -= damageAmt;
            lastObj = other.transform.gameObject;
        }
        if (other.CompareTag("dragon") && other.transform.gameObject != lastObj)
        {
            other.transform.gameObject.GetComponent<DragonScript>().enemyHealth -= damageAmt;
            lastObj = other.transform.gameObject;
        }
    }
}
