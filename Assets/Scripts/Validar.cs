using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Validar : MonoBehaviour
{
    public GameObject Aprobados;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AValidar()
    {
        if (Aprobados.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text == "Alfredo Lopez")
        {
            Debug.Log("Lo logre señor?");
        }            
 
    }
}
