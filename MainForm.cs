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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Rage.Shaders;
using System.Reflection;

namespace RageShaderInfo {
    public partial class MainForm : Form {

        ShaderDictionary s;

        public MainForm() {
            InitializeComponent();
            updateTitle();
            this.tabPage1.Text = "Disassembly";
            this.tabPage2.Text = "Raw Bytes";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                BinaryReader br = new BinaryReader(new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read));
                s = new ShaderDictionary(br);
                propertyGrid1.SelectedObject = s;
                populateListBox();
                updateTitle();
            }
        }

        void populateListBox() {
            treeView1.Nodes.Clear();
            TreeNode root = treeView1.Nodes.Add("Techniques");
            root.Tag = s;
            if (s != null) {
                for (int i = 0; i < s.Techniques.Length; i++) {
                    TreeNode node = new TreeNode(s.Techniques[i].Name);
                    node.Tag = s.Techniques[i];
                    for (int j = 0; j < s.Techniques[i].Passes.Length; j++) { 
                        TreeNode node2 = new TreeNode("Pass "+j.ToString());
                        node2.Tag = s.Techniques[i].Passes[j];
                        TreeNode node3 = new TreeNode("Vertex Fragment");
                        node3.Tag = s.Techniques[i].Passes[j].VSFragment;
                        TreeNode node4 = new TreeNode("Pixel Fragment");
                        node4.Tag = s.Techniques[i].Passes[j].PSFragment;
                        node2.Nodes.Add(node3);
                        node2.Nodes.Add(node4);
                        node.Nodes.Add(node2);
                    }
                    root.Nodes.Add(node);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                propertyGrid1.SelectedObject = e.Node.Tag;
                if (e.Node.Tag is Fragment)
                {
                    Fragment frag = ((Fragment)e.Node.Tag);
                    richTextBox1.Text = frag.Disassemble();
                    richTextBox2.Text = frag.ByteCodes();
                }
                else
                {
                    richTextBox1.Text = "";
                    richTextBox2.Text = "";
                }
            }
            else {
                propertyGrid1.SelectedObject = s;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void updateTitle()
        {
            if (string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                this.Text = AppUtil.AssemblyTitle;
            }
            else
            {
                this.Text = String.Format("{0} - {1}", AppUtil.AssemblyTitle, openFileDialog1.FileName);
            }
        }
    }
}
