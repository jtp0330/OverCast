using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Para : MonoBehaviour
{
    [SerializeField] private Vector2 effectMultiplier;
    [SerializeField] private bool isHorizontallyInfinite;
    [SerializeField] private bool isVerticallyInfinite;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    private float textureUnitSizeY;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(
            deltaMovement.x * effectMultiplier.x,
            deltaMovement.y * effectMultiplier.y
        );
        lastCameraPosition = cameraTransform.position;
        if (isHorizontallyInfinite)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float positionOffsetX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(
                    cameraTransform.position.x + positionOffsetX,
                    transform.position.y);
            }
        }
        if (isVerticallyInfinite)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float positionOffsetY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(
                    transform.position.x,
                    cameraTransform.position.y + positionOffsetY);
            }
        }
    }
}

