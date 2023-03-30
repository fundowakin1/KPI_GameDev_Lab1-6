using System.Collections.Generic;
using Assets.Scripts.Character;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class GameLevelInitializer : MonoBehaviour
    {
        [SerializeField] private CharacterEntity _character;
        [SerializeField] private GameUIInputReader _gameUiInputReader;
        
        private ExternalInputReader _externalInputReader;
        private CharacterBrain _characterBrain;

        private void Awake()
        {
            _externalInputReader = new ExternalInputReader();
            _characterBrain = new CharacterBrain(_character, new List<IInputReader>()
            {
                _gameUiInputReader,
                _externalInputReader,
            });
        }

        private void FixedUpdate()
        {
            _characterBrain.OnFixedUpdate();
        }
    }
}
