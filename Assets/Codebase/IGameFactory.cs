using UnityEngine;

namespace Codebase
{
    public interface IGameFactory
    {
        GameObject Player { get; set; }

        GameObject CreatePlayer();   
    }
}