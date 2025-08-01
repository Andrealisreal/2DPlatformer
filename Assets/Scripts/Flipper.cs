using UnityEngine;

public class Flipper
{
    private readonly SpriteRenderer _renderer;

    public Flipper(SpriteRenderer renderer)
    {
        _renderer = renderer;
    }

    public void Turn(Vector2 direction)
    {
        if (direction.x > 0)
            _renderer.flipX = false;
        else if (direction.x < 0)
            _renderer.flipX = true;
    }
}