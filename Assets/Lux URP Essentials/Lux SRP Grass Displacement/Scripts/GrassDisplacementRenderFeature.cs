using UnityEngine.Experimental.Rendering;


namespace Lux_SRP_GrassDisplacement
{
    public class GrassDisplacementRenderFeature : UnityEngine.Rendering.Universal.ScriptableRendererFeature
    {
        
        [System.Serializable]
        public enum RTDisplacementSize {
            _128 = 128,
            _256 = 256,
            _512 = 512,
            _1024 = 1024
        }

        [System.Serializable]
        public class GrassDisplacementSettings
        {
            public RTDisplacementSize Resolution = RTDisplacementSize._256;
            public float Size = 20.0f;
            public bool ShiftRenderTex = false;
            //public bool SinglePassInstancing = false;
        }

        public GrassDisplacementSettings settings = new GrassDisplacementSettings();
        GrassDisplacementPass m_GrassDisplacementPass;
        
        public override void Create()
        {
            m_GrassDisplacementPass = new GrassDisplacementPass();
            m_GrassDisplacementPass.renderPassEvent = UnityEngine.Rendering.Universal.RenderPassEvent.BeforeRenderingShadows;

        //  Apply settings
            m_GrassDisplacementPass.m_Resolution = (int)settings.Resolution;
            m_GrassDisplacementPass.m_Size = settings.Size;
            m_GrassDisplacementPass.m_ShiftRenderTex = settings.ShiftRenderTex;
            //m_GrassDisplacementPass.m_SinglePassInstancing = settings.SinglePassInstancing;

        }
        
        public override void AddRenderPasses(UnityEngine.Rendering.Universal.ScriptableRenderer renderer, ref UnityEngine.Rendering.Universal.RenderingData renderingData)
        {
            renderer.EnqueuePass(m_GrassDisplacementPass);
        }
    }




//  ---------------------------------------------------------
//  The Pass
}