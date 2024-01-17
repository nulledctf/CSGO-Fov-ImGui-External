using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClickableTransparentOverlay;
using ImGuiNET;


namespace CSGOMultiHack 
{
    public class Renderer : Overlay
    {
        public int fov = 60; //default value
        protected override void Render()
        {
            ImGui.Begin("MultiHack");
            ImGui.SliderInt("FOV", ref fov, 58, 140); //current, min, max
        }
    }
}
