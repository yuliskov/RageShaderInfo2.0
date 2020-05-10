/**********************************************************************\

 Rage Shader Info
 Copyright (C) 2009  DerPlaya78

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.

\**********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Rage.Shaders.Values;

namespace Rage.Shaders
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class ShaderParameter
    {
        public enum ShaderParameterType {
            @int = 1,
            @float = 2,
            float2 = 3,
            float3 = 4,
            float4 = 5,
            sampler = 6,
            @bool = 7,
            float4x3 = 8,
            float4x4 = 9
        }

        public ShaderParameterType Type { get; private set; }
        public byte ArrayCount { get; private set; }
        public bool ValueIsArray { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public byte ValueLength { get; private set; }
        public Value Value { get; private set; }
        public Annotation[] Annotations { get; private set; }

        public void readAnnotations(BinaryReader br) {
            byte annotationsCount = br.ReadByte();
            if (annotationsCount > 0)
            {
                Annotations = new Annotation[annotationsCount];
                for (int i = 0; i < annotationsCount; i++)
                {
                    Annotations[i] = new Annotation(br);
                }
            }
        }

        private void readValue(BinaryReader br) {
            if (ValueLength == 0) return;

            switch (Type)
            {
                case ShaderParameterType.@int:
                    Value = new ValueInt(br);
                    break;
                case ShaderParameterType.@float:
                    Value = new ValueFloat(br);
                    break;
                case ShaderParameterType.float2:
                    Value = new ValueFloat2(br);
                    break;
                case ShaderParameterType.float3:
                    Value = new ValueFloat3(br);
                    break;
                case ShaderParameterType.float4:
                    Value = new ValueFloat4(br);
                    break;
                case ShaderParameterType.@bool:
                    Value = new ValueBool(br);
                    break;
                case ShaderParameterType.float4x3:
                    Value = new ValueFloat4x3(br);
                    break;
                case ShaderParameterType.float4x4:
                    Value = new ValueFloat4x4(br);
                    break;
                case ShaderParameterType.sampler:
                    Value = new ValueSamplerState(br, ValueLength);
                    break;         
            }                
        }

        private void readValueArray( BinaryReader br ) {
            if ( ValueLength == 0 ) return;

            Value[] Values = new Value[ArrayCount];

            for ( int i = 0; i < ArrayCount; i++ ) {
                switch ( Type ) {
                    case ShaderParameterType.@int:
                        Values[i] = new ValueInt( br );
                        break;
                    case ShaderParameterType.@float:
                        Values[i] = new ValueFloat( br );
                        break;
                    case ShaderParameterType.float2:
                        Values[i] = new ValueFloat2( br );
                        break;
                    case ShaderParameterType.float3:
                        Values[i] = new ValueFloat3( br );
                        break;
                    case ShaderParameterType.float4:
                        Values[i] = new ValueFloat4( br );                        
                        break;
                    case ShaderParameterType.@bool:
                        Values[i] = new ValueBool( br );                                                
                        break;
                    case ShaderParameterType.float4x3:
                        Values[i] = new ValueFloat4x3( br );
                        break;
                    case ShaderParameterType.float4x4:
                        Values[i] = new ValueFloat4x4( br );                        
                        break;
                    case ShaderParameterType.sampler:
                        int len = ValueLength / ArrayCount;
                        Values[i] = new ValueSamplerState( br, len );                                                
                        break;
                }
            }
            Value = new ValueList( Values );
        }

        public void Read(BinaryReader br) {
            Type = (ShaderParameterType)br.ReadByte();
            ArrayCount = br.ReadByte();
            if (ArrayCount > 0)
            {
                ValueIsArray = true;
            }
            
            Name = Utils.ReadString(br);
            Description = Utils.ReadString(br);
            readAnnotations(br);

            ValueLength = br.ReadByte();
            if ( ValueIsArray ) readValueArray( br );
            else readValue(br);
        }

        public override string ToString() {
            string a = "";
            if(Annotations != null && Annotations.Length > 0) {
                a = " (" + Annotations.Length.ToString() + ")";
            }
            return Description + a;
        }
    }
}
