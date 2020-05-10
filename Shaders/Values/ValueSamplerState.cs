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
using System.IO;
using System;
using System.Collections.Generic;

namespace Rage.Shaders.Values
{
    [System.ComponentModel.TypeConverter( typeof( System.ComponentModel.ExpandableObjectConverter ) )]
    public class ValueSamplerState : Value
    {
        public int[] values { get; private set; }
        public string[] valuesString { get; private set; }

        public ValueSamplerState( BinaryReader br, int count )
        {
            Read(br, count);
        }

        public void Read(BinaryReader br, int count) {
            System.Diagnostics.Debug.Assert(count % 2 == 0);
            values = new int[count];
            List<string> test = new List<string>();
            for ( int i = 0; i < count / 2; i++ ) {
                
                values[i * 2] = br.ReadInt32();
                //File.AppendAllText(@"C:\samplerState.txt", values[i * 2].ToString());
                values[i * 2 + 1] = br.ReadInt32();
                //File.AppendAllText(@"C:\samplerState.txt", "\t" + values[i * 2 + 1].ToString()+"\r\n"); 

                SamplerStateType type = (SamplerStateType)values[i * 2] + 1;
                int value = values[i * 2 + 1];
                switch (type) { 
                    case SamplerStateType.AddressU:
                    case SamplerStateType.AddressV:
                    case SamplerStateType.AddressW:
                        test.Add(type.ToString() + "=" + ((TextureAddress)value).ToString());                    
                        break;
                    case SamplerStateType.BorderColor:
                        byte[] tmp = BitConverter.GetBytes(value);
                        string color = "r:" + (tmp[0] / 255f).ToString(System.Globalization.CultureInfo.InvariantCulture) +
                            ", g:" + (tmp[1] / 255f).ToString(System.Globalization.CultureInfo.InvariantCulture) +
                            ", b:" + (tmp[2] / 255f).ToString(System.Globalization.CultureInfo.InvariantCulture) +
                            ", a:" + (tmp[3] / 255f).ToString(System.Globalization.CultureInfo.InvariantCulture);
                        test.Add(type.ToString() + "=" + color);
                        break;
                    case SamplerStateType.MagFilter:
                    case SamplerStateType.MinFilter:
                    case SamplerStateType.MipFilter:
                        test.Add(type.ToString() + "=" + ((TextureFilterType)value).ToString());                    
                        break;
                    case SamplerStateType.MipMapLodBias:
                        test.Add(type.ToString() + "=" + BitConverter.ToSingle(BitConverter.GetBytes(value), 0).ToString(System.Globalization.CultureInfo.InvariantCulture));
                        break;
                    default:
                        throw new Exception(type.ToString());
                }
                
            }
            valuesString = test.ToArray();
        }

        public override string ToString() {
            return "SamplerState";
        }
    }
}
