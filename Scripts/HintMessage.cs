using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HintMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject hintBox;
    public Text message;
    public int objectType = 0;

    private Vector3 screenPoint;
    public GameObject theCanvas;
    private bool displaying = true;
    private bool overIcon = false;

    public Sprite CursorBasic;
    public Sprite CursorHand;
    public Image CursorImage;

    public GameObject inventoryObject;
    public bool magic = false;
    public bool left = true;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        overIcon = true;
        if (displaying == true)
        {
            CursorImage.sprite = CursorHand;
            hintBox.SetActive(true);
            if (left == true)
            {
                screenPoint.x = Input.mousePosition.x + 400;
            }
            if (left == false)
            {
                screenPoint.x = Input.mousePosition.x - 400;
            }
            screenPoint.y = Input.mousePosition.y;
            screenPoint.z = 1f;
            hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            MessageDisplay();
        }

    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        CursorImage.sprite = CursorBasic;
        overIcon = false;
        hintBox.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        hintBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (overIcon == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                displaying = false;
                hintBox.SetActive(false);
                if (magic == true)
                {
                    inventoryObject.GetComponent<InventoryItems>().selected = objectType - 20;
                    inventoryObject.GetComponent<InventoryItems>().set = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            displaying = true;
        }
    }
    void MessageDisplay()
    {
        if (objectType == 0)
        {
            message.text = "empty";
        }
        if (objectType == 1)
        {
            message.text = InventoryItems.redMushroom.ToString() + " Red Mushrooms to be used in potions";
        }
        if (objectType == 2)
        {
            message.text = InventoryItems.purpleMushroom.ToString() + " purple Mushrooms to be used in potions";
        }
        if (objectType == 3)
        {
            message.text = InventoryItems.brownMushroom.ToString() + " Brown Mushrooms to be used in potions";
        }
        if (objectType == 4)
        {
            message.text = InventoryItems.blueFlower.ToString() + " Blue Flowers to be used in potions";
        }
        if (objectType == 5)
        {
            message.text = InventoryItems.redFlower.ToString() + " red Flower to be used in potions";
        }
        if (objectType == 6)
        {
            message.text = InventoryItems.root.ToString() + " Root to be used in potions";
        }
        if (objectType == 7)
        {
            message.text = InventoryItems.leafDew.ToString() + " leafDew to be used in potions";
        }
        if (objectType == 8)
        {
            message.text = InventoryItems.key.ToString() + " Key to be used open chests";
        }
        if (objectType == 9)
        {
            message.text = InventoryItems.dragonEgg.ToString() + " Dragon egg to be used in potions";
        }
        if (objectType == 10)
        {
            message.text = InventoryItems.bluePotion.ToString() + " Blue potion to be used in potions";
        }
        if (objectType == 11)
        {
            message.text = InventoryItems.purplePotion.ToString() + " purple Potion to be used in potions";
        }
        if (objectType == 12)
        {
            message.text = InventoryItems.greenPotion.ToString() + " green Potion to be used in potions";
        }
        if (objectType == 13)
        {
            message.text = InventoryItems.redPotion.ToString() + " Red Potion to be used in potions";
        }

        if (objectType == 14)
        {
            message.text = InventoryItems.bread.ToString() + " bread eat it ";
        }
        if (objectType == 15)
        {
            message.text = InventoryItems.cheese.ToString() + " cheese eat it";
        }
        if (objectType == 16)
        {
            message.text = InventoryItems.meat.ToString() + " PROTEIN";
        }
        if (objectType == 20)
        {
            message.text = " Explosive fire attack";
        }
        if (objectType == 21)
        {
            message.text = " Self healing";
        }
        if (objectType == 22)
        {
            message.text = " I forget it";
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        theCanvas.GetComponent<CreatePotion>().thisValue = objectType;
        theCanvas.GetComponent<CreatePotion>().UpdateValue();
    }
}
