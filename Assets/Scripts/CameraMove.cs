using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Texture2D CursorTexture;
    public Transform Player;
    public Vector3 offset;
    public float Min_x, Max_x, Min_y, Max_y;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(CursorTexture, new Vector2(CursorTexture.width / 2, CursorTexture.height / 2), CursorMode.ForceSoftware);
    }
    void FixedUpdate()
    {
        if (EnemySpawner.BossMode)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(3f, 0f, -18f), 0.125f);
        }
        else
        {
            if (Player != null)
            {
                transform.position = Vector3.Lerp(new Vector3(Mathf.Clamp(transform.position.x, Min_x, Max_x),
                    Mathf.Clamp(transform.position.y, Min_y, Max_y), transform.position.z), Player.position + offset, 0.08f);
            }
        }
    }
}
