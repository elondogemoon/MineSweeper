using UnityEngine;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour
{
    public MapGenerator mapGenerator;
    
    public void Initialize(MapGenerator generator)
    {
        mapGenerator = generator;
    }

    // 1�� ����
    // �ֺ� �� ����� ��������� �����ϴ� �Լ��Դϴ�.
    public void OpenAdjacentBlocks(Block block)
    {
       
    }

    // 2�� ����
    // ������ ����� �ֺ� ����� ó���ϴ� �Լ��Դϴ�.
    public void OpenAdjacentBlocksAroundBlock(Block block)
    {
      
    }
}
