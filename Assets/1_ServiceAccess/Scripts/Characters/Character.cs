using System;
using UnityEngine;

namespace Excercise1
{
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] protected string id;
        [SerializeField] protected CharacterService characterservice;
        protected virtual void OnEnable()
        {
            characterservice.TryAddCharacter(id, this);
                //TODO: Add to CharacterService. The id should be the given serialized field. 
        }

        protected virtual void OnDisable()
        {
            characterservice.TryRemoveCharacter(id);
            //TODO: Remove from CharacterService.
        }
    }
}