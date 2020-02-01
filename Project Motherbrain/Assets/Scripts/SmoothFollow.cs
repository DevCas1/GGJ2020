using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] 
    private Transform TrackTransform;
    [SerializeField]
    private float LerpSpeed = 5;
    
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, TrackTransform.position, /*1 - Mathf.Exp(-*/LerpSpeed * Time.deltaTime/*)*/);
        //transform.rotation = TrackTransform.rotation;
    }

    public void SetTrackTransform(ref Transform newTrackTransform)
    {
        TrackTransform = newTrackTransform;
    }
}
