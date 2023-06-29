using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonParicle : MonoBehaviour
{
    public float speed = 1.0f;
    public float damageAmt = 0.1f;
    public GameObject parentObj;
    // Start is called before t1he first frame update
    void Start()
    {
        Invoke("DestroyParticle", 4);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveScript.playerHealth -= damageAmt;
            Destroy(parentObj.gameObject);
        }
    }
    void DestroyParticle()
    {
        Destroy(parentObj.gameObject);
    }
}
