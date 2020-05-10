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

namespace Rage.Shaders {
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class Fragment {
        private ushort size1;
        [System.ComponentModel.DisplayName("Size in bytes")]
        public ushort size2 { get; private set; }
        [System.ComponentModel.Browsable(false)]
        public byte[] RawData { get; private set; }

        public FragmentParameter[] Parameters { get; private set; }

        public Fragment( BinaryReader br ) {
            Read( br );
        }
        
        public void Read( BinaryReader br ) {
            byte numParameters = br.ReadByte();
            if ( numParameters > 0 ) {
                Parameters = new FragmentParameter[numParameters];
                for ( int i = 0; i < numParameters; i++ ) {
                    FragmentParameter csp = new FragmentParameter( br );
                    Parameters[i] = csp;
                }
            }
            size1 = br.ReadUInt16();
            size2 = br.ReadUInt16();
            RawData = br.ReadBytes( size2 );
        }

        public string Disassemble() {
            SlimDX.Direct3D9.ShaderBytecode code = new SlimDX.Direct3D9.ShaderBytecode(RawData);
            SlimDX.DataStream s = code.Disassemble();
            byte[] buffer = new byte[s.Length];
            s.Read(buffer, 0, buffer.Length);
            return ASCIIEncoding.ASCII.GetString(buffer);
        }
        
        public string ByteCodes() {
            return BitConverter.ToString(RawData).Replace("-", "");
        }
    }
}
