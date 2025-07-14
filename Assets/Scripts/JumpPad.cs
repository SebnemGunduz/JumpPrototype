using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Sprite activatedSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = activatedSprite;
        }
    }
}
