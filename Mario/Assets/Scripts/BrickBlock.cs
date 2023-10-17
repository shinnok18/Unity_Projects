using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : MonoBehaviour
{
    public float bounceHeight = 0.5f;
    public float bounceSpeed = 4f;
    public GameObject brokenBlockPrefab;
    public Sprite emptyBlockSprite;
    private bool canBounce = true;
    private Vector2 originalPosition;
    private bool isBroken = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    

    void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
        AudioController.instance.PlayMusic(4);
    }

    public void BreakBlock()
    {
        if (!isBroken)
        {
            isBroken = true;

            Instantiate(brokenBlockPrefab, transform.position, Quaternion.identity);
            ChangeSprite();

            if (canBounce)
            {
                canBounce = false;
                StartCoroutine(Bounce());
            }
        }
    }

    IEnumerator Bounce()
    {
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y >= originalPosition.y + bounceHeight)
                break;
            yield return null;
        }

        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y <= originalPosition.y)
            {
                transform.localPosition = originalPosition;
                break;
            }
            yield return null;
        }
    }
}
