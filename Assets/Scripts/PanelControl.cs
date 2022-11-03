using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    public GameObject PanelOne, PanelTow;
    // Start is called before the first frame update
    void Start()
    {
        panelOne();
    }

    public void panelOne()
    {
        PanelOne.SetActive(true);
        PanelTow.SetActive(false);
    }
    public void panelTwo()
    {
        PanelOne.SetActive(false);
        PanelTow.SetActive(true);
    }


}
