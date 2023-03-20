using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public int movementSpeed = 1;
    public int rotationSpeed = 1;
    public int lowerCameraLimit = 1;
    public int uperCameraLimit = 10;
    public int lateralCameraLimit = 200;

    void FixedUpdate() {
        Transform currentTransform = transform;

        if (Input.GetButton("Fire1")) {
            Vector3 position = currentTransform.position;
            float deltaX = Input.GetAxis("Mouse X") * rotationSpeed;
            float deltaY = Input.GetAxis("Mouse Y") * rotationSpeed;
            currentTransform.RotateAround(position, Vector3.up, deltaX);
            currentTransform.RotateAround(position, currentTransform.right, -deltaY);
        }

        if (Input.GetKey(KeyCode.W)) {
            Vector3 movementDirection = Vector3.Cross(currentTransform.right, Vector3.up);
            currentTransform.position += movementDirection * movementSpeed;
        } else if (Input.GetKey(KeyCode.S)) {
            Vector3 movementDirection = Vector3.Cross(currentTransform.right, Vector3.up);
            currentTransform.position -= movementDirection * movementSpeed;
        }

        if (Input.GetKey(KeyCode.A)) {
            Vector3 movementDirection = Vector3.Cross(currentTransform.forward, Vector3.up);
            currentTransform.position += movementDirection * movementSpeed;
        } else if (Input.GetKey(KeyCode.D)) {
            Vector3 movementDirection = Vector3.Cross(currentTransform.forward, Vector3.up);
            currentTransform.position -= movementDirection * movementSpeed;
        }

        if (currentTransform.position.x > lateralCameraLimit) {
            Vector3 pos = currentTransform.position;
            pos.x = lateralCameraLimit;
            currentTransform.position = pos;
        } else if (currentTransform.position.x < -lateralCameraLimit) {
            Vector3 pos = currentTransform.position;
            pos.x = -lateralCameraLimit;
            currentTransform.position = pos;
        }

        if (currentTransform.position.z > lateralCameraLimit) {
            Vector3 pos = currentTransform.position;
            pos.z = lateralCameraLimit;
            currentTransform.position = pos;
        } else if (currentTransform.position.z < -lateralCameraLimit) {
            Vector3 pos = currentTransform.position;
            pos.z = -lateralCameraLimit;
            currentTransform.position = pos;
        }

        if (Input.GetKey(KeyCode.Q)) {
            currentTransform.Rotate(Vector3.up, -rotationSpeed);
        } else if (Input.GetKey(KeyCode.E)) {
            currentTransform.Rotate(Vector3.up, rotationSpeed);
        }

        if (Input.GetKey(KeyCode.Space) && currentTransform.position.y < uperCameraLimit) {
            currentTransform.position += Vector3.up * movementSpeed;
        } else if (Input.GetKey(KeyCode.LeftShift) && currentTransform.position.y > lowerCameraLimit) {
            currentTransform.position += Vector3.down * movementSpeed;
        }
    }
}