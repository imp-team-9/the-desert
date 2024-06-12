using UnityEngine;
using BlockSideEnum; 

public class BlockSideDetector : MonoBehaviour
{
    public Transform topAttachPoint;
    public Transform bottomAttachPoint;
    public Transform leftAttachPoint;
    public Transform rightAttachPoint;
    public Transform frontAttachPoint;
    public Transform backAttachPoint;

    public BlockSide DetectSide(Vector3 hoverPosition)
    {
  
        float topDistance = Vector3.Distance(hoverPosition, topAttachPoint.position);
        float bottomDistance = Vector3.Distance(hoverPosition, bottomAttachPoint.position);
        float leftDistance = Vector3.Distance(hoverPosition, leftAttachPoint.position);
        float rightDistance = Vector3.Distance(hoverPosition, rightAttachPoint.position);
        float frontDistance = Vector3.Distance(hoverPosition, frontAttachPoint.position);
        float backDistance = Vector3.Distance(hoverPosition, backAttachPoint.position);

        float minDistance = Mathf.Min(topDistance, bottomDistance, leftDistance, rightDistance, frontDistance, backDistance);

        if (minDistance == topDistance) return BlockSide.Top;
        if (minDistance == bottomDistance) return BlockSide.Bottom;
        if (minDistance == leftDistance) return BlockSide.Left;
        if (minDistance == rightDistance) return BlockSide.Right;
        if (minDistance == frontDistance) return BlockSide.Front;
        return BlockSide.Back;
    }
}
