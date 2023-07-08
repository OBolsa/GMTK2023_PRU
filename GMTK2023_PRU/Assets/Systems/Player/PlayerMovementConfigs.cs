using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Movement")]
public class PlayerMovementConfigs : ScriptableObject
{
    public float maxMovementSpeed;
    public float impulseSpeed;
    public float rotationSpeed;
}