using System.Collections;
using UnityEngine;
using OVR;

public class Bow : MonoBehaviour
{
    public GameObject Arrow = null;

    public float Grablim = 0.15f;
    public Transform start;
    public Transform end;
    public Transform socket;
    private Transform PullingHand = null;
    private Arrow curArrow = null;
    private Animator Animator = null;

    private float pull = 0.0f;

    private void Awake()
    {
        Animator = GetComponent<Animator>();

    }

    private void Start()
    {
        StartCoroutine(CreateArrow(0.0f));
    }

    private void Update()
    {
        if (!PullingHand || !curArrow)
            return;

        pull = ComputePull(PullingHand);
        pull = Mathf.Clamp(pull, 0.0f, 1.0f);

        Animator.SetFloat("Blend", pull);
    }

    private float ComputePull(Transform pullHand)
    {
        Vector3 direction = end.position - start.position;
        float magnitude = direction.magnitude;

        direction.Normalize();
        Vector3 difference = pullHand.position - start.position;

        return Vector3.Dot(difference, direction) / magnitude;
    }

    private IEnumerator CreateArrow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject arrowObject = Instantiate(Arrow, socket);

        arrowObject.transform.localPosition = new Vector3(0, 0, 0.425f);
        arrowObject.transform.localEulerAngles = Vector3.zero;

        curArrow = arrowObject.GetComponent<Arrow>();
    }

    public void Pull(Transform hand)
    {
        float distance = Vector3.Distance(hand.position, start.position);

        if (distance > Grablim)
            return;

        PullingHand = hand;
    }

    public void Release()
    {
        if (pull > 0.25f)
            FireArrow();

        PullingHand = null;

        pull = 0.0f;
        Animator.SetFloat("Blend", 0);

        if (!curArrow)
            StartCoroutine(CreateArrow(0.25f));
    }

    private void FireArrow()
    {
        curArrow.Fired(pull);
        GetComponent<AudioSource>().Play();
        curArrow = null;
    }
}


