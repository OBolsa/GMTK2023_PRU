using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    public static FollowPoint Instance;

    public Transform target;
    public float targetTime;
    private float counter;
    private float percentageComplete;
    private bool isCounting;

    private Vector3 startPos;
    private Vector3 endPos;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 0.3f) StartFollow();

        if (isCounting)
        {
            if (target.position != endPos)
                StartFollow();

            counter += Time.deltaTime;
            percentageComplete = counter / targetTime;

            if(percentageComplete > 1 )
            {
                isCounting = false;
            }

            transform.position = Vector3.Lerp(startPos, target.position, percentageComplete);
        }
    }

    public void SetTarget(Transform newTarget) => target = newTarget;

    public void StartFollow()
    {
        startPos = transform.position;
        endPos = target.position;
        counter = 0;
        isCounting = true;
    }
}
