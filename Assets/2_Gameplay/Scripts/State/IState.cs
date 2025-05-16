using UnityEngine;

namespace Gameplay
{
    public interface IState 
    {
        void Exit();
        void Enter();
        void Jump();
        void Walk(Vector2 vector2);
        void OnCollisionEnter(Collision other);
    }
}
