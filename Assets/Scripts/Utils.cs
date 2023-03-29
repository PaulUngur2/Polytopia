using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 CastRay(Camera camera, Plane plane) {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Vector3 hitPoint = new Vector3(0, -10, 0);

        if (plane.Raycast(ray, out var enter)) {
            hitPoint = ray.GetPoint(enter);
            hitPoint.y += 1;
        }

        return hitPoint;
    }
}
