using UnityEngine;

namespace Gameplay
{
    public class GroundState : IState
    {
        private Character character;
        private PlayerController playerController;
        public GroundState(Character c, PlayerController p)
        {
            character = c;
            playerController = p;
        }
        public void Enter()
        {
            //These functions are available if needed by other states. following the State pattern.
        }

        public void Exit()
        {
            //These functions are available if needed by other states. following the State pattern.
        }

        public void Jump()
        {
            playerController.RunJumpCoroutine();
            playerController.ChangeState(new AirState(character, playerController));    
        }
        public void Walk(Vector2 vector2) 
        {
            character.SetDirection(vector2.ToHorizontalPlane());
        }
        public void OnCollisionEnter(Collision other)
        {
            
        }
    }
}
