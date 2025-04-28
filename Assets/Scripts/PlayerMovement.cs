using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
