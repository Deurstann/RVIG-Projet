using System.Collections;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    private float speed = 1000f;
    private bool stopped = true;
    private Rigidbody RB;
    private Transform pointe;
    private Vector3 prev_Position;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void StopArrow()
    {
        stopped = true;
        RB.isKinematic = true;
        RB.useGravity = false;
    }

    private void FixedUpdate()
    {
        if (stopped) return;
        RB.MoveRotation(Quaternion.LookRotation(RB.velocity,transform.up));

        if (Physics.Linecast(prev_Position, pointe.position))
        {
            StopArrow();
        }

        prev_Position = pointe.position;
    }

    public void Fired(float pull)
    {
        StartCoroutine(destroy());
        transform.parent = null;
        stopped = false;
        RB.isKinematic = false;
        RB.useGravity = true;
        RB.AddForce(transform.forward*speed*pull);
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }
}
