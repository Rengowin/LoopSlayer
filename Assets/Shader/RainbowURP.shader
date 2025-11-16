Shader "Custom/RainbowURP"
{
    Properties
    {
        _Speed ("Rainbow Speed", Range(0.1, 5)) = 1
        _Intensity ("Intensity", Range(0, 2)) = 1
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }

        Pass
        {
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float _Speed;
            float _Intensity;

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float3 normalWS : NORMAL;
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS);
                OUT.normalWS = TransformObjectToWorldNormal(IN.normalOS);
                return OUT;
            }

            float4 frag(Varyings IN) : SV_Target
            {
                float t = _Time.y * _Speed;

                float3 rainbow = float3(
                    sin(t),
                    sin(t + 2),
                    sin(t + 4)
                ) * 0.5 + 0.5;

                return float4(rainbow * _Intensity, 1);
            }

            ENDHLSL
        }
    }
}
