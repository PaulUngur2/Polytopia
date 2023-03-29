using UnityEngine;

public class CameraLook : MonoBehaviour {
    public int mouseSensitivity = 1;
    void FixedUpdate() {
        Transform currentTransform = transform;
        
        if (Input.GetButton("Fire1")) {
            Vector3 position = currentTransform.position;
            float deltaX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float deltaY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            currentTransform.RotateAround(position, Vector3.up, deltaX);
            currentTransform.RotateAround(position, currentTransform.right, -deltaY);
        }
    }
}