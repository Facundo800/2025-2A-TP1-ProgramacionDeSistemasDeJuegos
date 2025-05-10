using System;
using System.Collections.Generic;
using UnityEngine;

namespace Excercise1
{
    public class CharacterService : MonoBehaviour
    {
        public static CharacterService instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        private readonly Dictionary<string, ICharacter> _charactersById = new();
        public bool TryAddCharacter(string id, ICharacter character)
            => _charactersById.TryAdd(id, character);
        public bool TryRemoveCharacter(string id)
            => _charactersById.Remove(id);

        public ICharacter GetCharacter(string playerId)
        {
            ICharacter value = _charactersById[playerId];
            return value;
        }
    }
}
