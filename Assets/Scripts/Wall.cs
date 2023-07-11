using System;
using TMPro;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int health;

    public float blinkOnDuration;
    public float blinkOffDuration;

    public Material blinkOnMaterial;
    public Material blinkOffMaterial;

    public TextMeshPro healthDisplay;

    private int _blinksRemaining;
    private float _blinkTimestamp = float.NegativeInfinity;

    private void Update()
    {
        var renderer = GetComponent<Renderer>();
        if (_blinksRemaining > 0 && Time.time - _blinkTimestamp > blinkOnDuration + blinkOffDuration)
        {
            _blinksRemaining--;
            _blinkTimestamp = Time.time;
            renderer.material = blinkOnMaterial;
        }
        else if (Time.time - _blinkTimestamp > blinkOnDuration)
        {
            renderer.material = blinkOffMaterial;
        }
        else
        {
            renderer.material = blinkOnMaterial;
        }

        healthDisplay.text = health.ToString();
    }

    public void Damage(int amount)
    {
        health = Math.Max(health - amount, 0);
        _blinksRemaining = 5;
    }
}