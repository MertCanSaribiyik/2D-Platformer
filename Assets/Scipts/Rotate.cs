using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 2f;

    private void Update() {
        transform.Rotate(0f, 0f, 360 * rotateSpeed * Time.deltaTime);
    }
}
