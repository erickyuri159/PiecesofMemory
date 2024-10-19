using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public int pieceID;
    public Sprite pieceSprite; // Adicione um campo para o sprite
    public bool isHeld = false;
    private Transform player;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = pieceSprite;
        spriteRenderer.sortingOrder = 2; // Certifique-se que o sprite fica acima do slot
    }

    void Update()
    {
        if (isHeld && player != null)
        {
            transform.position = player.position;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            isHeld = !isHeld;
            if (isHeld)
            {
                player = other.transform;
                ShowSlot(true);
            }
            else
            {
                player = null;
                ShowSlot(false);
            }
        }
    }

    private void ShowSlot(bool show)
    {
        // Encontra o slot correto baseado no identificador e mostra/esconde o slot
        PuzzleSlot[] slots = FindObjectsOfType<PuzzleSlot>();
        foreach (PuzzleSlot slot in slots)
        {
            if (slot.slotID == pieceID)
            {
                slot.ShowSlot(show);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PuzzleSlot"))
        {
            PuzzleSlot slot = other.GetComponent<PuzzleSlot>();
            if (slot != null && slot.slotID == pieceID && !isHeld)
            {
                slot.OccupySlot();
                Destroy(gameObject); // Remove a peça do jogo após colocá-la
            }
        }
    }
}
