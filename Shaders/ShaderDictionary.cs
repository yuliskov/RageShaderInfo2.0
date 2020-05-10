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
    public class ShaderDictionary {
        const uint magic = 1635280754;
        [System.ComponentModel.DisplayName("Vertex Fragments")]
        public Fragment[] VSFragments { get; private set; }
        [System.ComponentModel.DisplayName("Pixel Fragments")]
        public Fragment[] PSFragments { get; private set; }
        [System.ComponentModel.DisplayName("Shader Params (Global?)")]
        public ShaderParameter[] ShaderParameters1 { get; private set; }
        [System.ComponentModel.DisplayName("Shader Params (Temp?)")]
        public ShaderParameter[] ShaderParameters2 { get; private set; }
        [System.ComponentModel.DisplayName("Effect Techniques")]
        public Technique[] Techniques { get; private set; }

        [System.ComponentModel.Browsable(false)]
        public List<Pass> passes = new List<Pass>();

        [System.ComponentModel.DisplayName("All Passes")]
        public Pass[] Passes { 
            get {return passes.ToArray(); }
        }

        public ShaderDictionary(BinaryReader br) {
            Read( br );
            associateParameters();
        }

        public void Read( BinaryReader br ) {
            if ( br.ReadUInt32() != magic ) {
                return;
            }

            byte fragmentCount = br.ReadByte();
            if (fragmentCount > 0) {
                VSFragments = new Fragment[fragmentCount];
                for (int i = 0; i < fragmentCount; i++)
                {
                    Fragment csf = new Fragment(br);
                    VSFragments[i] = csf;
                }            
            }

            fragmentCount = br.ReadByte();
            if (fragmentCount > 0)
            {
                PSFragments = new Fragment[fragmentCount];
                for (int i = 0; i < fragmentCount; i++)
                {
                    Fragment csf = new Fragment(br);
                    PSFragments[i] = csf;
                }            
            }

            byte shaderParameterCount = br.ReadByte();
            if (shaderParameterCount > 0)
            {
                ShaderParameters1 = new ShaderParameter[shaderParameterCount];
                for (int i = 0; i < shaderParameterCount; i++)
                {
                    ShaderParameter param = new ShaderParameter();
                    param.Read(br);
                    ShaderParameters1[i] = param;
                }
            }
            
            shaderParameterCount = br.ReadByte();
            if (shaderParameterCount > 0)
            {
                ShaderParameters2 = new ShaderParameter[shaderParameterCount];
                for (int i = 0; i < shaderParameterCount; i++)
                {
                    ShaderParameter param = new ShaderParameter();
                    param.Read(br);
                    ShaderParameters2[i] = param;
                }
            }

            byte techniqueCount = br.ReadByte();
            if (techniqueCount > 0) {
                Techniques = new Technique[techniqueCount];
                for (int i = 0; i < techniqueCount; i++) {
                    Technique tech = new Technique(br, this);
                    Techniques[i] = tech;
                }
            }
        }

        private void associateParameters() {
            if (PSFragments != null && PSFragments.Length > 0)
            {
                for (int i = 0; i < PSFragments.Length; i++)
                {
                    if (PSFragments[i].Parameters != null && PSFragments[i].Parameters.Length > 0)
                    {
                        for (int j = 0; j < PSFragments[i].Parameters.Length; j++)
                        {
                            assocParameterByName(PSFragments[i].Parameters[j]);
                        }
                    }
                }
            }

            if (VSFragments != null && VSFragments.Length > 0)
            {
                for (int i = 0; i < VSFragments.Length; i++)
                {
                    if (VSFragments[i].Parameters != null && VSFragments[i].Parameters.Length > 0)
                    {
                        for (int j = 0; j < VSFragments[i].Parameters.Length; j++)
                        {
                            assocParameterByName(VSFragments[i].Parameters[j]);
                        }
                    }
                }
            }
        }

        private void assocParameterByName(FragmentParameter param)
        {
            for (int i = 0; i < ShaderParameters1.Length; i++) {
                if ( ShaderParameters1[i].Name == param.Name ) {
                    param.SetShaderParameter(ShaderParameters1[i], 1);
                }
            }
            for (int i = 0; i < ShaderParameters2.Length; i++)
            {
                if ( ShaderParameters2[i].Name == param.Name ) {
                    System.Diagnostics.Debug.Assert( param.ShaderParameter == null );
                    param.SetShaderParameter( ShaderParameters2[i], 2 );
                }
            }
        }
    }
}
