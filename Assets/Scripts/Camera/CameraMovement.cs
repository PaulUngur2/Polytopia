using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int movementSpeed = 1;
    public int rotationSpeed = 1;
    public int lowerCameraLimit = 1;
    public int upperCameraLimit = 10;
    public int lateralCameraLimit = 200;

    void FixedUpdate()
    {
        Transform currentTransform = transform;

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 movementDirection = Vector3.Cross(currentTransform.right, Vector3.up);
            currentTransform.position += movementDirection * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 movementDirection = Vector3.Cross(currentTransform.right, Vector3.up);
            currentTransform.position -= movementDirection * movementSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movementDirection = Vector3.Cross(currentTransform.forward, Vector3.up);
            currentTransform.position += movementDirection * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 movementDirection = Vector3.Cross(currentTransform.forward, Vector3.up);
            currentTransform.position -= movementDirection * movementSpeed;
        }

        if (currentTransform.position.x > lateralCameraLimit)
        {
            Vector3 pos = currentTransform.position;
            pos.x = lateralCameraLimit;
            currentTransform.position = pos;
        }
        else if (currentTransform.position.x < -lateralCameraLimit)
        {
            Vector3 pos = currentTransform.position;
            pos.x = -lateralCameraLimit;
            currentTransform.position = pos;
        }

        if (currentTransform.position.z > lateralCameraLimit)
        {
            Vector3 pos = currentTransform.position;
            pos.z = lateralCameraLimit;
            currentTransform.position = pos;
        }
        else if (currentTransform.position.z < -lateralCameraLimit)
        {
            Vector3 pos = currentTransform.position;
            pos.z = -lateralCameraLimit;
            currentTransform.position = pos;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            currentTransform.Rotate(Vector3.up, -rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            currentTransform.Rotate(Vector3.up, rotationSpeed);
        }

        if (Input.GetKey(KeyCode.Space) && currentTransform.position.y < upperCameraLimit)
        {
            currentTransform.position += Vector3.up * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && currentTransform.position.y > lowerCameraLimit)
        {
            currentTransform.position += Vector3.down * movementSpeed;
        }
    }

    private float startTime;

    private void Update()
    {
        Transform currentTransform = transform;

        float scrollDelta = Input.mouseScrollDelta.y;
        if (scrollDelta == 0) return;

        // startTime = Time.time;
        Vector3 direction = Vector3.up + Vector3.Cross(Vector3.up, currentTransform.transform.right);

        if (!GlobalVariables.buildActive)
            if ((scrollDelta > 0 && currentTransform.position.y > lowerCameraLimit) ||
                (scrollDelta < 0 && currentTransform.position.y < upperCameraLimit))
            {
                currentTransform.Rotate(Vector3.left, 3 * scrollDelta);
                currentTransform.position -= direction * scrollDelta;
                // currentTransform.position = Vector3.Lerp(direction * scrollDelta, currentTransform.position, i);
            }
    }
}