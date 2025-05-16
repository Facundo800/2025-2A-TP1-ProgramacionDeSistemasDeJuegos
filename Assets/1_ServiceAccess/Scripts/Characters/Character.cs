using System;
using UnityEngine;

namespace Excercise1
{
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] protected string id;
        protected virtual void OnEnable()
        {
            
            CharacterService.instance.TryAddCharacter(id, this);

                //TODO: Add to CharacterService. The id should be the given serialized field. 
        }

        protected virtual void OnDisable()
        {
            CharacterService.instance.TryRemoveCharacter(id);
            //TODO: Remove from CharacterService.
        }
    }
}