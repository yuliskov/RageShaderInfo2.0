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

namespace Rage.Shaders
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class Pass
    {
        private ShaderDictionary parent;

        public byte VSIndex { get; private set; }
        public byte PSIndex { get; private set; }
        public Fragment PSFragment { get; private set; }
        public Fragment VSFragment { get; private set; }
        public uint[] Unknown { get; private set; }
        //public uint[] Data2 { get; private set; }
        //public ShaderParameter[] para1 { get; private set; }
        //public ShaderParameter[] para2 { get; private set; }

        public Pass(BinaryReader br, ShaderDictionary parent) {
            this.parent = parent;
            Read(br);
            parent.passes.Add(this);
        }

        public void Read(BinaryReader br) {
            VSIndex = br.ReadByte();
            PSIndex = br.ReadByte();

            PSFragment = parent.PSFragments[PSIndex];
            VSFragment = parent.VSFragments[VSIndex];

            byte dataCount = br.ReadByte();
            if (dataCount > 0)
            {
                Unknown = new uint[dataCount * 2];
                //Data2 = new uint[dataCount];

                //para1 = new ShaderParameter[dataCount];
                //para2 = new ShaderParameter[dataCount];

                for (int i = 0; i < dataCount; i++)
                {
                    Unknown[i * 2] = br.ReadUInt32();
                    Unknown[i * 2 + 1] = br.ReadUInt32();

                    //File.AppendAllText(@"C:\usage.txt", Data1[i].ToString() + "\t");
                    
                    //if(Data1[i] < parent.ShaderParameters2.Length) para1[i] = parent.ShaderParameters2[Data1[i]];
                    //parent.highestData1 = Math.Max(parent.highestData1, Data1[i]);

                    //Data2[i] = br.ReadUInt32();
                    //File.AppendAllText(@"C:\usage.txt", Data2[i].ToString() + "\r\n");
                    
                    //if(Data2[i] < parent.ShaderParameters1.Length) para2[i] = parent.ShaderParameters1[Data2[i]];
                    //parent.highestData2 = Math.Max(parent.highestData2, Data2[i]);
                }
                //File.AppendAllText(@"C:\usage.txt", "\r\n----\r\n");
            }
        }
    }
}
