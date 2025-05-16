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
          
        }

        public void Exit()
        {
          
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
