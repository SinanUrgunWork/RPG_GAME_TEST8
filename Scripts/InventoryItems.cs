using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryItems : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject inventoryScreen;
    public GameObject statsScreen;
    public GameObject characterDisplay;
    public GameObject openBook;
    public GameObject closedBook;
    public GameObject potionBook;
    public GameObject messageBox;
    public Image[] emptySlots;
    public Sprite[] icons;
    public Sprite emptyIcon;

    private GameObject playerObj;
    private Animator playerAnim;
    private float weightAmt = 1.0f;
    private bool changeWeight = false;
    private AnimatorStateInfo playerInfo;
    //
    public static int redMushroom = 0;
    public static int purpleMushroom = 0;
    public static int brownMushroom = 0;
    public static int blueFlower = 0;
    public static int redFlower = 0;
    public static int root = 0;
    public static int leafDew = 0;
    public static int dragonEgg = 0;
    public static int redPotion = 0;
    public static int bluePotion = 0;
    public static int greenPotion = 0;
    public static int purplePotion = 0;
    public static int bread = 0;
    public static int cheese = 0;
    public static int meat = 0;
    public static bool key = true;
    //
    public static int newIcon = 0;
    public static int gold = 1500;
    public static bool iconUpdate = false;
    private int max = 0;
    // skilss
    public GameObject magicParticle;
    public GameObject magicParticle2;
    public GameObject magicParticle3;
    public GameObject tornedo;
    public GameObject hurricane;
    public GameObject healMagic;
    public GameObject InvulnerabilityMagic;
    public GameObject magicBalls;
    public GameObject blueBall;
    public GameObject redBall;
    public GameObject yellowBall;
    //
    private bool blue = false;
    private bool red = false;
    private bool yellow = false;
    private string skillsCombo = "";
    public Image manaBar;
    public GameObject theCanvas;
    [HideInInspector]
    public string entry;
    public string[] items;
    [HideInInspector]
    public int currentID = 0;
    [HideInInspector]
    public int checkAmt = 0;
    private int max2;
    private int max3;
    public Image[] UISlorts;
    public Sprite[] magicIcons;
    public KeyCode[] keys;
    public bool set = false;
    [HideInInspector]
    public int selected = 0;
    public int[] magiAttack;
    public GameObject[] magicParticles;

    public bool[] weapons;
    public Image staminaBar;
    public Image healthImage;
    public GameObject testStart;


    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        potionBook.SetActive(false);
        max = emptySlots.Length;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerAnim = playerObj.GetComponent<Animator>();
        // blueBall.SetActive(false);
        //redBall.SetActive(false);
        //yellowBall.SetActive(false);
        //temp
        redMushroom = 0;
        blueFlower = 0;
        max2 = items.Length;
        max3 = emptySlots.Length;
    }

    // Update is called once per frame
    void Update()
    {
        playerInfo = playerAnim.GetCurrentAnimatorStateInfo(1);

        healthImage.fillAmount = SaveScript.playerHealth;


        if (iconUpdate == true)
        {

            for (int i = 0; i < max; i++)
            {
                if (emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[newIcon];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon;
                }
            }
            StartCoroutine(Reset());

        }
        if (set == true)
        {

            for (int i = 0; i < UISlorts.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    set = false;
                    UISlorts[i].sprite = magicIcons[selected];
                    magiAttack[i] = selected;
                    theCanvas.GetComponent<CreatePotion>().Removed(selected);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (SaveScript.manaAmt > 0.1)
            {
                if (skillsCombo == "qwe" && Time.timeScale == 1)
                {
                    Instantiate(magicParticle, SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
                    //test
                    playerAnim.SetTrigger("MagicAttak");
                    playerAnim.SetLayerWeight(1, 1);
                    weightAmt = 1;
                    //test
                }
                if (skillsCombo == "ewq" && Time.timeScale == 1)
                {
                    Instantiate(magicParticle2, SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
                }
                if (skillsCombo == "wqe" && Time.timeScale == 1)
                {
                    Instantiate(magicParticle3, SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
                }
                if (skillsCombo == "eee" && Time.timeScale == 1)
                {
                    Instantiate(tornedo, SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
                }
                if (skillsCombo == "qqq" && Time.timeScale == 1)
                {
                    Instantiate(hurricane, SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
                }
                if (skillsCombo == "www" && Time.timeScale == 1)
                {
                    Instantiate(healMagic, SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
                }
                if (skillsCombo == "eqw" && Time.timeScale == 1)
                {
                    Instantiate(InvulnerabilityMagic, SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (skillsCombo.Length > 2)
            {
                skillsCombo = "";
                //Debug.Log(skillsCombo);
                blueBall.SetActive(true);
                skillsCombo += 'q';
                //Debug.Log(skillsCombo);
                blue = true;


            }
            else if (blueBall.activeInHierarchy)
            {
                blueBall.SetActive(false);
                blue = false;
                skillsCombo += 'q';
                //Debug.Log(skillsCombo);
            }
            else
            {
                blueBall.SetActive(true);
                skillsCombo += 'q';
                //Debug.Log(skillsCombo);
                blue = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (skillsCombo.Length > 2)
            {
                skillsCombo = "";
                //Debug.Log(skillsCombo);
                redBall.SetActive(true);
                skillsCombo += 'w';
                //Debug.Log(skillsCombo);
                red = true;


            }
            else if (redBall.activeInHierarchy)
            {

                redBall.SetActive(false);
                red = false;
                skillsCombo += 'w';
                //Debug.Log(skillsCombo);
            }
            else
            {
                redBall.SetActive(true);
                skillsCombo += 'w';
                // Debug.Log(skillsCombo);
                red = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (skillsCombo.Length > 2)
            {
                skillsCombo = "";
                //Debug.Log(skillsCombo);
                yellowBall.SetActive(true);
                skillsCombo += 'e';
                //Debug.Log(skillsCombo);
                yellow = true;

            }
            else if (yellowBall.activeInHierarchy)
            {
                yellowBall.SetActive(false);
                yellow = false;
                skillsCombo += 'e';
                //Debug.Log(skillsCombo);

            }
            else
            {
                yellowBall.SetActive(true);
                skillsCombo += 'e';
                // Debug.Log(skillsCombo);
                yellow = true;
            }
        }

        if (Input.anyKey && Time.timeScale == 1)
        {
            for (int i = 0; i < UISlorts.Length; i++)
            {

                if (Input.GetKeyDown(keys[i]))
                {
                    if (UISlorts[i].sprite != emptyIcon)
                    {
                        if (SaveScript.manaAmt > 0.1f)
                        {
                            Instantiate(magicParticles[magiAttack[i]], SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
                        }
                        if (magiAttack[i] < 3 && SaveScript.manaAmt > 0.1)
                        {
                            UISlorts[i].sprite = emptyIcon;
                        }
                    }
                }
            }
        }
        if (playerInfo.IsTag("magic"))
        {
            changeWeight = true;
        }
        if (changeWeight == true)
        {
            weightAmt -= 0.4f * Time.deltaTime;
            playerAnim.SetLayerWeight(1, weightAmt);
            if (weightAmt <= 0)
            {
                changeWeight = false;
            }
        }
        manaBar.fillAmount = SaveScript.manaAmt;

        if (SaveScript.staminaAmt != staminaBar.fillAmount)
        {
            staminaBar.fillAmount = Mathf.Lerp(staminaBar.fillAmount, SaveScript.staminaAmt, 2 * Time.deltaTime);
        }
    }
    public void CheckStatics()
    {
        for (int i = 0; i < max2; i++)
        {
            if (i == currentID)
            {
                max2 = i;
                entry = items[i];
                checkAmt = System.Convert.ToInt32(typeof(InventoryItems).GetField(entry).GetValue(null));
                checkAmt--;
                typeof(InventoryItems).GetField(entry).SetValue(null, checkAmt);
                if (checkAmt == 0)
                {
                    RemoveIcon(i);
                }
            }
        }
        max2 = items.Length;
    }
    public void RemoveIcon(int iconType)
    {
        for (int i = 0; i < max3; i++)
        {
            if (emptySlots[i].sprite == icons[iconType])
            {
                max3 = i;
                emptySlots[i].sprite = icons[0];
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
            }
        }
        max3 = emptySlots.Length;
    }
    public void OpenMenu()
    {
        messageBox.SetActive(false);
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        SaveScript.theTarget = null;
        OpenInventoryScreen();
        Time.timeScale = 0;
    }
    public void CloseMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        characterDisplay.SetActive(false);
        statsScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void OpenInventoryScreen()
    {
        statsScreen.SetActive(false);
        characterDisplay.SetActive(false);
        inventoryScreen.SetActive(true);
    }
    public void OpenStatsScreen()
    {
        inventoryScreen.SetActive(false);
        statsScreen.SetActive(true);
        characterDisplay.SetActive(true);
        statsScreen.GetComponent<StatsUpdate>().updateWeapons = true;
    }
    public void OpenPotionBook()
    {
        potionBook.SetActive(true);
    }
    public void ClosePotionBook()
    {
        theCanvas.GetComponent<CreatePotion>().value = 0;
        theCanvas.GetComponent<CreatePotion>().thisValue = 0;
        potionBook.SetActive(false);


    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        iconUpdate = false;
        max = emptySlots.Length;
    }
}
