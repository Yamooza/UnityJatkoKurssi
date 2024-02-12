using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Interactable : MonoBehaviour
{
    public AudioClip onInteractClip;
    public UnityEvent InteractEvents;

    AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void OnInteract()
    {
        InteractEvents.Invoke();

        if (onInteractClip != null)
        AS.PlayOneShot(onInteractClip); //toistaa kerran audiosourcesta annetun clipin
    }
}
