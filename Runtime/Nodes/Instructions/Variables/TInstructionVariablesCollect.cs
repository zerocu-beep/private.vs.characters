using System;
using System.Collections.Generic;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Parameter("Origin", "The position where the rest of the game objects are collected")]
    [Parameter("Max Radius", "How far from the Origin the game objects are collected")]
    [Parameter("Min Radius", "How far from the Origin game objects start to be collected")]
    [Parameter("Store In", "List where the collected game objects are saved")]
    [Parameter("Filter", "Checks a set of Conditions with each collected game object")]
    

    [Keywords("Gather", "Get", "Set", "Array", "List", "Variables")]
    [Serializable]
    public abstract class TInstructionVariablesCollect : Instruction
    {
        // EXPOSED MEMBERS: -----------------------------------------------------------------------
        
        [SerializeField] 
        private GetVector3 m_Origin = TypeVector3PositionCharacter.Create;

        [SerializeField] 
        private GetNumber m_MaxRadius = new GetNumber(5f);

        [SerializeField] 
        private GetNumber m_MinRadius = new GetNumber(0.01f);

        [SerializeField] 
        private SetCollectionGameObjects m_StoreIn = new SetCollectionGameObjects();

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => 
            $"Collect {this.TitleTarget} within {this.m_Origin} {this.m_MaxRadius} units";
        
        protected abstract string TitleTarget { get; }

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Vector3 origin = this.m_Origin.Get(args);
            float maxRadius = (float) this.m_MaxRadius.Get(args);
            float minRadius = (float) this.m_MinRadius.Get(args);
            
            List<GameObject> elements = this.Collect(origin, maxRadius, minRadius);
            this.m_StoreIn.Set(elements, args);
            return Done;
        }

        protected abstract List<GameObject> Collect(
            Vector3 origin, 
            float maxRadius, 
            float minRadius
        );
    }
}