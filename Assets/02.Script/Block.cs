using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isRevealed;
    private bool flagged;
    private int adjacentMines;
    private SpriteRenderer spriteRenderer;
    private BlockType blockType;
    private Vector2Int position;

    public enum BlockType { Empty, Mine }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ResourceManager.Instance.closeBlockSprite;
    }

    // ���콺 �Է��� ó���Ͽ� ����� ���¸� �����ϴ� �Լ��Դϴ�.
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1))
        {
            if (IsRevealed && AdjacentMines > 0)
            {
                GameManager.Instance.gameLogic.OpenAdjacentBlocksAroundBlock(this);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (!IsRevealed)
            {
                ToggleFlag();
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (!IsRevealed && !Flagged)
            {
                OpenBlock();
            }
        }
    }

    // ����� �����ϰ� ���¸� ������Ʈ�ϴ� �Լ��Դϴ�.
    public void OpenBlock()
    {
        if (isRevealed || flagged) return;

        isRevealed = true;
        UpdateBlockSprite();

        if (blockType == BlockType.Mine)
        {
            GameManager.Instance.GameOver();
        }
        else if (adjacentMines == 0)
        {
            GameManager.Instance.gameLogic.OpenAdjacentBlocks(this);
        }
    }

    // ����� ��������Ʈ�� ���� ���¿� �°� ������Ʈ�ϴ� �Լ��Դϴ�.
    public void UpdateBlockSprite()
    {
        if (spriteRenderer == null)
        {
            return;
        }

        if (flagged)
        {
            spriteRenderer.sprite = ResourceManager.Instance.flagSprite;
        }
        else if (isRevealed)
        {
            if (blockType == BlockType.Mine)
            {
                spriteRenderer.sprite = ResourceManager.Instance.mineSprite;
            }
            else if (adjacentMines > 0)
            {
                spriteRenderer.sprite = ResourceManager.Instance.GetNumberSprite(adjacentMines);
            }
            else
            {
                spriteRenderer.sprite = ResourceManager.Instance.emptySprite;
            }
        }
        else
        {
            spriteRenderer.sprite = ResourceManager.Instance.closeBlockSprite;
        }
    }

    // ����� ��� ���¸� ����ϴ� �Լ��Դϴ�.
    public void ToggleFlag()
    {
        if (isRevealed) return;

        flagged = !flagged;
        UpdateBlockSprite();
    }

    // Property
    public bool IsRevealed
    {
        get { return isRevealed; }
        set { isRevealed = value; }
    }

    public bool Flagged
    {
        get { return flagged; }
        set { flagged = value; }
    }

    public int AdjacentMines
    {
        get { return adjacentMines; }
        set { adjacentMines = value; }
    }

    public BlockType Type
    {
        get { return blockType; }
        set { blockType = value; }
    }

    public Vector2Int Position
    {
        get { return position; }
        set { position = value; }
    }
}
