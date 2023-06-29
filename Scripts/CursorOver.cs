using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (Time.timeScale == 1)
        {
            PlayerMove.canMove = false;
        }

    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (Time.timeScale == 1)
        {
            PlayerMove.canMove = true;
        }

    }


}
