using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using BlockSideEnum;

public class DynamicAttachPoint : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public BlockSideDetector blockSideDetector;

    private void Start()
    {
        if (socketInteractor != null)
        {
            socketInteractor.hoverEntered.AddListener(OnHoverEnter);
        }
        else
        {
            Debug.LogError("Socket Interactor is not assigned in the inspector.");
        }
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (blockSideDetector != null)
        {
            Vector3 hoverPosition = args.interactorObject.transform.position;
            BlockSide side = blockSideDetector.DetectSide(hoverPosition);
            Transform newAttachPoint = GetAttachPoint(side);
            socketInteractor.attachTransform = newAttachPoint;
        }
        else
        {
            Debug.LogError("Block Side Detector is not assigned in the inspector.");
        }
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

    private void OnDestroy()
    {
        if (socketInteractor != null)
        {
            // Unregister the OnHoverEnter event handler
            socketInteractor.hoverEntered.RemoveListener(OnHoverEnter);
        }
    }
}
