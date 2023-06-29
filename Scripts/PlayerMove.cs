using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent nav;
    private Ray ray;
    private RaycastHit hit;
    private Animator anim;
    private float x;
    private float z;
    private float velocitySpeed;

    CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    private Vector3 pos;
    public Vector3 currPos;
    public static bool canMove = true;
    public static bool moving = false;
    public GameObject spawnPoint;
    private WaitForSeconds approachEnemy = new WaitForSeconds(0.3f);
    public GameObject freeCam;
    public GameObject staticCam;
    private bool freeCamActive = true;
    public GameObject[] weapons;
    public string[] attacks;
    private AnimatorStateInfo playerInfo;
    private GameObject trailObj;
    private WaitForSeconds trailOffTime = new WaitForSeconds(0.1f);
    public float[] staminaCost;
    private float currentHealth;
    public GameObject hitEffect;
    private WaitForSeconds hitOff = new WaitForSeconds(0.5f);

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = SaveScript.playerHealth;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currPos = ct.m_FollowOffset;
        SaveScript.spawnPoint = spawnPoint;
        freeCam.SetActive(true);
        staticCam.SetActive(false);
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        hitEffect.SetActive(false);

    }
    public GameObject GetStartPoint()
    {
        return spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {   //listen to animator
        playerInfo = anim.GetCurrentAnimatorStateInfo(0);
        //calculate valocitySpeed
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;

        //Get mouse position
        pos = Input.mousePosition;
        ct.m_FollowOffset = currPos;

        //Switch on correct weapon
        if (SaveScript.weaponChange == true)
        {
            SaveScript.weaponChange = false;
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }
            weapons[SaveScript.weaponChoice].SetActive(true);

            StartCoroutine(TurnOffTrail());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (SaveScript.carryingWeapon == true && SaveScript.staminaAmt > 0.2)
            {
                anim.SetTrigger(attacks[SaveScript.weaponChoice]);
                SaveScript.staminaAmt -= staminaCost[SaveScript.weaponChoice];
            }
        }

        if (Input.GetMouseButtonDown(0) && playerInfo.IsTag("nonAttack") && !anim.IsInTransition(0))
        {
            if (canMove == true)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.CompareTag("enemy"))
                    {
                        nav.isStopped = false;
                        SaveScript.theTarget = hit.transform.gameObject;
                        nav.destination = hit.point;
                        transform.LookAt(SaveScript.theTarget.transform);
                        StartCoroutine(MoveTo());
                    }
                    else
                    {
                        SaveScript.theTarget = null;
                        nav.destination = hit.point;
                        nav.isStopped = false;
                    }

                }
            }

        }

        if (velocitySpeed != 0)
        {
            if (SaveScript.carryingWeapon == false)
            {
                anim.SetBool("Sprinting", true);
                anim.SetBool("carryWeapon", false);
            }
            if (SaveScript.carryingWeapon == true)
            {
                anim.SetBool("Sprinting", true);
                anim.SetBool("carryWeapon", true);
            }
            moving = true;
        }
        if (velocitySpeed == 0)
        {
            anim.SetBool("Sprinting", false);
            moving = false;
        }

        if (Input.GetMouseButton(1))
        {
            if (pos.x != 0 || pos.y != 0)
            {
                currPos = pos / 200;
            }
        }

        IEnumerator MoveTo()
        {
            yield return approachEnemy;
            nav.isStopped = true;
        }
        IEnumerator TurnOffTrail()
        {
            yield return trailOffTime;
            trailObj = GameObject.Find("Trail");
            trailObj.GetComponent<Renderer>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (freeCamActive == true)
            {
                freeCam.SetActive(false);
                staticCam.SetActive(true);
                freeCamActive = false;
            }
            else if (freeCamActive == false)
            {
                freeCam.SetActive(true);
                staticCam.SetActive(false);
                freeCamActive = true;
            }
        }
        if (SaveScript.playerHealth <= 0.0f)
        {
            SceneManager.LoadScene("GameOver");
            SaveScript.playerHealth = 1.0f;
        }
        if (currentHealth > SaveScript.playerHealth)
        {
            hitEffect.SetActive(true);
            currentHealth = SaveScript.playerHealth;
            StartCoroutine(hitEffectOff());
        }

    }
    public void TrailOn()
    {
        trailObj.GetComponent<Renderer>().enabled = true;
    }
    public void TrailOff()
    {
        trailObj.GetComponent<Renderer>().enabled = false;
    }
    IEnumerator hitEffectOff()
    {
        yield return hitOff;
        hitEffect.SetActive(false);
    }

}
