Shader "Hidden/DrawingEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        
        _GradThresh("Stencil Gradiant threshold", range(0.001 , 1)) = 0.024
        _Samples("Stencil Samples", range(2,40)) = 2
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            Cull Back ZWrite On ZTest Always
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma exclude_renderers d3d11_9x
                #pragma exclude_renderers d3d9
                #include "UnityCG.cginc"
                #include "UnityStandardUtils.cginc"
                
                sampler2D _MainTex;

                float _GradThresh;
                float _Samples;

                #define PI2 6.28318530717959
                #define STEP 8.0                //quality parameters
                #define RANGE 16.0
                #define SENSITIVITY 20.0

                struct appdata
                {
                    float4 vertex : POSITION;
                    float4 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float4 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = ComputeGrabScreenPos(o.vertex);
                    return o;
                }

                float getVal(float2 pos)
                {
                    return tex2D(_MainTex, pos / _ScreenParams.xy);;
                }

                float2 getGrad(float2 pos, float delta)
                {
                    float2 d = float2(delta, 0.0);
                    return float2(getVal(pos + d.xy) - getVal(pos - d.xy),
                        getVal(pos + d.yx) - getVal(pos - d.yx)) / delta / 2.0;
                }

                void pR(inout float2 p, float a) {
                    p = cos(a) * p + sin(a) * float2(p.y, -p.x);
                }

                half4 frag(v2f i) : SV_Target
                {
                    float2 screenuv = i.uv.xy / i.uv.w;
                    float2 screenPos = float2(i.uv.x * _ScreenParams.x, i.uv.y * _ScreenParams.y);
                    half weight = 1;

                    [loop]
                    for (float j = 0; j < _Samples; j++)
                    {
                        float2 dir = float2(1.0, 0.0);
                        pR(dir, j * PI2 / (2.0 * _Samples));

                        float2 grad = float2(-dir.y, dir.x);

                        [loop]
                        for (float i = -RANGE; i <= RANGE; i += STEP)
                        {
                            float2 b = normalize(dir);
                            float2 pos2 = screenPos + float2(b.x, b.y) * i;

                            if (pos2.y < 0.0 || pos2.x < 0.0 || pos2.x > _ScreenParams.x || pos2.y > _ScreenParams.y)
                                continue;

                            float2 g = getGrad(pos2, 1.0);

                            if (sqrt(dot(g, g)) < _GradThresh)
                                continue;

                            weight -= pow(abs(dot(normalize(grad), normalize(g))), SENSITIVITY) / floor((2.0 * RANGE + 1.0) / STEP) / _Samples;
                        }
                    }

                    
                    return weight;
                    
                    /*float normalized = invLerp(0.7, 1, weight);
                    float remapedWeight = lerp(0, 1, normalized);
                    return remapedWeight;*/

                }
            ENDCG
        }
    }
}
