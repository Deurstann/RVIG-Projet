using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float interval;
    private float time;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject pointTotal;
    private float targetX;
    private float targetY;
    private float targetZ;
    private float targetScale;
    void Start()
    {
        interval = Random.Range(1.2f, 2.2f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > interval)
        {
            targetX = Random.Range(-10, 10);
            targetZ = Random.Range(8, 13);
            targetY = Random.Range(2, 8);
            Instantiate(target, transform);
            target.transform.position = new Vector3(targetX,targetY,targetZ);
            targetScale = Random.Range(0.6f, 1.4f);
            target.transform.localScale = Vector3.one*targetScale;
            target.GetComponent<Target>().points = (int) Mathf.Floor(10 / targetScale);
            target.GetComponent<Target>().pointTotal = pointTotal;
            
            interval = Random.Range(1.2f, 2.2f);
            time = 0;
        }
    }
}
