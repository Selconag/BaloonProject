using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BaloonTypes { Colorless, Blue, Green }

[CreateAssetMenu(fileName = "New Baloon", menuName = "Entities/Balloon", order = 1)]
public class BaloonProperties : ScriptableObject
{
    [Tooltip("Defines how much score the balloon gives when the balloon is popped.")]
    public int Score = 1;
    [Range(0, 10f)]
    [Tooltip("Defines the upward speed of the balloon type.")]
    public float VerticalSpeed = 1.0f;
    public Material Material;
    public BaloonTypes BaloonType;

}
