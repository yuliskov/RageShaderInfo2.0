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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace RageShaderInfo
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AppUtil.AssemblyTitle);
            this.labelProductName.Text = AppUtil.AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AppUtil.AssemblyVersion);
            this.labelCopyright.Text = AppUtil.AssemblyCopyright;
            this.labelCompanyName.Text = AppUtil.AssemblyCompany;
            this.textBoxDescription.Text = AppUtil.AssemblyDescription;
        }
    }
}
