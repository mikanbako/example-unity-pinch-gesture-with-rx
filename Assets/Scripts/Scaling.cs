using UnityEngine;

public sealed class Scaling
{
    public Vector2 Center { get; private set; }

    public float Scale { get; private set; }

    public Scaling(Vector2 center, float scale)
    {
        Center = center;
        Scale = scale;
    }
}
