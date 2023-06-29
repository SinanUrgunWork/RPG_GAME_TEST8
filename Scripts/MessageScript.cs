using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public Text shopOwnerMessage;
    public Color32 messageOff;
    public Color32 messageOn;
    public GameObject[] shopUI;
    [HideInInspector]
    public int shopNum = 0;
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
        PlayerMove.canMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;
        PlayerMove.canMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        shopOwnerMessage.text = "Hello " + SaveScript.player + " how can i help you ?";
    }

    // Update is called once per frame
    public void Message0()
    {
        shopOwnerMessage.text = "not much going on around here.";
    }
    public void Message1()
    {
        shopOwnerMessage.text = "Select item from the list.";
        shopUI[shopNum].SetActive(true);
        shopUI[shopNum].GetComponent<BuyScript>().UpdateGold();

    }
    void Update()
    {
        if (PlayerMove.canMove == true && PlayerMove.moving == true)
        {
            if (shopUI != null)
            {
                shopUI[shopNum].SetActive(false);
            }
        }

    }
}
