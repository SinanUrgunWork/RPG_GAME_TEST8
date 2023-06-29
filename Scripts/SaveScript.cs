using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class SaveScript : MonoBehaviour
{
    public static int pchar = 0;
    public static string player = "player";
    public static GameObject spawnPoint;
    public static GameObject theTarget;
    public static float staminaAmt = 1.0f;
    public static float manaAmt = 1.0f;
    public static float strengthAmt = 0.1f;
    public static bool invulnerable = false;
    public static float manaPowerAmt = 0.1f;
    public static float staminaPowerAmt = 0.1f;
    public static int killAmt = 0;
    public static int weaponChoice = 0;
    public static bool weaponChange = false;
    public static bool carryingWeapon = false;
    private int checkAmt = 1;
    public static float playerLevel = 0.1f;
    public static int weaponIncrease;
    public static float playerHealth = 1.0f;
    public static int strengthIncrease = 0;
    public static int enemiesOnScreen;

    public static bool saving = false;
    public static bool continueData = false;
    private bool checkForLoad = false;
    private GameObject inventoryObj;

    // public saves
    public int pcharS;
    public string pnameS;
    public float strengthAmtS;
    public float manaPowerAmtS;
    public float staminaPowerAmtS;
    public int killAmtS;
    public int weaponChoiceS;
    public bool carryingWeaponS;
    public int armorS;
    public float playerLevelS;
    public int weaponIncreaseS;
    public float playerHealthS;
    public int strengthIncreaseS;
    public float armorValueS;
    public int goldS;
    public bool keyS;
    public int redMushroomsS;
    public int purpleMushroomsS;
    public int brownMushroomsS;
    public int blueFlowersS;
    public int redFlowersS;
    public int rootsS;
    public int leafDewS;
    public int dragonEggS;
    public int redPotionS;
    public int bluePotionS;
    public int greenPotionS;
    public int purplePotionS;
    public int breadS;
    public int cheeseS;
    public int meatS;
    public bool magicCollectedS;
    public bool spellsCollectedS;
    public bool[] weaponS;
    public int[] objectTypeS;



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if (continueData == true)
        {
            string fileLocation = Application.persistentDataPath + "/save.dat";
            StreamReader reader = new StreamReader(fileLocation);
            string saveData = reader.ReadToEnd();
            reader.Close();
            JsonUtility.FromJsonOverwrite(saveData, this);

            pchar = pcharS;
            continueData = false;
            checkForLoad = true;
        }

    }
    void Update()
    {
        if (manaAmt < 1.0f)
        {
            manaAmt += (manaPowerAmt / 10 + 0.1f) * Time.deltaTime;
        }
        if (manaAmt <= 0)
        {
            manaAmt += 0;
        }
        if (staminaAmt < 1.0f)
        {
            staminaAmt += (staminaPowerAmt / 10 + 0.1f) * Time.deltaTime;
        }
        if (staminaAmt <= 0)
        {
            staminaAmt += 0;
        }
        if (manaAmt < 0.03)
        {
            invulnerable = false;
            strengthIncrease = 0;
        }

        if (killAmt == checkAmt)
        {
            playerLevel += 0.1f;
            checkAmt = killAmt + 2;
            staminaPowerAmt = playerLevel;
            manaPowerAmt = playerLevel;
            strengthAmt = playerLevel;
            weaponIncrease = System.Convert.ToInt32(strengthAmt * 90);
        }
        if (saving == true)
        {
            saving = false;
            if (inventoryObj == null)
            {
                inventoryObj = GameObject.Find("InventoryCanvas");
            }
            pcharS = pchar;
            //pnameS = pname;
            strengthAmtS = strengthAmt;
            manaPowerAmtS = manaPowerAmt;
            staminaPowerAmtS = staminaPowerAmt;
            killAmtS = killAmt;
            weaponChoiceS = weaponChoice;
            carryingWeaponS = carryingWeapon;
            //armorS = armor;
            playerLevelS = playerLevel;
            weaponIncreaseS = weaponIncrease;
            playerHealthS = playerHealth;
            strengthIncreaseS = strengthIncrease;
            //armorValueS = armorValue;
            goldS = InventoryItems.gold;
            keyS = InventoryItems.key;
            redMushroomsS = InventoryItems.redMushroom;
            purpleMushroomsS = InventoryItems.purpleMushroom;
            brownMushroomsS = InventoryItems.brownMushroom;
            blueFlowersS = InventoryItems.blueFlower;
            redFlowersS = InventoryItems.redFlower;
            rootsS = InventoryItems.root;
            leafDewS = InventoryItems.leafDew;
            dragonEggS = InventoryItems.dragonEgg;
            redPotionS = InventoryItems.redPotion;
            bluePotionS = InventoryItems.bluePotion;
            greenPotionS = InventoryItems.greenPotion;
            purplePotionS = InventoryItems.purplePotion;
            breadS = InventoryItems.bread;
            cheeseS = InventoryItems.cheese;
            meatS = InventoryItems.meat;
            weaponS = inventoryObj.GetComponent<InventoryItems>().weapons;
            for (int i = 0; i < 16; i++)
            {
                objectTypeS[i] = inventoryObj.GetComponent<InventoryItems>().emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType;
            }
            string saveData = JsonUtility.ToJson(this);
            string fileLocation = Application.persistentDataPath + "/save.dat";
            StreamWriter writer = new StreamWriter(fileLocation);
            writer.WriteLine(saveData);
            writer.Close();
        }
        if (checkForLoad == true)
        {
            int sceneNumber = SceneManager.GetActiveScene().buildIndex;
            if (sceneNumber == 1)
            {
                if (inventoryObj == null)
                {
                    inventoryObj = GameObject.Find("InventoryCanvas");
                }
                if (inventoryObj != null)
                {
                    pcharS = pchar;
                    //pnameS = pname;
                    strengthAmtS = strengthAmt;
                    manaPowerAmtS = manaPowerAmt;
                    staminaPowerAmtS = staminaPowerAmt;
                    killAmtS = killAmt;
                    weaponChoiceS = weaponChoice;
                    carryingWeaponS = carryingWeapon;
                    //armorS = armor;
                    playerLevelS = playerLevel;
                    weaponIncreaseS = weaponIncrease;
                    playerHealthS = playerHealth;
                    strengthIncreaseS = strengthIncrease;
                    //armorValueS = armorValue;
                    goldS = InventoryItems.gold;
                    keyS = InventoryItems.key;
                    redMushroomsS = InventoryItems.redMushroom;
                    purpleMushroomsS = InventoryItems.purpleMushroom;
                    brownMushroomsS = InventoryItems.brownMushroom;
                    blueFlowersS = InventoryItems.blueFlower;
                    redFlowersS = InventoryItems.redFlower;
                    rootsS = InventoryItems.root;
                    leafDewS = InventoryItems.leafDew;
                    dragonEggS = InventoryItems.dragonEgg;
                    redPotionS = InventoryItems.redPotion;
                    bluePotionS = InventoryItems.bluePotion;
                    greenPotionS = InventoryItems.greenPotion;
                    purplePotionS = InventoryItems.purplePotion;
                    breadS = InventoryItems.bread;
                    cheeseS = InventoryItems.cheese;
                    meatS = InventoryItems.meat;

                    inventoryObj.GetComponent<InventoryItems>().weapons = weaponS;
                    if (carryingWeapon == true)
                    {
                        weaponChange = true;
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        inventoryObj.GetComponent<InventoryItems>().emptySlots[i].sprite = inventoryObj.GetComponent<InventoryItems>().icons[objectTypeS[i]];
                        inventoryObj.GetComponent<InventoryItems>().emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = objectTypeS[i];
                    }
                    checkForLoad = false;
                }
            }
        }

    }
}
