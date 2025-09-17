using Unity.Collections;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    [Header("=== Acceleration Settings ===")]
    [SerializeField, Range(1f, 2f)] private float boostMultiplier = 1.5f;

    [Header("=== References ===")]
    [SerializeField] private DriverMovement driverMovement;

    public void ActivateBoost() => driverMovement.SetAcceleration(driverMovement.Acceleration * boostMultiplier);

    public void DeactivateBoost() => driverMovement.ResetAcceleration();
}
