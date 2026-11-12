using System;
using System.Threading.Tasks;

namespace VisualScript.Runtime.Characters
{
    public interface INavMeshTraverseLink
    {
        Task Traverse(Character character, Action onTraverseComplete);
    }
}