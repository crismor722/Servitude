using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, -4);
    public float smooth = 10f;
    void LateUpdate()
    {
        Vector3 targetPos = player.position + player.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);

        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
