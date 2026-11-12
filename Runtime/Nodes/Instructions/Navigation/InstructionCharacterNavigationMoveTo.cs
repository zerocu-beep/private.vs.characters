using System;
using System.Threading.Tasks;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Move To")]
    [Description("Instructs the Character to move to a new location")]

    [Category("Characters/Navigation/Move To")]
    
    [Parameter(
        "Location", 
        "The position and rotation of the destination"
    )]
    
    [Parameter(
        "Stop Distance", 
        "Distance to the destination that the Character considers it has reached the target"
    )]
    
    [Parameter(
        "Cancel on Fail", 
        "Stops executing the rest of Instructions if the path has been obstructed"
    )]
    
    [Parameter(
        "On Fail", 
        "A list of Instructions executed when it can't reach the destination"
    )]
    

    [Keywords("Walk", "Run", "Position", "Location", "Destination")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Blue)]

    [Serializable]
    public class InstructionCharacterNavigationMoveTo : TInstructionCharacterNavigation
    {
        [Serializable]
        public class NavigationOptions
        {
            // EXPOSED MEMBERS: -------------------------------------------------------------------
            
            [SerializeField] private bool m_WaitToArrive = true;

            [SerializeField] private bool m_CancelOnFail = true;
            [SerializeField] private Instructions m_OnFail = new Instructions();
            
            // PROPERTIES: ------------------------------------------------------------------------

            public bool WaitToArrive => this.m_WaitToArrive;
            
            public bool CancelOnFail => this.m_CancelOnFail;
            public Instructions OnFail => this.m_OnFail;
        }
        
        private class NavigationResult
        {
            [NonSerialized] private bool m_Complete;
            [NonSerialized] private bool m_Success = true;
            
            public void OnFinish(Character character, bool success)
            {
                this.m_Complete = true;
                this.m_Success = success;
            }
            
            public async Task<bool> Await(NavigationOptions options)
            {
                if (options.WaitToArrive)
                {
                    while (this.m_Complete == false)
                    {
                        await Task.Yield();
                    }
                }
                
                return this.m_Success;
            }
        }
        
        ///////////////////////////////////////////////////////////////////////////////////////////
        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] private GetLocation m_Location = new GetLocation(new TypeLocationNavigationMarker());
        [SerializeField] private GetNumber m_StopDistance = new GetNumber(0f);
        
        [SerializeField] private NavigationOptions m_Options = new NavigationOptions();
        
        // MEMBERS: -------------------------------------------------------------------------------

        [NonSerialized] private NavigationResult m_Result;
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Move {this.m_Character} to {this.m_Location}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override async Awaitable Run(Args args)
        {
            this.m_Result = new NavigationResult();
            
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return;

            Location location = this.m_Location.Get(args);
            character.Motion.MoveToLocation(
                location, 
                (float) this.m_StopDistance.Get(args),
                this.m_Result.OnFinish
            );
            
            bool success = await this.m_Result.Await(this.m_Options);
            if (success) return;
            
            await this.m_Options.OnFail.Run(args, this.ParentCancelToken);
            
            if (this.m_Options.CancelOnFail)
            {
                this.CurrentResult = InstructionResult.Exit;
            }
        }
    }
}