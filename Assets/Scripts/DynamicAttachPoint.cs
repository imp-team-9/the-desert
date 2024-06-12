using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using BlockSideEnum;

public class DynamicAttachPoint : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public BlockSideDetector blockSideDetector;

    private void Start()
    {
       
    }

    public void OnHoverEnter(XRBaseInteractor interactor)
    {
        Vector3 hoverPosition = interactor.transform.position;
        BlockSide side = blockSideDetector.DetectSide(hoverPosition);
        Transform newAttachPoint = GetAttachPoint(side);
        socketInteractor.attachTransform = newAttachPoint;
    }

    private Transform GetAttachPoint(BlockSide side)
    {
        switch (side)
        {
            case BlockSide.Top:
                return blockSideDetector.topAttachPoint;
            case BlockSide.Bottom:
                return blockSideDetector.bottomAttachPoint;
            case BlockSide.Left:
                return blockSideDetector.leftAttachPoint;
            case BlockSide.Right:
                return blockSideDetector.rightAttachPoint;
            case BlockSide.Front:
                return blockSideDetector.frontAttachPoint;
            case BlockSide.Back:
                return blockSideDetector.backAttachPoint;
            default:
                return null;
        }
    }


}
