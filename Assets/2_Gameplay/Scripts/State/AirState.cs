using UnityEngine;

namespace Gameplay
{
    public class AirState : IState
    {
        bool hasdoubleJumped = false;
        private Character character;
        private PlayerController playerController;
        public AirState(Character c, PlayerController p)
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
            if (hasdoubleJumped)
            {
                return;
            }
            playerController.RunJumpCoroutine();
            hasdoubleJumped = true;
        }

        public void Update()
        {
            
        }

        public void Walk(Vector2 vector2)
        {
            var direction = vector2.ToHorizontalPlane()* playerController.GetairborneSpeedMultiplier();
            character.SetDirection(direction);
        }
        public void OnCollisionEnter(Collision other)
        {
            foreach (var contact in other.contacts)
            {
                if (Vector3.Angle(contact.normal, Vector3.up) < 5)
                {
                    playerController.ChangeState(new GroundState(character, playerController));
                }
            }
        }
    }
}
