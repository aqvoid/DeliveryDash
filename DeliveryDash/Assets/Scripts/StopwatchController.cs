using UnityEngine;

public class StopwatchController : MonoBehaviour
{
    private float elapsedTime;

    public float ElapsedTime { get => elapsedTime; private set => elapsedTime = value; }

    private void Update() => ElapsedTime += Time.deltaTime;

}
