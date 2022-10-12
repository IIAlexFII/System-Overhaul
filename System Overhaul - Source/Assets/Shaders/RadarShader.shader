Shader "Custom/RadarShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "Queue" = "Geometry+1" "RenderType" = "Opaque" "PerformanceChecks" = "False" }
        //Tags { "RenderType"="Opaque" }
        
        LOD 200

        //ZTEST GREATER
        ZTEST Off

        //CGPROGRAM
        HLSLPROGRAM
        #pragma surface surf Unlit


        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        
        float4 _Color;

        half4 LightingUnlit(SurfaceOutput s, half3 lightDir, half atten)
        {
            half4 col;
            col.rgb = s.Albedo;
            col.a = s.Alpha;

            return col;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            float4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;          
            o.Alpha = c.a;
        }
        //ENDCG
        ENDHLSL
    }
    FallBack "Diffuse"
}
