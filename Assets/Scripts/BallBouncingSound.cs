using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class BallBoincingSound : MonoBehaviour
{
    public AudioClip impactSound;
    public float minImpactSpeed = 1f;
    public float maxImpactSpeed = 10f;
    public float maxVolume = 1f;

     //TODO: Cache rigidbody and AudioSource

    void Start()
    {

        GetComponent<AudioSource>().spatialBlend = 1f;
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = impactSound;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Surface")
        {
            Debug.Log("hit surface",this);
            float impactSpeed = GetComponent<Rigidbody>().linearVelocity.magnitude;

            if (impactSpeed >= minImpactSpeed)
            {
                float volume = Mathf.Clamp01((impactSpeed - minImpactSpeed) / (maxImpactSpeed - minImpactSpeed)) * maxVolume;

                GetComponent<AudioSource>().PlayOneShot(impactSound, volume);
            }
        }
    }
}