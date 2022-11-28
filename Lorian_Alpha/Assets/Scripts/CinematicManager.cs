using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour
{
    public GameObject fadeFromBlack, fadeToBlack, fadeToWhite;
    public GameObject panel0, panel1, panel2, panel3,dialog1,dialog2;
    private int i;
    void Start()
    {
        if (fadeFromBlack != null)
        {
            GameObject panel = Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1.5f);
        }
    }

    void Update()
    {
        if (i > 4)
        {
            GameObject panel = Instantiate(fadeToWhite, Vector3.zero, Quaternion.identity);
            StartCoroutine(fadeToBlackCo());
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject panel = Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity);
            //StartCoroutine(fadeFromBlackCo());                
            i++;
            switch (i)
            {               
                case 1:
                    panel= Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity);
                    Destroy(panel, 1.5f); ;
                    panel0.SetActive(false);
                    panel1.SetActive(true);                   
                    break;
                case 2:
                    panel = Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity);
                    panel1.SetActive(false);
                    panel2.SetActive(true);                    
                    break;
                case 3:
                    panel = Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity);
                    panel2.SetActive(false);
                    panel3.SetActive(true);                   
                    break;
                case 4:
                    dialog1.SetActive(false);
                    dialog2.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
    private IEnumerator fadeToBlackCo()
    {
        yield return new WaitForSeconds(2);
    }
                
}
