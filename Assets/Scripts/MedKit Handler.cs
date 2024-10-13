using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitHennder : MonoBehaviour
{
    public ParticleSystem DestroyParticle;

    public AudioSource DestroyAudio;

    public int HealtPointCount;

    private GameManager _GameManager;

    private void Start()
    {
        _GameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyParticle.transform.parent = null;
        DestroyAudio.transform.parent= null;

        DestroyParticle.Play();
        DestroyAudio.Play();

        Destroy(gameObject);

        _GameManager.Healing(HealtPointCount);
    }
}