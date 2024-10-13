using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    private PlayerController _PlayerController;
    private GameManager _GameManager;

    private float fallStartY;
    private float fallDistanceThreshold = 4; 
    private float fallDamageMultiplier = 2.5f; 

    private bool isFalling = false;

    private void Start()
    {
        _PlayerController = GetComponentInParent<PlayerController>();
        _GameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        CheckFalling();
    }

    private void CheckFalling()
    {
        if (!_PlayerController.IsGrounded && !isFalling)
        {
            fallStartY = transform.position.y;
            isFalling = true;
        }
        else if (_PlayerController.IsGrounded && isFalling)
        {
            float fallEndY = transform.position.y;
            float fallDistance = fallStartY - fallEndY;

            if (fallDistance > fallDistanceThreshold)
            {
                int fallDamage = Mathf.RoundToInt(fallDistance * fallDamageMultiplier);
                ApplyFallDamage(fallDamage);
            }

            isFalling = false;
        }
    }

    private void ApplyFallDamage(int damage)
    {
        _GameManager.TakeDamage(damage);  
        Debug.Log("Урон от падения: " + damage);
    }
}