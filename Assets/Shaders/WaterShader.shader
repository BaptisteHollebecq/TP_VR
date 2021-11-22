// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "WaterShader"
{
	Properties
	{
		_Diffraction("Diffraction", Float) = 0.05
		[NoScaleOffset]_Water("Water ", 2D) = "white" {}
		_Tilingnormal("Tiling normal", Float) = 1
		[HDR]_Color2("Color 2", Color) = (0,0.5885868,1,0)
		[HDR]_Color3("Color 2", Color) = (0,0.5885868,1,0)
		_VertexOffset("Vertex Offset", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		GrabPass{ }
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#if defined(UNITY_STEREO_INSTANCING_ENABLED) || defined(UNITY_STEREO_MULTIVIEW_ENABLED)
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex);
		#else
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex)
		#endif
		#pragma surface surf Standard alpha:fade keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float4 screenPos;
			float2 uv_texcoord;
		};

		uniform float _VertexOffset;
		ASE_DECLARE_SCREENSPACE_TEXTURE( _GrabTexture )
		uniform sampler2D _Water;
		uniform float _Tilingnormal;
		uniform float _Diffraction;
		uniform float4 _Color3;
		uniform float4 _Color2;


		float2 voronoihash74( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi74( float2 v, float time, inout float2 id, inout float2 mr, float smoothness, inout float2 smoothId )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash74( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.5 * dot( r, r );
			 		if( d<F1 ) {
			 			F2 = F1;
			 			F1 = d; mg = g; mr = r; id = o;
			 		} else if( d<F2 ) {
			 			F2 = d;
			
			 		}
			 	}
			}
			return F1;
		}


		float2 voronoihash80( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi80( float2 v, float time, inout float2 id, inout float2 mr, float smoothness, inout float2 smoothId )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash80( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.5 * dot( r, r );
			 		if( d<F1 ) {
			 			F2 = F1;
			 			F1 = d; mg = g; mr = r; id = o;
			 		} else if( d<F2 ) {
			 			F2 = d;
			
			 		}
			 	}
			}
			return F1;
		}


		inline float4 ASE_ComputeGrabScreenPos( float4 pos )
		{
			#if UNITY_UV_STARTS_AT_TOP
			float scale = -1.0;
			#else
			float scale = 1.0;
			#endif
			float4 o = pos;
			o.y = pos.w * 0.5f;
			o.y = ( pos.y - o.y ) * _ProjectionParams.x * scale + o.y;
			return o;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float time74 = 0.0;
			float2 voronoiSmoothId0 = 0;
			float2 _Vector3 = float2(0.5,0.12);
			float2 uv_TexCoord75 = v.texcoord.xy * _Vector3 + ( _Time.y * float2( 0,0.1 ) );
			float2 coords74 = uv_TexCoord75 * 11.86;
			float2 id74 = 0;
			float2 uv74 = 0;
			float voroi74 = voronoi74( coords74, time74, id74, uv74, 0, voronoiSmoothId0 );
			float time80 = 0.0;
			float2 uv_TexCoord79 = v.texcoord.xy * _Vector3 + ( _Time.y * float2( 0,0.05 ) );
			float2 coords80 = uv_TexCoord79 * 11.86;
			float2 id80 = 0;
			float2 uv80 = 0;
			float voroi80 = voronoi80( coords80, time80, id80, uv80, 0, voronoiSmoothId0 );
			float temp_output_88_0 = ( ( voroi74 * voroi80 ) * 10.0 );
			float4 appendResult102 = (float4(0.0 , ( temp_output_88_0 * _VertexOffset ) , 0.0 , 0.0));
			v.vertex.xyz += appendResult102.xyz;
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( ase_screenPos );
			float4 ase_grabScreenPosNorm = ase_grabScreenPos / ase_grabScreenPos.w;
			float2 appendResult11 = (float2(ase_grabScreenPosNorm.xy));
			float2 appendResult36 = (float2(_Tilingnormal , _Tilingnormal));
			float2 uv_TexCoord15 = i.uv_texcoord * appendResult36 + ( _Time.y * float2( 0,0.2 ) );
			float2 appendResult10 = (float2(UnpackNormal( tex2D( _Water, uv_TexCoord15 ) ).xy));
			float4 screenColor2 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,( ( appendResult11 / ase_grabScreenPosNorm.a ) + ( appendResult10 * _Diffraction ) ));
			o.Albedo = ( ( screenColor2 * _Color3 ) + _Color2 ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18912
263;73;730;669;411.53;-1122.795;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;35;-2826.867,182.4822;Inherit;False;Property;_Tilingnormal;Tiling normal;2;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;16;-2870.745,418.4441;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;17;-2893.455,629.1887;Inherit;False;Constant;_Vector0;Vector 0;2;0;Create;True;0;0;0;False;0;False;0,0.2;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-2621.719,515.3689;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;36;-2632.549,283.7139;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;15;-2457.419,383.5408;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexturePropertyNode;26;-2436.567,149.6532;Inherit;True;Property;_Water;Water ;1;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;d4e876a62db598740b48093c4b6c991f;d4e876a62db598740b48093c4b6c991f;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SamplerNode;7;-2148.424,331.0086;Inherit;True;Property;_WaterNormal;Water Normal;0;0;Create;True;0;0;0;False;0;False;-1;d4e876a62db598740b48093c4b6c991f;d4e876a62db598740b48093c4b6c991f;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TimeNode;82;-2104.246,1417.56;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;83;-2126.956,1628.305;Inherit;False;Constant;_Vector2;Vector 2;2;0;Create;True;0;0;0;False;0;False;0,0.05;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TimeNode;77;-2123.255,986.6378;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;78;-2145.965,1197.382;Inherit;False;Constant;_Vector1;Vector 1;2;0;Create;True;0;0;0;False;0;False;0,0.1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;81;-1855.219,1514.486;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;76;-1874.228,1083.563;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.UnpackScaleNormalNode;9;-1817.099,336.4121;Inherit;False;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.GrabScreenPosition;5;-1078.266,-11.03873;Inherit;False;0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;86;-1870.305,929.5754;Inherit;False;Constant;_Vector3;Vector 3;4;0;Create;True;0;0;0;False;0;False;0.5,0.12;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;75;-1533.519,882.2697;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;11;-817.4801,27.0166;Inherit;False;FLOAT2;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;14;-1525.633,517.3864;Inherit;False;Property;_Diffraction;Diffraction;0;0;Create;True;0;0;0;False;0;False;0.05;0.04;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;10;-1488.138,338.3974;Inherit;False;FLOAT2;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;79;-1603.369,1341.253;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;74;-1245.671,976.7966;Inherit;True;0;0;1;0;1;False;1;False;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;11.86;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.VoronoiNode;80;-1315.521,1435.78;Inherit;True;0;0;1;0;1;False;1;False;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;11.86;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-1290.918,330.6624;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;12;-646.4801,50.0166;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;6;-438.5112,74.61285;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;84;-955.1622,1277.65;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;89;-781.9402,1531.031;Inherit;False;Constant;_Float0;Float 0;3;0;Create;True;0;0;0;False;0;False;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenColorNode;2;-269.338,30.13815;Inherit;False;Global;_GrabScreen0;Grab Screen 0;1;0;Create;True;0;0;0;False;0;False;Object;-1;False;False;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;88;-599.9865,1319.001;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;129;264.6366,335.4281;Inherit;False;Property;_Color3;Color 2;6;1;[HDR];Create;True;0;0;0;False;0;False;0,0.5885868,1,0;0,3.019654,21.36125,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;130;-89.29962,1503.31;Inherit;False;Property;_VertexOffset;Vertex Offset;7;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;126;512.8745,190.3822;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;127;471.0097,-37.95906;Inherit;False;Property;_Color2;Color 2;5;1;[HDR];Create;True;0;0;0;False;0;False;0,0.5885868,1,0;0.08884287,0,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;131;119.5543,1388.718;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;97;161.6406,512.3086;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.DynamicAppendNode;102;356.8647,1365.665;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleAddOpNode;128;780.1721,-233.1883;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;92;-320.7325,893.8032;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;94;-682.73,1053.807;Inherit;False;Property;_Color1;Color 1;4;1;[HDR];Create;True;0;0;0;False;0;False;0.4764151,0.914363,1,0;1.662551,1.662551,1.662551,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;93;-645.3901,827.1018;Inherit;False;Property;_Color0;Color 0;3;1;[HDR];Create;True;0;0;0;False;0;False;0,0.1608469,1,0;1,0,0.08150673,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;932.6304,264.6136;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;WaterShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;18;0;16;2
WireConnection;18;1;17;0
WireConnection;36;0;35;0
WireConnection;36;1;35;0
WireConnection;15;0;36;0
WireConnection;15;1;18;0
WireConnection;7;0;26;0
WireConnection;7;1;15;0
WireConnection;81;0;82;2
WireConnection;81;1;83;0
WireConnection;76;0;77;2
WireConnection;76;1;78;0
WireConnection;9;0;7;0
WireConnection;75;0;86;0
WireConnection;75;1;76;0
WireConnection;11;0;5;0
WireConnection;10;0;9;0
WireConnection;79;0;86;0
WireConnection;79;1;81;0
WireConnection;74;0;75;0
WireConnection;80;0;79;0
WireConnection;13;0;10;0
WireConnection;13;1;14;0
WireConnection;12;0;11;0
WireConnection;12;1;5;4
WireConnection;6;0;12;0
WireConnection;6;1;13;0
WireConnection;84;0;74;0
WireConnection;84;1;80;0
WireConnection;2;0;6;0
WireConnection;88;0;84;0
WireConnection;88;1;89;0
WireConnection;126;0;2;0
WireConnection;126;1;129;0
WireConnection;131;0;88;0
WireConnection;131;1;130;0
WireConnection;97;0;2;0
WireConnection;97;1;92;0
WireConnection;102;1;131;0
WireConnection;128;0;126;0
WireConnection;128;1;127;0
WireConnection;92;0;93;0
WireConnection;92;1;94;0
WireConnection;92;2;88;0
WireConnection;0;0;128;0
WireConnection;0;11;102;0
ASEEND*/
//CHKSM=80EC9E94C26F9174A9010B731CB0640ABBFD3937