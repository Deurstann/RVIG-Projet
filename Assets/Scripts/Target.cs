using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int points;
    [SerializeField] public GameObject pointTotal;


    void Start()
    {
        StartCoroutine(destroy());
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "target") return;
        pointTotal.GetComponent<Points>().points += points;
        Destroy(other.gameObject);
        GetComponent<AudioSource>().Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
    }
}
