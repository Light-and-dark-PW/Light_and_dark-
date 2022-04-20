using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Startbutton : MonoBehaviour
{
    private GameObject police;
    private GameObject thief;
    private GameObject introduce;

    public GameObject introduceimg;
    public Button close;
    // Start is called before the first frame update 
    void Start()
    {
        Button buttonpolice = this.transform.Find("police").GetComponent<Button>();
        Button buttonthief= this.transform.Find("thief").GetComponent<Button>();
        Button buttonintroduce = this.transform.Find("introduce").GetComponent<Button>();


        buttonpolice.onClick.AddListener(() => SceneManager.LoadScene("light¡ªXiangyu Wang"));
        buttonthief.onClick.AddListener(() => SceneManager.LoadScene("dark¡ªPeiwen Zuo"));
        buttonintroduce.onClick.AddListener(introduceEnve);

        close.onClick.AddListener(() => introduceimg.SetActive(false));
    }

    public void introduceEnve()
    {
        introduceimg.SetActive(true);
    }


}
