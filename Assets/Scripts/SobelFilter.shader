Shader "Hidden/SobelFilter"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float2 _MainTex_TexelSize;

            fixed4 frag (v2f i) : SV_Target
            {
                float gradientX = 0;
                float gradientY = 0;

                float sobelX[9] = {
                    -1,     -2,     -1,
                    0,      0,      0,
                    1,      2,      1
                };

                float sobelY[9] = {
                    -1,     0,      1,
                    -2,     0,      2,
                    -1,     0,      1,
                };

                int index = 0;

                for(int x = -1; x <=1; x++)
                {
                    for(int y = -1; y <= 1; y++)
                    {
                        if(index == 4 )
                        {
                            index++;
                            continue;
                        }
                        float2 offset = float2(x, y) * _MainTex_TexelSize;
                        float3 pxCol = tex2D(_MainTex, i.uv + offset).xyz;
                        float pxLum = dot(pxCol, float3(0.212, 0.7152,0.0722));

                        gradientX += pxLum * sobelX[index];
                        gradientY += pxLum * sobelY[index];

                        index++;
                    }
                }

                float sobel = length(float2(gradientX, gradientY));  

                float angle = 0;
                if (abs(gradientX) > 0.001)
                {
                    angle = atan(gradientY / gradientX);
                }

                return sobel;
            }
            ENDCG
        }
    }
}
