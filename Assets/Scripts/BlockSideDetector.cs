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
        Vector3 localPoint = transform.InverseTransformPoint(hoverPosition);
        float topDistance = Vector3.Distance(localPoint, topAttachPoint.localPosition);
        float bottomDistance = Vector3.Distance(localPoint, bottomAttachPoint.localPosition);
        float leftDistance = Vector3.Distance(localPoint, leftAttachPoint.localPosition);
        float rightDistance = Vector3.Distance(localPoint, rightAttachPoint.localPosition);
        float frontDistance = Vector3.Distance(localPoint, frontAttachPoint.localPosition);
        float backDistance = Vector3.Distance(localPoint, backAttachPoint.localPosition);

        float minDistance = Mathf.Min(topDistance, bottomDistance, leftDistance, rightDistance, frontDistance, backDistance);

        if (minDistance == topDistance) return BlockSide.Top;
        if (minDistance == bottomDistance) return BlockSide.Bottom;
        if (minDistance == leftDistance) return BlockSide.Left;
        if (minDistance == rightDistance) return BlockSide.Right;
        if (minDistance == frontDistance) return BlockSide.Front;
        return BlockSide.Back;
    }
}
