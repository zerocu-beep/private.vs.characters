using UnityEngine;
using UnityEngine.EventSystems;

namespace VisualScript.Runtime.Characters
{
    public interface ITouchStick : IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        Vector2 Value { get; }
        GameObject Root { get; }
    }
}