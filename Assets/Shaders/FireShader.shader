// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "FireShader"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_MainNoisecloud("Main Noise (cloud)", 2D) = "white" {}
		[HDR]_Color2("Color 2", Color) = (1,0.6196079,0,0)
		[HDR]_Color("Color ", Color) = (1,0,0,0)
		_FireTiling("Fire Tiling", Float) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Transparent+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _MainNoisecloud;
		uniform float _FireTiling;
		uniform float4 _Color;
		uniform float4 _Color2;
		uniform float _Cutoff = 0.5;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float2 appendResult43 = (float2(_FireTiling , _FireTiling));
			float2 uv_TexCoord2 = v.texcoord.xy * appendResult43 + ( _Time.y * float2( -0.2,-3 ) );
			float2 uv_TexCoord10 = v.texcoord.xy * appendResult43 + ( _Time.y * float2( 0.3,-2 ) );
			float temp_output_14_0 = ( tex2Dlod( _MainNoisecloud, float4( uv_TexCoord2, 0, 0.0) ).g * tex2Dlod( _MainNoisecloud, float4( uv_TexCoord10, 0, 0.0) ).r );
			float4 appendResult44 = (float4(temp_output_14_0 , 0.0 , temp_output_14_0 , 0.0));
			v.vertex.xyz += ( ( ( appendResult44 - float4( 0.5,0,0.5,0 ) ) * v.texcoord.xy.y ) * 0.3 ).xyz;
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 appendResult43 = (float2(_FireTiling , _FireTiling));
			float2 uv_TexCoord2 = i.uv_texcoord * appendResult43 + ( _Time.y * float2( -0.2,-3 ) );
			float2 uv_TexCoord10 = i.uv_texcoord * appendResult43 + ( _Time.y * float2( 0.3,-2 ) );
			float temp_output_14_0 = ( tex2D( _MainNoisecloud, uv_TexCoord2 ).g * tex2D( _MainNoisecloud, uv_TexCoord10 ).r );
			float smoothstepResult17 = smoothstep( 0.5 , ( 0.5 + 0.5 ) , i.uv_texcoord.y);
			float temp_output_16_0 = ( temp_output_14_0 * ( 1.0 - smoothstepResult17 ) );
			float smoothstepResult29 = smoothstep( 0.27 , ( 0.27 + -0.56 ) , i.uv_texcoord.y);
			float temp_output_22_0 = ( 1.0 - step( ( temp_output_16_0 + smoothstepResult29 ) , 0.41 ) );
			float4 lerpResult37 = lerp( _Color , _Color2 , temp_output_16_0);
			o.Emission = ( temp_output_22_0 * lerpResult37 ).rgb;
			o.Alpha = 1;
			clip( temp_output_22_0 - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18912
266;73;718;695;1878.748;-296.4433;1.035671;True;False
Node;AmplifyShaderEditor.TimeNode;3;-1512.26,209.5455;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;13;-1489.51,856.9451;Inherit;False;Constant;_Vector0;Vector 0;1;0;Create;True;0;0;0;False;0;False;0.3,-2;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;42;-1476.239,-72.00356;Inherit;False;Property;_FireTiling;Fire Tiling;4;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;5;-1456.36,383.7456;Inherit;False;Constant;_Dir;Dir;1;0;Create;True;0;0;0;False;0;False;-0.2,-3;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TimeNode;11;-1545.41,682.7449;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;20;-600.6035,1038.358;Inherit;False;Constant;_Float2;Float 2;1;0;Create;True;0;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-1261.36,292.7455;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-1294.51,765.9449;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-582.1202,903.7499;Inherit;False;Constant;_Float1;Float 1;1;0;Create;True;0;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;43;-1298.717,3.831207;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;19;-408.9026,955.8127;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;10;-1116.41,576.1451;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-1083.26,102.9456;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexturePropertyNode;8;-1084.631,-126.7861;Inherit;True;Property;_MainNoisecloud;Main Noise (cloud);1;0;Create;True;0;0;0;False;0;False;e5f356180e9312c4f9dc5e884ce5efa4;e5f356180e9312c4f9dc5e884ce5efa4;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TextureCoordinatesNode;15;-605.5706,744.3025;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-789.4594,56.14547;Inherit;True;Property;_MainNoise;Main Noise;0;0;Create;True;0;0;0;False;0;False;-1;e5f356180e9312c4f9dc5e884ce5efa4;e5f356180e9312c4f9dc5e884ce5efa4;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;9;-775.0721,388.6856;Inherit;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;17;-283.4607,761.0027;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;-446.0829,310.2635;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;27;-162.9224,652.0623;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;33;264.4037,88.52419;Inherit;False;Constant;_Float3;Float 3;1;0;Create;True;0;0;0;False;0;False;0.27;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;34;265.4037,228.5243;Inherit;False;Constant;_Float4;Float 4;1;0;Create;True;0;0;0;False;0;False;-0.56;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;28;221.0609,-96.59571;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-121.4551,324.9888;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;30;445.288,119.6068;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;29;570.73,-75.20354;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;38;85.30408,-132.4955;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;35;788.7741,-227.9436;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;7;1097.334,13.84157;Inherit;False;Constant;_Float0;Float 0;1;0;Create;True;0;0;0;False;0;False;0.41;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;44;392.9306,958.1178;Inherit;True;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ColorNode;39;1057.987,329.8088;Inherit;False;Property;_Color;Color ;3;1;[HDR];Create;True;0;0;0;False;0;False;1,0,0,0;1,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;6;1300.3,-259.6625;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;40;1022.255,537.5821;Inherit;False;Property;_Color2;Color 2;2;1;[HDR];Create;True;0;0;0;False;0;False;1,0.6196079,0,0;1,0.6196079,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;53;632.1302,980.785;Inherit;False;2;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0.5,0,0.5,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;50;501.5559,1235.352;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;48;771.5687,1002.086;Inherit;True;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;55;858.1771,1274.362;Inherit;False;Constant;_Float5;Float 5;5;0;Create;True;0;0;0;False;0;False;0.3;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;37;1285.892,673.6485;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;22;1532.174,-265.9655;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;41;1853.23,190.6266;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;54;1017.36,1011.522;Inherit;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;2370.498,-57.87834;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;FireShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;False;TransparentCutout;;Transparent;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;4;0;3;2
WireConnection;4;1;5;0
WireConnection;12;0;11;2
WireConnection;12;1;13;0
WireConnection;43;0;42;0
WireConnection;43;1;42;0
WireConnection;19;0;18;0
WireConnection;19;1;20;0
WireConnection;10;0;43;0
WireConnection;10;1;12;0
WireConnection;2;0;43;0
WireConnection;2;1;4;0
WireConnection;1;0;8;0
WireConnection;1;1;2;0
WireConnection;9;0;8;0
WireConnection;9;1;10;0
WireConnection;17;0;15;2
WireConnection;17;1;18;0
WireConnection;17;2;19;0
WireConnection;14;0;1;2
WireConnection;14;1;9;1
WireConnection;27;0;17;0
WireConnection;16;0;14;0
WireConnection;16;1;27;0
WireConnection;30;0;33;0
WireConnection;30;1;34;0
WireConnection;29;0;28;2
WireConnection;29;1;33;0
WireConnection;29;2;30;0
WireConnection;38;0;16;0
WireConnection;35;0;38;0
WireConnection;35;1;29;0
WireConnection;44;0;14;0
WireConnection;44;2;14;0
WireConnection;6;0;35;0
WireConnection;6;1;7;0
WireConnection;53;0;44;0
WireConnection;48;0;53;0
WireConnection;48;1;50;2
WireConnection;37;0;39;0
WireConnection;37;1;40;0
WireConnection;37;2;16;0
WireConnection;22;0;6;0
WireConnection;41;0;22;0
WireConnection;41;1;37;0
WireConnection;54;0;48;0
WireConnection;54;1;55;0
WireConnection;0;2;41;0
WireConnection;0;10;22;0
WireConnection;0;11;54;0
ASEEND*/
//CHKSM=7480BC6A4AB84510C9E9A0863534777635D9A022