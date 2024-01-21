using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tenticle : MonoBehaviour
{
    [SerializeField] int length;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Vector3[] segmentPoses;
    [SerializeField]Vector3[] segmentV;

    [SerializeField] Transform targerDir;
    [SerializeField] float targetDist;

    [SerializeField] float smoothSpeed;

    [SerializeField] float wiggleSpeed;
    [SerializeField] float wiggleMag;
    [SerializeField] Transform wiggleDir;

    void Start()
    {
        lineRenderer.positionCount = length; 
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMag);

        segmentPoses[0] = transform.position;
        for(int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targerDir.right * targetDist,ref segmentV[i], smoothSpeed);
        }
        lineRenderer.SetPositions(segmentPoses);
    }
}
