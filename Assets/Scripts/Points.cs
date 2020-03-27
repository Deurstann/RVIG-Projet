using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    // Start is called before the first frame update
    public float points = 0;
    private float fpoints = 0;
    private bool switc=true;
    public float time = 90;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject retry;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        GetComponent<Text>().text = "Vous avez " + points.ToString() + " points!\n\nTemps Restant: "+((int) time).ToString();
        if (time <= 0)
        {
            if (switc)
            {
                fpoints = points;
                switc = false;
            }
            GetComponent<Text>().text = "Félicitation, votre score est de " + fpoints.ToString() + "points!";
            spawner.GetComponent<TargetSpawner>().enabled = false;
            retry.SetActive(true);
        }
    }
}
