using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private float spacing;
    [SerializeField] private float minePercent;
    [SerializeField] private GameObject blockPrefab;

    private GameObject[,] blocks;
    private List<Vector2Int> minePositions;

    void Start()
    {
        GenerateBoard();
    }

    void InitializeBlocks()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Block block = blocks[x, y].GetComponent<Block>();
                if (block != null)
                {
                    if (block.Type == Block.BlockType.Empty)
                    {
                        int adjacentMines = CountAdjacentMines(block.Position.x, block.Position.y);
                        block.AdjacentMines = adjacentMines;
                    }

                    block.IsRevealed = false;
                    block.Flagged = false;
                    block.UpdateBlockSprite();
                }
            }
        }
    }

    // ���带 �����ϴ� �Լ��Դϴ�.
    void GenerateBoard()
    {
        blocks = new GameObject[columns, rows];
        minePositions = new List<Vector2Int>();

        // ��ü ��� ���� ���� �� ���
        int totalBlocks = rows * columns;
        int mineCount = Mathf.RoundToInt(totalBlocks * minePercent);

        while (minePositions.Count < mineCount)
        {
            int x = Random.Range(0, columns);
            int y = Random.Range(0, rows);
            Vector2Int newMinePos = new Vector2Int(x, y);

            if (!minePositions.Contains(newMinePos))
            {
                minePositions.Add(newMinePos);
            }
        }

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 position = new Vector3(x * (1 + spacing), y * (1 + spacing), 0);
                GameObject newBlock = Instantiate(blockPrefab, position, Quaternion.identity);
                newBlock.transform.SetParent(this.transform);
                newBlock.name = $"Block_{x}-{y}";
                blocks[x, y] = newBlock;

                Block block = newBlock.GetComponent<Block>();
                if (block != null)
                {
                    block.Position = new Vector2Int(x, y);

                    if (minePositions.Contains(block.Position))
                    {
                        block.Type = Block.BlockType.Mine;
                    }
                    else
                    {
                        block.Type = Block.BlockType.Empty;
                    }
                }
            }
        }

        InitializeBlocks();
    }

    // �ֺ� ���� ���� ����ϴ� �Լ��Դϴ�.
    int CountAdjacentMines(int x, int y)
    {
        int count = 0;

        for (int nX = -1; nX <= 1; nX++)
        {
            for (int nY = -1; nY <= 1; nY++)
            {
                if (nX == 0 && nY == 0) continue;

                int neighborX = x + nX;
                int neighborY = y + nY;

                Block adjacentBlock = GetBlock(neighborX, neighborY);
                if (adjacentBlock != null && adjacentBlock.Type == Block.BlockType.Mine)
                {
                    count++;
                }
            }
        }

        return count;
    }

    // Ư�� ��ġ�� ����� �������� �Լ��Դϴ�.
    public Block GetBlock(int x, int y)
    {
        if (x >= 0 && x < columns && y >= 0 && y < rows)
        {
            return blocks[x, y]?.GetComponent<Block>();
        }
        return null;
    }
}
