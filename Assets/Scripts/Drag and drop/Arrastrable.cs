using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Arrastrable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform pointofreturn = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        pointofreturn = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(pointofreturn);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
