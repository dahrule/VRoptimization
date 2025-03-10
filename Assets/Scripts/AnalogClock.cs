using UnityEngine;
using System;

/// <summary>
/// TODO: Try to optimize such that it does not use Update
/// </summary>

[RequireComponent (typeof(AudioSource))]
public class AnalogClockWithTick : MonoBehaviour
{
    [SerializeField] Transform hourHandPivot;
    [SerializeField] Transform minuteHandPivot;
    [SerializeField] Transform secondHandPivot;
    [SerializeField] AudioClip tickSound;
    private int previousSecond;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource=GetComponent<AudioSource>();
    }

    void Start()
    {
        previousSecond = -1; // Initialize to an invalid value
    }

    void Update()
    {
        if (hourHandPivot == null || minuteHandPivot == null || secondHandPivot == null || tickSound == null)
        {
            Debug.LogError("One or more clock hand transforms or tick sound are not assigned!");
            return;
        }

        DateTime time = DateTime.Now;

        // Calculate rotations
        float hourRotation = (time.Hour % 12 + time.Minute / 60f) * 30f;
        float minuteRotation = (time.Minute + time.Second / 60f) * 6f;
        float secondRotation = time.Second * 6f;

        Debug.Log("hourRotation" + hourRotation);
        Debug.Log("minuteRotation" + minuteRotation);
        Debug.Log("secondRotation" + secondRotation);


        // Apply rotations
        hourHandPivot.localRotation = Quaternion.Euler(hourRotation,0f, 0f);
        minuteHandPivot.localRotation = Quaternion.Euler(minuteRotation, 0f, 0f);
        secondHandPivot.localRotation = Quaternion.Euler(secondRotation,0f, 0f);

        // Play tick sound every second
        if (time.Second != previousSecond)
        {
            previousSecond = time.Second;

            audioSource.clip=tickSound;
            audioSource.Play();
            //AudioSource.PlayClipAtPoint(tickSound, transform.position); // Play at the clock's position
        }
    }
}