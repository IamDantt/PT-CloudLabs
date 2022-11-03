using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class JsonReader : MonoBehaviour
{
    public TextAsset json;

    public GameObject Aviso, Continuar, Regresar;
    public TextMeshProUGUI aviso;
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
        ClosAviso();
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
            g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.id.ToString();
            g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.nombre.ToString();
            g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = item.apellido.ToString();
            g.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.correo.ToString();
            g.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = item.nota.ToString();

        }

        Destroy(datosTemplate);
    }


    public void CheckNote()
    {
        foreach (Datos item in myStudentList.datos)
        {
            if (g.transform.GetChild(5).GetChild(1).GetComponent<Toggle>().isOn == false && g.transform.GetChild(5).GetChild(0).GetComponent<Toggle>().isOn == false)
            {
                Aviso.SetActive(true);
                Regresar.SetActive(true);
                aviso.text = "error";
            }
            if (item.nota < 3 && g.transform.GetChild(5).GetChild(1).GetComponent<Toggle>().isOn == true)
            {
                Aviso.SetActive(true);
                Regresar.SetActive(true);
                aviso.text = "error";
            }
            else if (item.nota >= 3 && g.transform.GetChild(5).GetChild(0).GetComponent<Toggle>().isOn == true)
            {
                aviso.text = "Correcto";
                Aviso.SetActive(true);
                Continuar.SetActive(true);
            }

        }
    }

    public void ClosAviso()
    {
        Aviso.SetActive(false);
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
    
}
