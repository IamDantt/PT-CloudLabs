using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class JsonForDragDrop : MonoBehaviour
{
    public TextAsset json;
    public GameObject Aprobados, Reprobados, Padre, MesgCor, MesgInco, MesgEstado;
    public TextMeshProUGUI Mesg;
    public bool estado_Aprobado = false;

    [System.Serializable]
    public class Datos
    {
        public int id;
        public string nombre;
        public string apellido;
        public string correo;
        public float nota;
    }

    [System.Serializable]
    public class StudentList
    {
        public Datos[] datos;
    }

    public StudentList myStudentList = new StudentList();

    void Start()
    {
        MesgEstado.SetActive(false);
        MesgCor.SetActive(false);
        MesgInco.SetActive(false);
        myStudentList = JsonUtility.FromJson<StudentList>(json.text);
        LoadData();
    }
    public GameObject g;
    public void LoadData()
    {
        GameObject datosTemplate = transform.GetChild(0).gameObject;

        foreach (Datos item in myStudentList.datos)
        {
            g = Instantiate(datosTemplate, transform);
            g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.nombre.ToString() + " " + item.apellido.ToString();
            g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.nota.ToString();

        }

        Destroy(datosTemplate);
    }

    public void PAValidar()
    {
        if (Padre.transform.childCount == 0)
        {
            float nota = 3;
            foreach (Datos item in myStudentList.datos)
            {
                if (Aprobados.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text == item.nota.ToString() && item.nota <  nota)
                {
                    ResINCorecta();
                    Debug.Log("Aprovados estan incorrectos");
                    
                }
                else
                {
                    if (Aprobados.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text == item.nota.ToString() && item.nota >= nota)
                    {
                        ResCorecta();
                        Debug.Log("Aprobados estan correctos");
                    }
                }
                if (Reprobados.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text == item.nota.ToString() && item.nota >  nota)
                {
                    ResINCorecta();
                    Debug.Log("Reprovados estan incorrectos");
                }
                else
                {
                    if (Reprobados.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text == item.nota.ToString() && item.nota < nota)
                    {
                        ResCorecta();
                        Debug.Log("Reprovados estan correctos");
                    }
                }
            }
        }
        else
        {           
            mesgEstado();
        }

    }
    public void mesgEstado()
    {
        MesgEstado.SetActive(true);
        MesgCor.SetActive(false);
        MesgInco.SetActive(false);
    }
    public void ResCorecta()
    {
        MesgCor.SetActive(true);
        MesgInco.SetActive(false);
        MesgEstado.SetActive(false);
    }
    public void ResINCorecta()
    {
        MesgCor.SetActive(false);
        MesgInco.SetActive(true);
        MesgEstado.SetActive(false);
    }

}
