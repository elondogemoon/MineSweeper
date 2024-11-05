using UnityEngine;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour
{
    public MapGenerator mapGenerator;
    
    public void Initialize(MapGenerator generator)
    {
        mapGenerator = generator;
    }

    // 1번 문제
    // 주변 빈 블록을 재귀적으로 공개하는 함수입니다.
    public void OpenAdjacentBlocks(Block block)
    {
       
    }

    // 2번 문제
    // 공개된 블록의 주변 블록을 처리하는 함수입니다.
    public void OpenAdjacentBlocksAroundBlock(Block block)
    {
      
    }
}
